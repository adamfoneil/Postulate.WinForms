namespace TestWinForms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbZipCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbOrg = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.validationPanel1 = new Postulate.WinForms.Controls.ValidationPanel();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rbTaxExemptFalse = new System.Windows.Forms.RadioButton();
            this.rbIsTaxExemptTrue = new System.Windows.Forms.RadioButton();
            this.chkSendNewsletter = new System.Windows.Forms.CheckBox();
            this.formBinderToolStrip1 = new Postulate.WinForms.Controls.FormBinderToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbFind = new System.Windows.Forms.ToolStripTextBox();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.formBinderToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(83, 68);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(191, 20);
            this.tbFirstName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "First Name:";
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(83, 94);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(191, 20);
            this.tbLastName.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Last Name:";
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(83, 120);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(191, 20);
            this.tbAddress.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Address:";
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(83, 146);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(191, 20);
            this.tbCity.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "City:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "State:";
            // 
            // tbZipCode
            // 
            this.tbZipCode.Location = new System.Drawing.Point(83, 199);
            this.tbZipCode.Name = "tbZipCode";
            this.tbZipCode.Size = new System.Drawing.Size(94, 20);
            this.tbZipCode.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Zip Code:";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(83, 225);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(191, 20);
            this.tbEmail.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Email:";
            // 
            // cbOrg
            // 
            this.cbOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrg.FormattingEnabled = true;
            this.cbOrg.Location = new System.Drawing.Point(83, 41);
            this.cbOrg.Name = "cbOrg";
            this.cbOrg.Size = new System.Drawing.Size(191, 21);
            this.cbOrg.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Org:";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(80, 304);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(35, 13);
            this.lblId.TabIndex = 23;
            this.lblId.Text = "label9";
            // 
            // validationPanel1
            // 
            this.validationPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.validationPanel1.BackColor = System.Drawing.SystemColors.Info;
            this.validationPanel1.Location = new System.Drawing.Point(12, 370);
            this.validationPanel1.Name = "validationPanel1";
            this.validationPanel1.Size = new System.Drawing.Size(396, 31);
            this.validationPanel1.TabIndex = 24;
            // 
            // cbState
            // 
            this.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbState.FormattingEnabled = true;
            this.cbState.Location = new System.Drawing.Point(83, 172);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(191, 21);
            this.cbState.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 276);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Sales Tax:";
            // 
            // rbTaxExemptFalse
            // 
            this.rbTaxExemptFalse.AutoSize = true;
            this.rbTaxExemptFalse.Location = new System.Drawing.Point(83, 274);
            this.rbTaxExemptFalse.Name = "rbTaxExemptFalse";
            this.rbTaxExemptFalse.Size = new System.Drawing.Size(92, 17);
            this.rbTaxExemptFalse.TabIndex = 21;
            this.rbTaxExemptFalse.TabStop = true;
            this.rbTaxExemptFalse.Text = "Apply (default)";
            this.rbTaxExemptFalse.UseVisualStyleBackColor = true;
            // 
            // rbIsTaxExemptTrue
            // 
            this.rbIsTaxExemptTrue.AutoSize = true;
            this.rbIsTaxExemptTrue.Location = new System.Drawing.Point(181, 274);
            this.rbIsTaxExemptTrue.Name = "rbIsTaxExemptTrue";
            this.rbIsTaxExemptTrue.Size = new System.Drawing.Size(60, 17);
            this.rbIsTaxExemptTrue.TabIndex = 22;
            this.rbIsTaxExemptTrue.TabStop = true;
            this.rbIsTaxExemptTrue.Text = "Exempt";
            this.rbIsTaxExemptTrue.UseVisualStyleBackColor = true;
            // 
            // chkSendNewsletter
            // 
            this.chkSendNewsletter.AutoSize = true;
            this.chkSendNewsletter.Location = new System.Drawing.Point(83, 251);
            this.chkSendNewsletter.Name = "chkSendNewsletter";
            this.chkSendNewsletter.Size = new System.Drawing.Size(104, 17);
            this.chkSendNewsletter.TabIndex = 19;
            this.chkSendNewsletter.Text = "Send Newsletter";
            this.chkSendNewsletter.UseVisualStyleBackColor = true;
            // 
            // formBinderToolStrip1
            // 
            this.formBinderToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tbFind,
            this.btnFind});
            this.formBinderToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.formBinderToolStrip1.Name = "formBinderToolStrip1";
            this.formBinderToolStrip1.Size = new System.Drawing.Size(420, 25);
            this.formBinderToolStrip1.TabIndex = 25;
            this.formBinderToolStrip1.Text = "formBinderToolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(46, 22);
            this.toolStripLabel1.Text = "Find Id:";
            // 
            // tbFind
            // 
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(100, 25);
            // 
            // btnFind
            // 
            this.btnFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(26, 22);
            this.btnFind.Text = "Go";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 413);
            this.Controls.Add(this.formBinderToolStrip1);
            this.Controls.Add(this.chkSendNewsletter);
            this.Controls.Add(this.rbIsTaxExemptTrue);
            this.Controls.Add(this.rbTaxExemptFalse);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbState);
            this.Controls.Add(this.validationPanel1);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbOrg);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbZipCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbCity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFirstName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.formBinderToolStrip1.ResumeLayout(false);
            this.formBinderToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbZipCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbOrg;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblId;
        private Postulate.WinForms.Controls.ValidationPanel validationPanel1;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbTaxExemptFalse;
        private System.Windows.Forms.RadioButton rbIsTaxExemptTrue;
        private System.Windows.Forms.CheckBox chkSendNewsletter;
        private Postulate.WinForms.Controls.FormBinderToolStrip formBinderToolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tbFind;
        private System.Windows.Forms.ToolStripButton btnFind;
    }
}

