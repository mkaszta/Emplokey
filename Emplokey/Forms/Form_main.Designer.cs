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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_main));
            this.btnCertMgr = new System.Windows.Forms.Button();
            this.labelServer = new System.Windows.Forms.Label();
            this.labelServerInfo = new System.Windows.Forms.Label();
            this.labelUsbCertificateInfo = new System.Windows.Forms.Label();
            this.labelUsbCertificate = new System.Windows.Forms.Label();
            this.labelAuthorizationInfo = new System.Windows.Forms.Label();
            this.labelAuthorization = new System.Windows.Forms.Label();
            this.labelCounting = new System.Windows.Forms.Label();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnPortable = new System.Windows.Forms.Button();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.labelSuInfo = new System.Windows.Forms.Label();
            this.labelLock = new System.Windows.Forms.Label();
            this.labelLockInfo = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBoxSettings.SuspendLayout();
            this.groupBoxStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCertMgr
            // 
            this.btnCertMgr.Location = new System.Drawing.Point(6, 35);
            this.btnCertMgr.Name = "btnCertMgr";
            this.btnCertMgr.Size = new System.Drawing.Size(99, 23);
            this.btnCertMgr.TabIndex = 0;
            this.btnCertMgr.Text = "Certificates";
            this.btnCertMgr.UseVisualStyleBackColor = true;
            this.btnCertMgr.Click += new System.EventHandler(this.btnCertMgr_Click);
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServer.Location = new System.Drawing.Point(97, 30);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(58, 16);
            this.labelServer.TabIndex = 1;
            this.labelServer.Text = "Server:";
            // 
            // labelServerInfo
            // 
            this.labelServerInfo.AutoSize = true;
            this.labelServerInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServerInfo.ForeColor = System.Drawing.Color.Red;
            this.labelServerInfo.Location = new System.Drawing.Point(161, 30);
            this.labelServerInfo.Name = "labelServerInfo";
            this.labelServerInfo.Size = new System.Drawing.Size(89, 16);
            this.labelServerInfo.TabIndex = 2;
            this.labelServerInfo.Text = "disconnected";
            // 
            // labelUsbCertificateInfo
            // 
            this.labelUsbCertificateInfo.AutoSize = true;
            this.labelUsbCertificateInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsbCertificateInfo.ForeColor = System.Drawing.Color.Red;
            this.labelUsbCertificateInfo.Location = new System.Drawing.Point(161, 62);
            this.labelUsbCertificateInfo.Name = "labelUsbCertificateInfo";
            this.labelUsbCertificateInfo.Size = new System.Drawing.Size(62, 16);
            this.labelUsbCertificateInfo.TabIndex = 4;
            this.labelUsbCertificateInfo.Text = "not found";
            // 
            // labelUsbCertificate
            // 
            this.labelUsbCertificate.AutoSize = true;
            this.labelUsbCertificate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsbCertificate.Location = new System.Drawing.Point(38, 62);
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
            this.labelAuthorizationInfo.Location = new System.Drawing.Point(161, 94);
            this.labelAuthorizationInfo.Name = "labelAuthorizationInfo";
            this.labelAuthorizationInfo.Size = new System.Drawing.Size(12, 16);
            this.labelAuthorizationInfo.TabIndex = 6;
            this.labelAuthorizationInfo.Text = "-";
            // 
            // labelAuthorization
            // 
            this.labelAuthorization.AutoSize = true;
            this.labelAuthorization.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthorization.Location = new System.Drawing.Point(54, 94);
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
            this.labelCounting.Location = new System.Drawing.Point(161, 132);
            this.labelCounting.Name = "labelCounting";
            this.labelCounting.Size = new System.Drawing.Size(0, 16);
            this.labelCounting.TabIndex = 7;
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.btnStatistics);
            this.groupBoxSettings.Controls.Add(this.btnPortable);
            this.groupBoxSettings.Controls.Add(this.btnCertMgr);
            this.groupBoxSettings.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(319, 86);
            this.groupBoxSettings.TabIndex = 8;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
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
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.labelSuInfo);
            this.groupBoxStatus.Controls.Add(this.labelLock);
            this.groupBoxStatus.Controls.Add(this.labelLockInfo);
            this.groupBoxStatus.Controls.Add(this.labelServer);
            this.groupBoxStatus.Controls.Add(this.labelServerInfo);
            this.groupBoxStatus.Controls.Add(this.labelCounting);
            this.groupBoxStatus.Controls.Add(this.labelUsbCertificate);
            this.groupBoxStatus.Controls.Add(this.labelAuthorizationInfo);
            this.groupBoxStatus.Controls.Add(this.labelUsbCertificateInfo);
            this.groupBoxStatus.Controls.Add(this.labelAuthorization);
            this.groupBoxStatus.Location = new System.Drawing.Point(12, 104);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(319, 151);
            this.groupBoxStatus.TabIndex = 9;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "Status";
            // 
            // labelSuInfo
            // 
            this.labelSuInfo.AutoSize = true;
            this.labelSuInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.labelSuInfo.Location = new System.Drawing.Point(12, 135);
            this.labelSuInfo.Name = "labelSuInfo";
            this.labelSuInfo.Size = new System.Drawing.Size(16, 13);
            this.labelSuInfo.TabIndex = 10;
            this.labelSuInfo.Text = "...";
            // 
            // labelLock
            // 
            this.labelLock.AutoSize = true;
            this.labelLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLock.Location = new System.Drawing.Point(86, 46);
            this.labelLock.Name = "labelLock";
            this.labelLock.Size = new System.Drawing.Size(69, 16);
            this.labelLock.TabIndex = 8;
            this.labelLock.Text = "PC Lock:";
            // 
            // labelLockInfo
            // 
            this.labelLockInfo.AutoSize = true;
            this.labelLockInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLockInfo.ForeColor = System.Drawing.Color.Red;
            this.labelLockInfo.Location = new System.Drawing.Point(161, 46);
            this.labelLockInfo.Name = "labelLockInfo";
            this.labelLockInfo.Size = new System.Drawing.Size(12, 16);
            this.labelLockInfo.TabIndex = 9;
            this.labelLockInfo.Text = "-";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Emplokey";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 278);
            this.Controls.Add(this.groupBoxStatus);
            this.Controls.Add(this.groupBoxSettings);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_main";
            this.Text = "Emplokey";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_main_FormClosing);
            this.Load += new System.EventHandler(this.Form_main_Load);
            this.Resize += new System.EventHandler(this.Form_main_Resize);
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxStatus.ResumeLayout(false);
            this.groupBoxStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCertMgr;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.Label labelServerInfo;
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
        private System.Windows.Forms.Label labelLock;
        private System.Windows.Forms.Label labelLockInfo;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

