using System.Drawing;
using System.Windows.Forms;

namespace Postulate.WinForms.Controls
{
    public enum RecordStatus
    {
        Valid,
        Invalid,
        Editing
    }

    public partial class ValidationPanel : UserControl
    {
        public ValidationPanel()
        {
            InitializeComponent();
        }

        public new Font Font
        {
            get { return label1.Font; }
            set { label1.Font = value; }
        }

        public void SetStatus(RecordStatus status, string message = null)
        {
            pbStatus.Image = imageList1.Images[(int)status];
            label1.Text = message?.Replace("\r\n", " ");
        }
    }
}