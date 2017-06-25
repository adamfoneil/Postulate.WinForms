using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postulate.WinForms
{
    public class ListItem<TValue>
    {
        public ListItem(TValue value, string text)
        {
            Value = value;
            Text = text;
        }

        public TValue Value { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public override bool Equals(object obj)
        {
            var listItem = obj as ListItem<TValue>;
            if (listItem != null) return listItem.Value.Equals(Value);
            return obj.Equals(this);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
