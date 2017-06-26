using Postulate.Orm.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
            Action<TRecord> writeAction = (record) =>
            {
                pi.SetValue(record, control.GetValue<TValue>());
            };

            var func = property.Compile();
            Action<TRecord> readAction = (record) =>
            {
                control.SetValue((TValue)func.Invoke(record));
            };

            if (typeof(TValue).Equals(typeof(int)))
            {
                AddComboBox(control, writeAction, readAction, () => { control.SelectedIndex = -1; });
            }
            else
            {                
                AddComboBox(control, writeAction, readAction, () => { control.SetValue(defaultValue); });
            }            
        }

        public void AddControl(ComboBox control, Action<TRecord> writeAction, Action<TRecord> readAction, int defaultValue = -1)
        {
            AddComboBox(control, writeAction, readAction, () => { control.SelectedIndex = defaultValue; });
        }

        private void AddComboBox(ComboBox control, Action<TRecord> writeAction, Action<TRecord> readAction, Action clearAction)
        {
            control.SelectedIndexChanged += delegate (object sender, EventArgs e) { ValueChanged(writeAction); };
            _readActions.Add(readAction);
            _clearActions.Add(clearAction);
        }
    }
}
