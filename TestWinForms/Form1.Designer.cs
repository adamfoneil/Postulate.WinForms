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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(84, 76);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(191, 20);
            this.tbFirstName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Name:";
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(84, 102);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(191, 20);
            this.tbLastName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Last Name:";
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(84, 128);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(191, 20);
            this.tbAddress.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Address:";
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(84, 154);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(191, 20);
            this.tbCity.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "City:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "State:";
            // 
            // tbZipCode
            // 
            this.tbZipCode.Location = new System.Drawing.Point(84, 207);
            this.tbZipCode.Name = "tbZipCode";
            this.tbZipCode.Size = new System.Drawing.Size(94, 20);
            this.tbZipCode.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Zip Code:";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(84, 233);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(191, 20);
            this.tbEmail.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Email:";
            // 
            // cbOrg
            // 
            this.cbOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrg.FormattingEnabled = true;
            this.cbOrg.Location = new System.Drawing.Point(84, 49);
            this.cbOrg.Name = "cbOrg";
            this.cbOrg.Size = new System.Drawing.Size(191, 21);
            this.cbOrg.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Org:";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(81, 289);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(35, 13);
            this.lblId.TabIndex = 16;
            this.lblId.Text = "label9";
            // 
            // validationPanel1
            // 
            this.validationPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.validationPanel1.BackColor = System.Drawing.SystemColors.Info;
            this.validationPanel1.Location = new System.Drawing.Point(12, 318);
            this.validationPanel1.Name = "validationPanel1";
            this.validationPanel1.Size = new System.Drawing.Size(396, 31);
            this.validationPanel1.TabIndex = 17;
            // 
            // cbState
            // 
            this.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbState.FormattingEnabled = true;
            this.cbState.Location = new System.Drawing.Point(84, 180);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(191, 21);
            this.cbState.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 261);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Sales Tax:";
            // 
            // rbTaxExemptFalse
            // 
            this.rbTaxExemptFalse.AutoSize = true;
            this.rbTaxExemptFalse.Location = new System.Drawing.Point(84, 259);
            this.rbTaxExemptFalse.Name = "rbTaxExemptFalse";
            this.rbTaxExemptFalse.Size = new System.Drawing.Size(92, 17);
            this.rbTaxExemptFalse.TabIndex = 20;
            this.rbTaxExemptFalse.TabStop = true;
            this.rbTaxExemptFalse.Text = "Apply (default)";
            this.rbTaxExemptFalse.UseVisualStyleBackColor = true;
            // 
            // rbIsTaxExemptTrue
            // 
            this.rbIsTaxExemptTrue.AutoSize = true;
            this.rbIsTaxExemptTrue.Location = new System.Drawing.Point(182, 259);
            this.rbIsTaxExemptTrue.Name = "rbIsTaxExemptTrue";
            this.rbIsTaxExemptTrue.Size = new System.Drawing.Size(60, 17);
            this.rbIsTaxExemptTrue.TabIndex = 21;
            this.rbIsTaxExemptTrue.TabStop = true;
            this.rbIsTaxExemptTrue.Text = "Exempt";
            this.rbIsTaxExemptTrue.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(249, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(201, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Find Id:";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(355, 10);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(32, 23);
            this.btnFind.TabIndex = 24;
            this.btnFind.Text = "Go";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 361);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox1);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnFind;
    }
}

