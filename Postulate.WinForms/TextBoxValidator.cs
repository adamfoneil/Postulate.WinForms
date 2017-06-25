using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Postulate.WinForms
{
    internal class TextBoxValidator
    {
        private readonly TextBox _textBox;
        private readonly EventHandler _validatedEvent;

        public TextBoxValidator(TextBox textBox, EventHandler validatedEvent)
        {
            _textBox = textBox;
            _validatedEvent = validatedEvent;
        }

        public EventHandler Validated {  get { return _validatedEvent; } }
    }
}
