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
            this.btnPcLock = new System.Windows.Forms.Button();
            this.groupBoxDrives = new System.Windows.Forms.GroupBox();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.btnRemoveCert = new System.Windows.Forms.Button();
            this.btnPcUnlock = new System.Windows.Forms.Button();
            this.groupBoxUsbCertificates = new System.Windows.Forms.GroupBox();
            this.groupBoxServer = new System.Windows.Forms.GroupBox();
            this.buttonRevert = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.labelDbName = new System.Windows.Forms.Label();
            this.textBoxDbName = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.groupBoxAdmin = new System.Windows.Forms.GroupBox();
            this.groupBoxPcLock = new System.Windows.Forms.GroupBox();
            this.groupBoxDrives.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxUsbCertificates.SuspendLayout();
            this.groupBoxServer.SuspendLayout();
            this.groupBoxAdmin.SuspendLayout();
            this.groupBoxPcLock.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxDrives
            // 
            this.listBoxDrives.FormattingEnabled = true;
            this.listBoxDrives.Location = new System.Drawing.Point(27, 19);
            this.listBoxDrives.Name = "listBoxDrives";
            this.listBoxDrives.Size = new System.Drawing.Size(85, 108);
            this.listBoxDrives.TabIndex = 0;
            this.listBoxDrives.SelectedIndexChanged += new System.EventHandler(this.listBoxDrives_SelectedIndexChanged);
            // 
            // btnCreateCert
            // 
            this.btnCreateCert.Enabled = false;
            this.btnCreateCert.Location = new System.Drawing.Point(6, 19);
            this.btnCreateCert.Name = "btnCreateCert";
            this.btnCreateCert.Size = new System.Drawing.Size(106, 23);
            this.btnCreateCert.TabIndex = 1;
            this.btnCreateCert.Text = "Create";
            this.btnCreateCert.UseVisualStyleBackColor = true;
            this.btnCreateCert.Click += new System.EventHandler(this.btnCreateCert_Click);
            // 
            // btnPcLock
            // 
            this.btnPcLock.Location = new System.Drawing.Point(6, 19);
            this.btnPcLock.Name = "btnPcLock";
            this.btnPcLock.Size = new System.Drawing.Size(106, 23);
            this.btnPcLock.TabIndex = 2;
            this.btnPcLock.Text = "Lock";
            this.btnPcLock.UseVisualStyleBackColor = true;
            this.btnPcLock.Click += new System.EventHandler(this.btnPcLock_Click);
            // 
            // groupBoxDrives
            // 
            this.groupBoxDrives.Controls.Add(this.listBoxDrives);
            this.groupBoxDrives.Location = new System.Drawing.Point(6, 20);
            this.groupBoxDrives.Name = "groupBoxDrives";
            this.groupBoxDrives.Size = new System.Drawing.Size(138, 190);
            this.groupBoxDrives.TabIndex = 3;
            this.groupBoxDrives.TabStop = false;
            this.groupBoxDrives.Text = "Available drives";
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.btnRemoveCert);
            this.groupBoxOptions.Controls.Add(this.btnCreateCert);
            this.groupBoxOptions.Location = new System.Drawing.Point(150, 20);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(122, 190);
            this.groupBoxOptions.TabIndex = 4;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Certificate options";
            // 
            // btnRemoveCert
            // 
            this.btnRemoveCert.Enabled = false;
            this.btnRemoveCert.Location = new System.Drawing.Point(6, 48);
            this.btnRemoveCert.Name = "btnRemoveCert";
            this.btnRemoveCert.Size = new System.Drawing.Size(106, 23);
            this.btnRemoveCert.TabIndex = 3;
            this.btnRemoveCert.Text = "Remove";
            this.btnRemoveCert.UseVisualStyleBackColor = true;
            this.btnRemoveCert.Click += new System.EventHandler(this.btnRemoveCert_Click);
            // 
            // btnPcUnlock
            // 
            this.btnPcUnlock.Location = new System.Drawing.Point(6, 48);
            this.btnPcUnlock.Name = "btnPcUnlock";
            this.btnPcUnlock.Size = new System.Drawing.Size(106, 23);
            this.btnPcUnlock.TabIndex = 4;
            this.btnPcUnlock.Text = "Unlock";
            this.btnPcUnlock.UseVisualStyleBackColor = true;
            this.btnPcUnlock.Click += new System.EventHandler(this.btnPcUnlock_Click);
            // 
            // groupBoxUsbCertificates
            // 
            this.groupBoxUsbCertificates.Controls.Add(this.groupBoxDrives);
            this.groupBoxUsbCertificates.Controls.Add(this.groupBoxOptions);
            this.groupBoxUsbCertificates.Location = new System.Drawing.Point(12, 12);
            this.groupBoxUsbCertificates.Name = "groupBoxUsbCertificates";
            this.groupBoxUsbCertificates.Size = new System.Drawing.Size(283, 221);
            this.groupBoxUsbCertificates.TabIndex = 5;
            this.groupBoxUsbCertificates.TabStop = false;
            this.groupBoxUsbCertificates.Text = "USB certificates";
            // 
            // groupBoxServer
            // 
            this.groupBoxServer.Controls.Add(this.buttonRevert);
            this.groupBoxServer.Controls.Add(this.btnSave);
            this.groupBoxServer.Controls.Add(this.labelDbName);
            this.groupBoxServer.Controls.Add(this.textBoxDbName);
            this.groupBoxServer.Controls.Add(this.labelAddress);
            this.groupBoxServer.Controls.Add(this.labelPassword);
            this.groupBoxServer.Controls.Add(this.labelUsername);
            this.groupBoxServer.Controls.Add(this.textBoxAddress);
            this.groupBoxServer.Controls.Add(this.textBoxUsername);
            this.groupBoxServer.Controls.Add(this.textBoxPassword);
            this.groupBoxServer.Location = new System.Drawing.Point(6, 20);
            this.groupBoxServer.Name = "groupBoxServer";
            this.groupBoxServer.Size = new System.Drawing.Size(283, 190);
            this.groupBoxServer.TabIndex = 6;
            this.groupBoxServer.TabStop = false;
            this.groupBoxServer.Text = "Server";
            // 
            // buttonRevert
            // 
            this.buttonRevert.Location = new System.Drawing.Point(170, 145);
            this.buttonRevert.Name = "buttonRevert";
            this.buttonRevert.Size = new System.Drawing.Size(92, 23);
            this.buttonRevert.TabIndex = 28;
            this.buttonRevert.Text = "Revert changes";
            this.buttonRevert.UseVisualStyleBackColor = true;
            this.buttonRevert.Click += new System.EventHandler(this.buttonRevert_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(67, 145);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 23);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            // groupBoxAdmin
            // 
            this.groupBoxAdmin.Controls.Add(this.groupBoxPcLock);
            this.groupBoxAdmin.Controls.Add(this.groupBoxServer);
            this.groupBoxAdmin.Enabled = false;
            this.groupBoxAdmin.Location = new System.Drawing.Point(301, 12);
            this.groupBoxAdmin.Name = "groupBoxAdmin";
            this.groupBoxAdmin.Size = new System.Drawing.Size(424, 221);
            this.groupBoxAdmin.TabIndex = 7;
            this.groupBoxAdmin.TabStop = false;
            this.groupBoxAdmin.Text = "Administrative";
            // 
            // groupBoxPcLock
            // 
            this.groupBoxPcLock.Controls.Add(this.btnPcLock);
            this.groupBoxPcLock.Controls.Add(this.btnPcUnlock);
            this.groupBoxPcLock.Location = new System.Drawing.Point(295, 20);
            this.groupBoxPcLock.Name = "groupBoxPcLock";
            this.groupBoxPcLock.Size = new System.Drawing.Size(119, 190);
            this.groupBoxPcLock.TabIndex = 7;
            this.groupBoxPcLock.TabStop = false;
            this.groupBoxPcLock.Text = "PC Lock";
            // 
            // Form_certificates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 250);
            this.Controls.Add(this.groupBoxAdmin);
            this.Controls.Add(this.groupBoxUsbCertificates);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_certificates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Certificates";
            this.groupBoxDrives.ResumeLayout(false);
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxUsbCertificates.ResumeLayout(false);
            this.groupBoxServer.ResumeLayout(false);
            this.groupBoxServer.PerformLayout();
            this.groupBoxAdmin.ResumeLayout(false);
            this.groupBoxPcLock.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxDrives;
        private System.Windows.Forms.Button btnCreateCert;
        private System.Windows.Forms.Button btnPcLock;
        private System.Windows.Forms.GroupBox groupBoxDrives;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.Button btnPcUnlock;
        private System.Windows.Forms.Button btnRemoveCert;
        private System.Windows.Forms.GroupBox groupBoxUsbCertificates;
        private System.Windows.Forms.GroupBox groupBoxServer;
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
        private System.Windows.Forms.GroupBox groupBoxAdmin;
        private System.Windows.Forms.GroupBox groupBoxPcLock;
    }
}