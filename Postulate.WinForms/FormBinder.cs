using Postulate.Orm.Abstract;
using Postulate.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace Postulate.WinForms
{
    internal delegate bool BinderAction();

    public partial class FormBinder<TRecord, TKey> where TRecord : Record<TKey>, new()
    {
        private Form _form;
        private TRecord _record;
        private bool _suspend = false;
        private bool _dirty = false;
        private SqlDb<TKey> _db;
        private List<Action<TRecord>> _setControls;
        private List<DefaultAction<TRecord, TKey>> _setDefaults;
        private Dictionary<string, bool> _textChanges = new Dictionary<string, bool>();
        private Dictionary<string, bool> _validated = new Dictionary<string, bool>();
        private Dictionary<string, TextBoxValidator> _textBoxValidators = new Dictionary<string, TextBoxValidator>();
        private Timer _escapeTimer = null;
        private TRecord _priorRecord = null;
        private DittoAction<TRecord, TKey> _ditto = null;

        public ValidationPanel ValidationPanel { get; set; }

        public event EventHandler Dirty;

        public event EventHandler Clean;

        public event EventHandler SavingRecord;

        public event EventHandler RecordLoaded;

        public event EventHandler RecordSaved;

        public event EventHandler RecordDeleted;

        public event EventHandler NewRecord;

        public string DeletePrompt { get; set; }

        public Control FirstControl { get; set; }

        private FormBinderToolStrip _toolStrip;
        public FormBinderToolStrip ToolStrip
        {
            get { return _toolStrip; }
            set
            {
                _toolStrip = value;

                Action<BinderAction> tryAction = (action) =>
                {
                    try
                    {
                        action.Invoke();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                };

                _toolStrip.AddNew += delegate (object sender, EventArgs e) { tryAction(AddNew); };
                _toolStrip.Save += delegate (object sender, EventArgs e) { tryAction(Save); };
                _toolStrip.Delete += delegate (object sender, EventArgs e) { tryAction(Delete); };
            }
        }

        public FormBinder(Form form, SqlDb<TKey> sqlDb)
        {
            _form = form;
            _form.KeyPreview = true;

            _form.Load += delegate (object sender, EventArgs e) { AddNew(); };

            _form.FormClosing += delegate (object sender, FormClosingEventArgs e)
            {
                if (!Save())
                {
                    if (MessageBox.Show(
                        "The record could not be saved. Click OK to try again, or Cancel to lose your changes.",
                        "Form Closing", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        e.Cancel = true;
                    }
                }
            };

            _form.KeyDown += delegate (object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter && e.Shift && !e.Control)
                {
                    Save();
                    e.Handled = true;
                }

                if (e.KeyCode == Keys.Enter && e.Shift && e.Control)
                {
                    Validate();
                    e.Handled = true;
                }

                if (e.KeyCode == Keys.Add && e.Control)
                {
                    AddNew();
                    e.Handled = true;
                }

                if (e.KeyCode == Keys.Subtract && e.Control)
                {
                    Delete();
                    e.Handled = true;
                }

                if (e.KeyCode == Keys.Escape)
                {
                    if (_escapeTimer == null)
                    {
                        _escapeTimer = new Timer();
                        _escapeTimer.Tick += escapeTimer_Tick;
                        _escapeTimer.Interval = 500;
                        _escapeTimer.Start();
                    }
                    else
                    {
                        if (MessageBox.Show("Click OK to undo changes to the record.", "Undo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            UndoChanges();
                        }
                        e.Handled = true;
                    }
                }

                if (e.KeyCode == Keys.OemQuotes && e.Control)
                {
                    if (_priorRecord != null)
                    {                        
                        _ditto?.SetControl.Invoke(_priorRecord);
                        _ditto?.SetProperty.Invoke(_record);
                    }
                        
                    e.Handled = true;
                }
            };

            _setControls = new List<Action<TRecord>>();
            _setDefaults = new List<DefaultAction<TRecord, TKey>>();
            _db = sqlDb;
        }

        private void escapeTimer_Tick(object sender, EventArgs e)
        {
            _escapeTimer.Stop();
            _escapeTimer = null;
        }

        public TRecord CurrentRecord
        {
            get { return _record; }
        }

        public bool Load(TKey id)
        {
            var record = _db.Find<TRecord>(id);
            return Load(record);
        }

        public bool Load(TRecord record)
        {
            if (record == null) throw new ArgumentNullException(nameof(record));

            if (Save())
            {
                if (_record != null) _priorRecord = _record;
                _record = record;
                _suspend = true;
                foreach (var action in _setControls) action.Invoke(record);
                RecordLoaded?.Invoke(this, new EventArgs());
                ValidationPanel?.SetStatus(RecordStatus.Valid, "Record loaded");
                _suspend = false;
                return true;
            }
            return false;
        }

        public bool Validate()
        {
            using (var cn = _db.GetConnection())
            {
                cn.Open();
                string message;
                RecordStatus status = (_record.IsValid(cn, out message)) ? RecordStatus.Editing : RecordStatus.Invalid;
                ValidationPanel?.SetStatus(status, message ?? "Record has no errors");
                return (status == RecordStatus.Valid);
            }
        }

        public bool Save()
        {
            // get the textboxes with changes that haven't fired Validated event
            var unvalidatedTextboxes = _textChanges.Where(kp => kp.Value && !_validated[kp.Key]).Select(kp => kp.Key).ToList();
            foreach (var tb in unvalidatedTextboxes) _textBoxValidators[tb].Validated.Invoke(this, new EventArgs());

            if (_suspend) return true;
            _suspend = true;

            try
            {
                if (IsDirty)
                {
                    SavingRecord?.Invoke(this, new EventArgs());
                    _db.Save(_record);
                    IsDirty = false;
                    RecordSaved?.Invoke(this, new EventArgs());
                    ValidationPanel?.SetStatus(RecordStatus.Valid, "Record saved");
                }
                return true;
            }
            catch (Exception exc)
            {
                ValidationPanel?.SetStatus(RecordStatus.Invalid, exc.Message);

                if (MessageBox.Show($"The record could not be saved: {exc.Message}\r\nClick OK to try again or Cancel to lose your changes.", "Save Error", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    UndoChanges();
                    return true;
                }
                return false;
            }
            finally
            {
                _suspend = false;
            }
        }

        public bool AddNew()
        {
            if (Save())
            {
                if (_record != null) _priorRecord = _record;
                _record = new TRecord();
                _suspend = true;
                foreach (var action in _setDefaults)
                {
                    action.SetControl.Invoke();
                    if (action.InvokeSetProperty) action.SetProperty.Invoke(_record);
                }
                NewRecord?.Invoke(this, new EventArgs());
                FirstControl?.Focus();
                ValidationPanel?.SetStatus(RecordStatus.Valid, "New record started");
                ToolStrip?.OnNew();
                _suspend = false;                
                return true;
            }
            return false;
        }

        public void UndoChanges()
        {
            IsDirty = false;
            _suspend = true;
            foreach (var action in _setControls) action.Invoke(_record);
            _suspend = false;
        }

        public bool Delete()
        {
            if (string.IsNullOrEmpty(DeletePrompt)) DeletePrompt = "This will delete the record permanently.";
            if (MessageBox.Show(DeletePrompt, "Delete Record", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                _db.DeleteOne(_record);
                RecordDeleted?.Invoke(this, new EventArgs());
                IsDirty = false;
                return AddNew();
            }
            return false;
        }

        public void AddControl(IFormBinderControl control, Action<TRecord> setProperty, Action<TRecord> setControl, Action defaultAction, bool invokeSetterOnDefault = false)
        {
            control.ValueChanged += delegate (object sender, EventArgs e) { ValueChanged(setProperty); };
            _setControls.Add(setControl);
            _setDefaults.Add(new DefaultAction<TRecord, TKey>()
            {
                SetControl = defaultAction,
                InvokeSetProperty = invokeSetterOnDefault,
                SetProperty = setProperty
            });
        }

        private void ValueChanged(Action<TRecord> setProperty)
        {            
            setProperty.Invoke(_record);
            if (_suspend) return;
            IsDirty = true;
        }

        public bool IsDirty
        {
            get { return _dirty; }
            set
            {
                if (_dirty != value)
                {
                    _dirty = value;
                    if (value)
                    {
                        Dirty?.Invoke(this, new EventArgs());
                        ValidationPanel?.SetStatus(RecordStatus.Editing, "Edit in progress...");
                        ToolStrip?.OnDirty();
                    }
                    if (!value)
                    {
                        Clean?.Invoke(this, new EventArgs());
                        ValidationPanel?.SetStatus(RecordStatus.Valid, "Record restored...");
                        ToolStrip?.OnClean(CurrentRecord?.IsNew() ?? false);
                    }
                }
            }
        }

        public bool FindCurrentPosition(BindingList<TRecord> list, out int position)
        {
            position = -1;

            if (_record == null) return false;

            for (int index = 0; index < list.Count; index++)
            {
                if (list[index].Id.Equals(_record.Id))
                {
                    position = index;
                    return true;
                }
            }

            return false;
        }

        private string PropertyNameFromLambda(Expression expression)
        {
            // thanks to http://odetocode.com/blogs/scott/archive/2012/11/26/why-all-the-lambdas.aspx
            // thanks to http://stackoverflow.com/questions/671968/retrieving-property-name-from-lambda-expression

            LambdaExpression le = expression as LambdaExpression;
            if (le == null) throw new ArgumentException("expression");

            MemberExpression me = null;
            if (le.Body.NodeType == ExpressionType.Convert)
            {
                me = ((UnaryExpression)le.Body).Operand as MemberExpression;
            }
            else if (le.Body.NodeType == ExpressionType.MemberAccess)
            {
                me = le.Body as MemberExpression;
            }

            if (me == null) throw new ArgumentException("expression");

            return me.Member.Name;
        }

        private PropertyInfo GetProperty<TValue>(Expression<Func<TRecord, TValue>> property)
        {
            string propName = PropertyNameFromLambda(property);
            PropertyInfo pi = typeof(TRecord).GetProperty(propName);
            return pi;
        }

        private void InitDitto(Control control, Action<TRecord> setProperty, Action<TRecord> setControl)
        {
            control.Enter += delegate (object sender, EventArgs e) { _ditto = new DittoAction<TRecord, TKey>() { SetControl = setControl, SetProperty = setProperty }; };
            control.Leave += delegate (object sender, EventArgs e) { _ditto = null; };
        }
    }

    internal class DefaultAction<TRecord, TKey> where TRecord : Record<TKey>
    {                
        public Action SetControl { get; set; }
        public bool InvokeSetProperty { get; set; }
        public Action<TRecord> SetProperty { get; set; }
    }

    internal class DittoAction<TRecord, TKey> where TRecord : Record<TKey>
    {
        public Action<TRecord> SetControl { get; set; }
        public Action<TRecord> SetProperty { get; set; }
    }
}