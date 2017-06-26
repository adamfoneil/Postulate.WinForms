using Postulate.Orm.Abstract;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace Postulate.WinForms
{
    public partial class FormBinder<TRecord, TKey> where TRecord : Record<TKey>, new()
    {
        public void AddControl(CheckBox control, Action<TRecord> setProperty, Action<TRecord> setControl, bool defaultValue = false)
        {
            control.CheckedChanged += delegate (object sender, EventArgs e) { ValueChanged(setProperty); };
            _setControls.Add(setControl);
            _setDefaults.Add(() => { control.Checked = defaultValue; });
        }

        public void AddControl(CheckBox control, Expression<Func<TRecord, bool>> property, bool defaultValue = false)
        {
            PropertyInfo pi = GetProperty(property);
            Action<TRecord> setProperty = (record) =>
            {
                pi.SetValue(record, control.Checked);
            };

            var func = property.Compile();
            Action<TRecord> setControl = (record) =>
            {
                control.Checked = func.Invoke(record);
            };

            AddControl(control, setProperty, setControl, defaultValue);
        }
    }
}
