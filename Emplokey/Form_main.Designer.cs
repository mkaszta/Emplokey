namespace Emplokey
{
    partial class Form_main
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
            this.btnInstallCert = new System.Windows.Forms.Button();
            this.labelRegisteredUser = new System.Windows.Forms.Label();
            this.labelRegisteredUserInfo = new System.Windows.Forms.Label();
            this.labelUsbCertificateInfo = new System.Windows.Forms.Label();
            this.labelUsbCertificate = new System.Windows.Forms.Label();
            this.labelAuthorizationInfo = new System.Windows.Forms.Label();
            this.labelAuthorization = new System.Windows.Forms.Label();
            this.labelCounting = new System.Windows.Forms.Label();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.labelSuInfo = new System.Windows.Forms.Label();
            this.btnPortable = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.groupBoxSettings.SuspendLayout();
            this.groupBoxStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInstallCert
            // 
            this.btnInstallCert.Location = new System.Drawing.Point(6, 35);
            this.btnInstallCert.Name = "btnInstallCert";
            this.btnInstallCert.Size = new System.Drawing.Size(99, 23);
            this.btnInstallCert.TabIndex = 0;
            this.btnInstallCert.Text = "Certificates";
            this.btnInstallCert.UseVisualStyleBackColor = true;
            this.btnInstallCert.Click += new System.EventHandler(this.btnInstallCert_Click);
            // 
            // labelRegisteredUser
            // 
            this.labelRegisteredUser.AutoSize = true;
            this.labelRegisteredUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegisteredUser.Location = new System.Drawing.Point(6, 33);
            this.labelRegisteredUser.Name = "labelRegisteredUser";
            this.labelRegisteredUser.Size = new System.Drawing.Size(123, 16);
            this.labelRegisteredUser.TabIndex = 1;
            this.labelRegisteredUser.Text = "Registered user:";
            // 
            // labelRegisteredUserInfo
            // 
            this.labelRegisteredUserInfo.AutoSize = true;
            this.labelRegisteredUserInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegisteredUserInfo.ForeColor = System.Drawing.Color.Red;
            this.labelRegisteredUserInfo.Location = new System.Drawing.Point(135, 33);
            this.labelRegisteredUserInfo.Name = "labelRegisteredUserInfo";
            this.labelRegisteredUserInfo.Size = new System.Drawing.Size(168, 16);
            this.labelRegisteredUserInfo.TabIndex = 2;
            this.labelRegisteredUserInfo.Text = "no certificate registered yet";
            // 
            // labelUsbCertificateInfo
            // 
            this.labelUsbCertificateInfo.AutoSize = true;
            this.labelUsbCertificateInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsbCertificateInfo.ForeColor = System.Drawing.Color.Red;
            this.labelUsbCertificateInfo.Location = new System.Drawing.Point(135, 49);
            this.labelUsbCertificateInfo.Name = "labelUsbCertificateInfo";
            this.labelUsbCertificateInfo.Size = new System.Drawing.Size(62, 16);
            this.labelUsbCertificateInfo.TabIndex = 4;
            this.labelUsbCertificateInfo.Text = "not found";
            // 
            // labelUsbCertificate
            // 
            this.labelUsbCertificate.AutoSize = true;
            this.labelUsbCertificate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsbCertificate.Location = new System.Drawing.Point(12, 49);
            this.labelUsbCertificate.Name = "labelUsbCertificate";
            this.labelUsbCertificate.Size = new System.Drawing.Size(117, 16);
            this.labelUsbCertificate.TabIndex = 3;
            this.labelUsbCertificate.Text = "USB Certificate:";
            // 
            // labelAuthorizationInfo
            // 
            this.labelAuthorizationInfo.AutoSize = true;
            this.labelAuthorizationInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthorizationInfo.ForeColor = System.Drawing.Color.Red;
            this.labelAuthorizationInfo.Location = new System.Drawing.Point(135, 65);
            this.labelAuthorizationInfo.Name = "labelAuthorizationInfo";
            this.labelAuthorizationInfo.Size = new System.Drawing.Size(120, 16);
            this.labelAuthorizationInfo.TabIndex = 6;
            this.labelAuthorizationInfo.Text = "user not authorized";
            // 
            // labelAuthorization
            // 
            this.labelAuthorization.AutoSize = true;
            this.labelAuthorization.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthorization.Location = new System.Drawing.Point(28, 65);
            this.labelAuthorization.Name = "labelAuthorization";
            this.labelAuthorization.Size = new System.Drawing.Size(101, 16);
            this.labelAuthorization.TabIndex = 5;
            this.labelAuthorization.Text = "Authorization:";
            // 
            // labelCounting
            // 
            this.labelCounting.AutoSize = true;
            this.labelCounting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCounting.ForeColor = System.Drawing.Color.Red;
            this.labelCounting.Location = new System.Drawing.Point(135, 81);
            this.labelCounting.Name = "labelCounting";
            this.labelCounting.Size = new System.Drawing.Size(0, 16);
            this.labelCounting.TabIndex = 7;
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.btnStatistics);
            this.groupBoxSettings.Controls.Add(this.btnPortable);
            this.groupBoxSettings.Controls.Add(this.btnInstallCert);
            this.groupBoxSettings.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(319, 86);
            this.groupBoxSettings.TabIndex = 8;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.labelRegisteredUser);
            this.groupBoxStatus.Controls.Add(this.labelRegisteredUserInfo);
            this.groupBoxStatus.Controls.Add(this.labelCounting);
            this.groupBoxStatus.Controls.Add(this.labelUsbCertificate);
            this.groupBoxStatus.Controls.Add(this.labelAuthorizationInfo);
            this.groupBoxStatus.Controls.Add(this.labelUsbCertificateInfo);
            this.groupBoxStatus.Controls.Add(this.labelAuthorization);
            this.groupBoxStatus.Location = new System.Drawing.Point(12, 104);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(319, 102);
            this.groupBoxStatus.TabIndex = 9;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "Status";
            // 
            // labelSuInfo
            // 
            this.labelSuInfo.AutoSize = true;
            this.labelSuInfo.Location = new System.Drawing.Point(269, 215);
            this.labelSuInfo.Name = "labelSuInfo";
            this.labelSuInfo.Size = new System.Drawing.Size(62, 13);
            this.labelSuInfo.TabIndex = 10;
            this.labelSuInfo.Text = "(super-user)";
            // 
            // btnPortable
            // 
            this.btnPortable.Enabled = false;
            this.btnPortable.Location = new System.Drawing.Point(109, 35);
            this.btnPortable.Name = "btnPortable";
            this.btnPortable.Size = new System.Drawing.Size(99, 23);
            this.btnPortable.TabIndex = 1;
            this.btnPortable.Text = "Portable data";
            this.btnPortable.UseVisualStyleBackColor = true;
            // 
            // btnStatistics
            // 
            this.btnStatistics.Enabled = false;
            this.btnStatistics.Location = new System.Drawing.Point(214, 35);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(99, 23);
            this.btnStatistics.TabIndex = 2;
            this.btnStatistics.Text = "Statistics";
            this.btnStatistics.UseVisualStyleBackColor = true;
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 237);
            this.ControlBox = false;
            this.Controls.Add(this.labelSuInfo);
            this.Controls.Add(this.groupBoxStatus);
            this.Controls.Add(this.groupBoxSettings);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_main";
            this.Text = "Emplokey";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_main_FormClosing);
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxStatus.ResumeLayout(false);
            this.groupBoxStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInstallCert;
        private System.Windows.Forms.Label labelRegisteredUser;
        private System.Windows.Forms.Label labelRegisteredUserInfo;
        private System.Windows.Forms.Label labelUsbCertificateInfo;
        private System.Windows.Forms.Label labelUsbCertificate;
        private System.Windows.Forms.Label labelAuthorizationInfo;
        private System.Windows.Forms.Label labelAuthorization;
        private System.Windows.Forms.Label labelCounting;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.GroupBox groupBoxStatus;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Button btnPortable;
        private System.Windows.Forms.Label labelSuInfo;
    }
}

