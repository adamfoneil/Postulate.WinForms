using Postulate.Orm.Abstract;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace Postulate.WinForms
{
    public partial class FormBinder<TRecord, TKey> where TRecord : Record<TKey>, new()
    {
        public void AddControl(CheckBox control, Action<TRecord> writeAction, Action<TRecord> readAction, bool defaultValue = false)
        {
            control.CheckedChanged += delegate (object sender, EventArgs e) { ValueChanged(writeAction); };
            _readActions.Add(readAction);
            _clearActions.Add(() => { control.Checked = defaultValue; });
        }

        public void AddControl(CheckBox control, Expression<Func<TRecord, bool>> property, bool defaultValue = false)
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

            AddControl(control, writeAction, readAction, defaultValue);
        }
    }
}
