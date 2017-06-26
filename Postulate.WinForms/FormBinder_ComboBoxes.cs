using Postulate.Orm.Abstract;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace Postulate.WinForms
{
    public partial class FormBinder<TRecord, TKey> where TRecord : Record<TKey>, new()
    {
        public void AddControl(ComboBox control, Expression<Func<TRecord, object>> property, int defaultValue = -1)
        {
            AddControl<int>(control, property, defaultValue);
        }

        public void AddControl<TValue>(ComboBox control, Expression<Func<TRecord, object>> property, TValue defaultValue = default(TValue))
        {
            PropertyInfo pi = GetProperty(property);
            Action<TRecord> setProperty = (record) =>
            {
                pi.SetValue(record, control.GetValue<TValue>());
            };

            var func = property.Compile();
            Action<TRecord> setControl = (record) =>
            {
                control.SetValue((TValue)func.Invoke(record));
            };

            if (typeof(TValue).Equals(typeof(int)))
            {
                int defaultIndex = Convert.ToInt32(defaultValue);
                AddComboBox(control, setProperty, setControl, () => { control.SelectedIndex = defaultIndex; }, defaultIndex != -1);
            }
            else
            {
                AddComboBox(control, setProperty, setControl, () => { control.SetValue(defaultValue); }, !defaultValue.Equals(default(TValue)));
            }
        }

        public void AddControl(ComboBox control, Action<TRecord> setProperty, Action<TRecord> setControl, int defaultValue = -1)
        {
            AddComboBox(control, setProperty, setControl, () => { control.SelectedIndex = defaultValue; }, (defaultValue != -1));
        }

        private void AddComboBox(ComboBox control, Action<TRecord> setProperty, Action<TRecord> setControl, Action defaultAction, bool invokeSetProperty)
        {
            control.SelectedIndexChanged += delegate (object sender, EventArgs e) { ValueChanged(setProperty); };
            _setControls.Add(setControl);
            _setDefaults.Add(new DefaultAction<TRecord, TKey>()
            {
                SetControl = defaultAction,
                InvokeSetProperty = invokeSetProperty,
                SetProperty = setProperty
            });
        }
    }
}