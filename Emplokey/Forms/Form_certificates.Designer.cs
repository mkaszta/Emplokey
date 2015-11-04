namespace Emplokey
{
    partial class Form_certificates
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
            this.listBoxDrives = new System.Windows.Forms.ListBox();
            this.btnCreateCert = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.groupBoxDrives = new System.Windows.Forms.GroupBox();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.buttonDeregister = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.groupBoxUsbCertificates = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelDbName = new System.Windows.Forms.Label();
            this.textBoxDbName = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.buttonRevert = new System.Windows.Forms.Button();
            this.groupBoxDrives.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxUsbCertificates.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxDrives
            // 
            this.listBoxDrives.FormattingEnabled = true;
            this.listBoxDrives.Location = new System.Drawing.Point(27, 19);
            this.listBoxDrives.Name = "listBoxDrives";
            this.listBoxDrives.Size = new System.Drawing.Size(85, 108);
            this.listBoxDrives.TabIndex = 0;
            // 
            // btnCreateCert
            // 
            this.btnCreateCert.Location = new System.Drawing.Point(6, 19);
            this.btnCreateCert.Name = "btnCreateCert";
            this.btnCreateCert.Size = new System.Drawing.Size(106, 23);
            this.btnCreateCert.TabIndex = 1;
            this.btnCreateCert.Text = "Create";
            this.btnCreateCert.UseVisualStyleBackColor = true;
            this.btnCreateCert.Click += new System.EventHandler(this.btnCreateCert_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(603, 32);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(106, 23);
            this.btnRegister.TabIndex = 2;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // groupBoxDrives
            // 
            this.groupBoxDrives.Controls.Add(this.listBoxDrives);
            this.groupBoxDrives.Location = new System.Drawing.Point(6, 20);
            this.groupBoxDrives.Name = "groupBoxDrives";
            this.groupBoxDrives.Size = new System.Drawing.Size(138, 143);
            this.groupBoxDrives.TabIndex = 3;
            this.groupBoxDrives.TabStop = false;
            this.groupBoxDrives.Text = "Available drives";
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.btnRemove);
            this.groupBoxOptions.Controls.Add(this.btnCreateCert);
            this.groupBoxOptions.Location = new System.Drawing.Point(150, 20);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(122, 143);
            this.groupBoxOptions.TabIndex = 4;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Certificate options";
            // 
            // buttonDeregister
            // 
            this.buttonDeregister.Enabled = false;
            this.buttonDeregister.Location = new System.Drawing.Point(603, 61);
            this.buttonDeregister.Name = "buttonDeregister";
            this.buttonDeregister.Size = new System.Drawing.Size(106, 23);
            this.buttonDeregister.TabIndex = 4;
            this.buttonDeregister.Text = "Deregister";
            this.buttonDeregister.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(6, 48);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(106, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // groupBoxUsbCertificates
            // 
            this.groupBoxUsbCertificates.Controls.Add(this.groupBoxDrives);
            this.groupBoxUsbCertificates.Controls.Add(this.groupBoxOptions);
            this.groupBoxUsbCertificates.Location = new System.Drawing.Point(12, 12);
            this.groupBoxUsbCertificates.Name = "groupBoxUsbCertificates";
            this.groupBoxUsbCertificates.Size = new System.Drawing.Size(283, 190);
            this.groupBoxUsbCertificates.TabIndex = 5;
            this.groupBoxUsbCertificates.TabStop = false;
            this.groupBoxUsbCertificates.Text = "USB certificates";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonRevert);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.labelDbName);
            this.groupBox1.Controls.Add(this.textBoxDbName);
            this.groupBox1.Controls.Add(this.labelAddress);
            this.groupBox1.Controls.Add(this.labelPassword);
            this.groupBox1.Controls.Add(this.labelUsername);
            this.groupBox1.Controls.Add(this.textBoxAddress);
            this.groupBox1.Controls.Add(this.textBoxUsername);
            this.groupBox1.Controls.Add(this.textBoxPassword);
            this.groupBox1.Location = new System.Drawing.Point(301, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 190);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server";
            // 
            // labelDbName
            // 
            this.labelDbName.AutoSize = true;
            this.labelDbName.Location = new System.Drawing.Point(5, 61);
            this.labelDbName.Name = "labelDbName";
            this.labelDbName.Size = new System.Drawing.Size(56, 13);
            this.labelDbName.TabIndex = 26;
            this.labelDbName.Text = "DB Name:";
            // 
            // textBoxDbName
            // 
            this.textBoxDbName.Location = new System.Drawing.Point(67, 58);
            this.textBoxDbName.Name = "textBoxDbName";
            this.textBoxDbName.Size = new System.Drawing.Size(195, 20);
            this.textBoxDbName.TabIndex = 20;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(13, 35);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(48, 13);
            this.labelAddress.TabIndex = 25;
            this.labelAddress.Text = "Address:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(5, 113);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 24;
            this.labelPassword.Text = "Password:";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(3, 87);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(58, 13);
            this.labelUsername.TabIndex = 23;
            this.labelUsername.Text = "Username:";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(67, 32);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(195, 20);
            this.textBoxAddress.TabIndex = 19;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(67, 84);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(195, 20);
            this.textBoxUsername.TabIndex = 21;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(67, 110);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(195, 20);
            this.textBoxPassword.TabIndex = 22;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(67, 145);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 23);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // buttonRevert
            // 
            this.buttonRevert.Location = new System.Drawing.Point(171, 145);
            this.buttonRevert.Name = "buttonRevert";
            this.buttonRevert.Size = new System.Drawing.Size(91, 23);
            this.buttonRevert.TabIndex = 28;
            this.buttonRevert.Text = "Revert changes";
            this.buttonRevert.UseVisualStyleBackColor = true;
            // 
            // Form_certificates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 281);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonDeregister);
            this.Controls.Add(this.groupBoxUsbCertificates);
            this.Controls.Add(this.btnRegister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_certificates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Certificates";
            this.groupBoxDrives.ResumeLayout(false);
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxUsbCertificates.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxDrives;
        private System.Windows.Forms.Button btnCreateCert;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.GroupBox groupBoxDrives;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.Button buttonDeregister;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.GroupBox groupBoxUsbCertificates;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonRevert;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label labelDbName;
        private System.Windows.Forms.TextBox textBoxDbName;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
    }
}