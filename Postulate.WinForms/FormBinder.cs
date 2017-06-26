﻿using Postulate.Orm.Abstract;
using Postulate.WinForms.Controls;
using ReflectionHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace Postulate.WinForms
{
    public class FormBinder<TRecord, TKey> where TRecord : Record<TKey>, new()
    {
        private Form _form;
        private TRecord _record;
        private bool _suspend = false;
        private bool _dirty = false;
        private SqlDb<TKey> _db;
        private List<Action<TRecord>> _readActions;
        private List<Action> _clearActions;
        private Dictionary<string, bool> _textChanges = new Dictionary<string, bool>();
        private Dictionary<string, bool> _validated = new Dictionary<string, bool>();
        private Dictionary<string, TextBoxValidator> _textBoxValidators = new Dictionary<string, TextBoxValidator>();
        private Timer _escapeTimer = null;
        private TRecord _priorRecord = null;

        public ValidationPanel ValidationPanel { get; set; }

        public event EventHandler Dirty;

        public event EventHandler Clean;

        public event EventHandler SavingRecord;

        public event EventHandler RecordLoaded;

        public event EventHandler RecordSaved;

        public event EventHandler RecordDeleted;

        public event EventHandler NewRecord;

        public Control FirstControl { get; set; }

        public FormBinder(Form form, SqlDb<TKey> sqlDb)
        {
            _form = form;
            _form.KeyPreview = true;
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
                        _escapeTimer.Tick += _escapeTimer_Tick;
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
            };

            _readActions = new List<Action<TRecord>>();
            _clearActions = new List<Action>();
            _db = sqlDb;
        }

        private void _escapeTimer_Tick(object sender, EventArgs e)
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
                _record = record;
                _suspend = true;
                foreach (var action in _readActions) action.Invoke(record);
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
                foreach (var action in _clearActions) action.Invoke();
                NewRecord?.Invoke(this, new EventArgs());
                FirstControl?.Focus();
                ValidationPanel?.SetStatus(RecordStatus.Valid, "New record started");
                _suspend = false;
                return true;
            }
            return false;
        }

        public void UndoChanges()
        {
            IsDirty = false;
            _suspend = true;
            foreach (var action in _readActions) action.Invoke(_record);
            _suspend = false;
        }

        public bool Delete(string message = null)
        {
            if (string.IsNullOrEmpty(message)) message = "This will delete the record permanently.";
            if (MessageBox.Show(message, "Delete Record", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                _db.DeleteOne(_record);
                RecordDeleted?.Invoke(this, new EventArgs());
                IsDirty = false;
                return AddNew();
            }
            return false;
        }

        public void AddControl<TValue>(ComboBox control, Expression<Func<TRecord, object>> property)
        {
            PropertyInfo pi = GetProperty(property);
            Action<TRecord> writeAction = (record) =>
            {
                pi.SetValue(record, control.GetValue<TValue>());
            };

            var func = property.Compile();
            Action<TRecord> readAction = (record) =>
            {
                control.SetValue((TValue)func.Invoke(record));                
            };

            AddControl(control, writeAction, readAction);
        }

        public void AddControl(ComboBox control, Expression<Func<TRecord, object>> property)
        {
            AddControl<int>(control, property);
        }

        public void AddControl(ComboBox control, Action<TRecord> writeAction, Action<TRecord> readAction)
        {
            control.SelectedIndexChanged += delegate (object sender, EventArgs e) { ValueChanged(writeAction); };
            _readActions.Add(readAction);
            _clearActions.Add(() => { control.SelectedIndex = -1; });
        }

        public void AddControl(IFormBinderControl control, Action<TRecord> writeAction, Action<TRecord> readAction, Action clearAction)
        {
            control.ValueChanged += delegate (object sender, EventArgs e) { ValueChanged(writeAction); };
            _readActions.Add(readAction);
            _clearActions.Add(clearAction);
        }

        public void AddControl(TextBox control, Expression<Func<TRecord, object>> property)
        {
            AddControl<object>(control, property);
        }

        public void AddControl<TValue>(TextBox control, Expression<Func<TRecord, TValue>> property)
        {
            PropertyInfo pi = GetProperty(property);
            Action<TRecord> writeAction = (record) =>
            {
                pi.SetValue(record, control.Text);
            };

            MaxLengthAttribute attr;
            if (pi.HasAttribute(out attr)) control.MaxLength = attr.Length;

            var func = property.Compile();
            Action<TRecord> readAction = (record) =>
            {
                control.Text = func.Invoke(record)?.ToString();
                _textChanges[control.Name] = false;
            };

            AddControl(control, writeAction, readAction);
        }

        public void AddControl(TextBox control, Action<TRecord> writeAction, Action<TRecord> readAction)
        {
            EventHandler validated = delegate (object sender, EventArgs e)
            {
                if (_textChanges[control.Name])
                {
                    ValueChanged(writeAction);
                    _textChanges[control.Name] = false;
                    _validated[control.Name] = true;
                }
            };

            _textBoxValidators.Add(control.Name, new TextBoxValidator(control, validated));
            _textChanges.Add(control.Name, false);
            control.TextChanged += delegate (object sender, EventArgs e) { if (!_suspend) { _textChanges[control.Name] = true; _validated[control.Name] = false; } };
            control.Validated += validated;
            _readActions.Add(readAction);
            _clearActions.Add(() => { control.Text = null; });
        }

        public void AddControl(RadioButton control, Action<TRecord> writeAction, Action<TRecord> readAction)
        {
            control.CheckedChanged += delegate (object sender, EventArgs e) { ValueChanged(writeAction); };
            _readActions.Add(readAction);
            _clearActions.Add(() => { control.Checked = false; });
        }

        public void AddRadioButtons<TValue>(RadioButtonDictionary<TValue> radioButtons, Expression<Func<TRecord, TValue>> property)
        {
            PropertyInfo pi = GetProperty(property);

            foreach (var rbb in radioButtons)
            {
                Action<TRecord> writeAction = (record) =>
                {
                    pi.SetValue(record, rbb.Key);
                };

                var func = property.Compile();
                Action<TRecord> readAction = (record) =>
                {
                    rbb.Value.Checked = func.Invoke(record).Equals(rbb.Key);
                };

                AddControl(rbb.Value, writeAction, readAction);
            }
        }

        public void AddControl(CheckBox control, Action<TRecord> writeAction, Action<TRecord> readAction)
        {
            control.CheckedChanged += delegate (object sender, EventArgs e) { ValueChanged(writeAction); };
            _readActions.Add(readAction);
            _clearActions.Add(() => { control.Checked = false; });
        }

        public void AddControl(CheckBox control, Expression<Func<TRecord, bool>> property)
        {
            PropertyInfo pi = GetProperty(property);
            Action<TRecord> writeAction = (record) =>
            {
                pi.SetValue(record, control.Text);
            };

            var func = property.Compile();
            Action<TRecord> readAction = (record) =>
            {
                control.Checked = Convert.ToBoolean(func.Invoke(record));
            };

            AddControl(control, writeAction, readAction);
        }

        private void ValueChanged(Action<TRecord> setProperty)
        {
            if (_suspend) return;
            setProperty.Invoke(_record);
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
                    }
                    if (!value)
                    {
                        Clean?.Invoke(this, new EventArgs());
                        ValidationPanel?.SetStatus(RecordStatus.Valid, "Record restored...");
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
    }

    public interface IFormBinderControl
    {
        event EventHandler ValueChanged;
    }
}