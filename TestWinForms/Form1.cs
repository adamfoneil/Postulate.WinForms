using Postulate.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test2.Models;
using TestWinForms.Queries;

namespace TestWinForms
{
    public partial class Form1 : Form
    {
        private FormBinder<Customer, int> _binder = null;

        public Form1()
        {
            InitializeComponent();

            _binder = new FormBinder<Customer, int>(this, new TdgDb());
            _binder.RecordSaved += binder_RecordSaved;
            _binder.ValidationPanel = validationPanel1;

            _binder.AddControl(cbOrg, c => c.OrganizationId);
            _binder.AddControl(tbFirstName, c => c.FirstName);
            _binder.AddControl(tbLastName, c => c.LastName);
            _binder.AddControl(tbAddress, c => c.Address);
            _binder.AddControl(tbCity, c => c.City);
            _binder.AddControl<string>(cbState, c => c.State);
            _binder.AddControl(tbZipCode, c => c.ZipCode);
            _binder.AddControl(tbEmail, c => c.Email);            
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
            _binder.CurrentRecord
        }
    }
}
