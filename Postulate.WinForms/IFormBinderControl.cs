using System;

namespace Postulate.WinForms
{
    public interface IFormBinderControl
    {
        string Name { get; }

        event EventHandler ValueChanged;
    }
}
