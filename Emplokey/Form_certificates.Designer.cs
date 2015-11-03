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
            this.btnRemove = new System.Windows.Forms.Button();
            this.buttonDeregister = new System.Windows.Forms.Button();
            this.groupBoxDrives.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
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
            this.btnRegister.Location = new System.Drawing.Point(118, 19);
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
            this.groupBoxDrives.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDrives.Name = "groupBoxDrives";
            this.groupBoxDrives.Size = new System.Drawing.Size(138, 143);
            this.groupBoxDrives.TabIndex = 3;
            this.groupBoxDrives.TabStop = false;
            this.groupBoxDrives.Text = "Removable drives";
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.buttonDeregister);
            this.groupBoxOptions.Controls.Add(this.btnRemove);
            this.groupBoxOptions.Controls.Add(this.btnCreateCert);
            this.groupBoxOptions.Controls.Add(this.btnRegister);
            this.groupBoxOptions.Location = new System.Drawing.Point(156, 12);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(233, 143);
            this.groupBoxOptions.TabIndex = 4;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Certificate options";
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
            // buttonDeregister
            // 
            this.buttonDeregister.Enabled = false;
            this.buttonDeregister.Location = new System.Drawing.Point(118, 48);
            this.buttonDeregister.Name = "buttonDeregister";
            this.buttonDeregister.Size = new System.Drawing.Size(106, 23);
            this.buttonDeregister.TabIndex = 4;
            this.buttonDeregister.Text = "Deregister";
            this.buttonDeregister.UseVisualStyleBackColor = true;
            // 
            // Form_certManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 179);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.groupBoxDrives);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_certManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Certificates manager";
            this.groupBoxDrives.ResumeLayout(false);
            this.groupBoxOptions.ResumeLayout(false);
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
    }
}