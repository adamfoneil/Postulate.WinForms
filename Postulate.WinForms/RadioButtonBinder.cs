using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Postulate.WinForms
{
    public class RadioButtonBinder<TValue>
    {
        private readonly RadioButton _radioButton;
        private readonly TValue _value;

        public RadioButtonBinder(RadioButton radioButton, TValue value)
        {
            _radioButton = radioButton;
            _value = value;
        }

        public RadioButton RadioButton {  get { return _radioButton; } }
        public TValue Value { get { return _value; } }
    }
}
