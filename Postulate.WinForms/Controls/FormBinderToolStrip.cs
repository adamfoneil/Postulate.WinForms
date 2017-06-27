using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Postulate.WinForms.Controls
{
    public class FormBinderToolStrip : ToolStrip
    {
        public event EventHandler AddNew;
        public event EventHandler Save;
        public event EventHandler Delete;

        private ToolStripButton _btnAddNew = new ToolStripButton()
        {
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
            Text = "Add New",
            Image = Resources.AddNew
        };

        private ToolStripButton _btnDelete = new ToolStripButton()
        {
            DisplayStyle = ToolStripItemDisplayStyle.Image,
            Image = Resources.Delete
        };

        private ToolStripButton _btnSave = new ToolStripButton()
        {
            DisplayStyle = ToolStripItemDisplayStyle.Image,
            Text = "Save",
            Image = Resources.Save
        };

        public FormBinderToolStrip()
        {            
            _btnAddNew.Click += delegate (object sender, EventArgs e) { AddNew?.Invoke(this, e); };            
            _btnSave.Click += delegate (object sender, EventArgs e) { Save?.Invoke(this, e); };            
            _btnDelete.Click += delegate (object sender, EventArgs e) { Delete?.Invoke(this, e); };
            Items.AddRange(new ToolStripItem[] { _btnAddNew, _btnSave, _btnDelete });
        }

        public ToolStripButton AddNewButton { get { return _btnAddNew; } }
        public ToolStripButton DeleteButton {  get { return _btnDelete; } }
        public ToolStripButton SaveButton {  get { return _btnSave; } }
    }
}
