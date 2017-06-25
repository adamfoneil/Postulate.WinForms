using Postulate.Sql.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Postulate.WinForms
{
    public static class ComboBoxExtensions
    {
        public static void Fill<TValue>(this ComboBox comboBox, Query<ListItem<TValue>> query)
        {
            var results = query.Execute();
            FillInner(comboBox, results);
        }

        public static void Fill<TValue>(this ComboBox comboBox, IDbConnection connection, Query<ListItem<TValue>> query)
        {
            var results = query.Execute(connection);
            FillInner(comboBox, results);
        }

        private static void FillInner<TValue>(ComboBox comboBox, IEnumerable<ListItem<TValue>> results)
        {
            comboBox.Items.Clear();
            foreach (var item in results) comboBox.Items.Add(item);
        }

        public static TValue GetValue<TValue>(this ComboBox comboBox, TValue defaultValue = default(TValue))
        {
            return (comboBox.SelectedItem != null) ? ((ListItem<TValue>)comboBox.SelectedItem).Value : defaultValue;
        }

        public static void SetValue<TValue>(this ComboBox comboBox, TValue value)
        {
            var items = comboBox.Items.OfType<ListItem<TValue>>();
            int index = 0;
            foreach (var item in items)
            {
                if (item.Value.Equals(value))
                {
                    comboBox.SelectedIndex = index;
                    return;
                }
                index++;
            }
            comboBox.SelectedIndex = -1;
        }
    }
}
