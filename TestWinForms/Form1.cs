using Postulate.WinForms;
using System;
using System.Windows.Forms;
using Test2.Models;
using TestWinForms.Queries;

namespace TestWinForms
{
    public partial class Form1 : Form
    {
        private TdgDb _db = new TdgDb();
        private FormBinder<Customer, int> _binder = null;

        public Form1()
        {
            InitializeComponent();

            _binder = new FormBinder<Customer, int>(this, _db);
            _binder.RecordSaved += binder_RecordSaved;
            _binder.RecordLoaded += binder_RecordSaved;
            _binder.ValidationPanel = validationPanel1;

            _binder.AddControl(cbOrg, c => c.OrganizationId);
            _binder.AddControl(tbFirstName, c => c.FirstName);
            _binder.AddControl(tbLastName, c => c.LastName);
            _binder.AddControl(tbAddress, c => c.Address);
            _binder.AddControl(tbCity, c => c.City);
            _binder.AddControl<string>(cbState, c => c.State);
            _binder.AddControl(tbZipCode, c => c.ZipCode);
            _binder.AddControl(tbEmail, c => c.Email);
            _binder.AddRadioButtons(new RadioButtonDictionary<bool>()
            {
                { true, rbIsTaxExemptTrue },
                { false, rbTaxExemptFalse }
            }, c => c.IsTaxExempt);
        }

        private void binder_RecordSaved(object sender, EventArgs e)
        {
            lblId.Text = _binder.CurrentRecord.Id.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            cbOrg.Fill(new OrgSelect());
            cbState.Fill(new StateSelect());

            _binder.AddNew();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                if (int.TryParse(tbFind.Text, out id))
                {                    
                    _binder.Load(id);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
