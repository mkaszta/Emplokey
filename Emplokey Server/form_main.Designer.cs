namespace Emplokey_Server
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
            this.groupBoxDatabase = new System.Windows.Forms.GroupBox();
            this.labelIP = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.groupBoxDatabase.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDatabase
            // 
            this.groupBoxDatabase.Controls.Add(this.btnCreate);
            this.groupBoxDatabase.Controls.Add(this.labelIP);
            this.groupBoxDatabase.Controls.Add(this.textBox1);
            this.groupBoxDatabase.Controls.Add(this.btnDisconnect);
            this.groupBoxDatabase.Controls.Add(this.btnConnect);
            this.groupBoxDatabase.Controls.Add(this.btnRefresh);
            this.groupBoxDatabase.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDatabase.Name = "groupBoxDatabase";
            this.groupBoxDatabase.Size = new System.Drawing.Size(256, 168);
            this.groupBoxDatabase.TabIndex = 0;
            this.groupBoxDatabase.TabStop = false;
            this.groupBoxDatabase.Text = "Database";
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(7, 35);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(60, 13);
            this.labelIP.TabIndex = 7;
            this.labelIP.Text = "IP address:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(235, 20);
            this.textBox1.TabIndex = 6;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(89, 77);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 4;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(8, 77);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Location = new System.Drawing.Point(170, 77);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Location = new System.Drawing.Point(277, 12);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(256, 117);
            this.groupBoxStatus.TabIndex = 8;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "Status";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(10, 106);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "Create DB";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 318);
            this.Controls.Add(this.groupBoxStatus);
            this.Controls.Add(this.groupBoxDatabase);
            this.Name = "Form_main";
            this.Text = "Emplokey (Server)";
            this.groupBoxDatabase.ResumeLayout(false);
            this.groupBoxDatabase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDatabase;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBoxStatus;
        private System.Windows.Forms.Button btnCreate;
    }
}

