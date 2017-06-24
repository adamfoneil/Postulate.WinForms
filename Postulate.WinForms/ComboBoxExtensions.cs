using Postulate.Sql.Abstract;
using System;
using System.Collections.Generic;
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
            comboBox.Items.Clear();
            foreach (var item in results) comboBox.Items.Add(item);
        }

        public static TValue GetValue<TValue>(this ComboBox comboBox, TValue defaultValue = default(TValue))
        {
            return (comboBox.SelectedItem != null) ? ((ListItem<TValue>)comboBox.SelectedItem).Value : defaultValue;
        }
    }
}
