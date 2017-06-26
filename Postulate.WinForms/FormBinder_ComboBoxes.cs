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

        public void AddControl(ComboBox control, Action<TRecord> writeAction, Action<TRecord> readAction, int defaultValue = -1)
        {
            control.SelectedIndexChanged += delegate (object sender, EventArgs e) { ValueChanged(writeAction); };
            _readActions.Add(readAction);
            _clearActions.Add(() => { control.SelectedIndex = defaultValue; });
        }
    }
}
