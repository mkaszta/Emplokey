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
            this.SuspendLayout();
            // 
            // btnInstallCert
            // 
            this.btnInstallCert.Location = new System.Drawing.Point(215, 161);
            this.btnInstallCert.Name = "btnInstallCert";
            this.btnInstallCert.Size = new System.Drawing.Size(75, 23);
            this.btnInstallCert.TabIndex = 0;
            this.btnInstallCert.Text = "Install cert";
            this.btnInstallCert.UseVisualStyleBackColor = true;
            this.btnInstallCert.Click += new System.EventHandler(this.btnInstallCert_Click);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 196);
            this.Controls.Add(this.btnInstallCert);
            this.Name = "Form_main";
            this.Text = "Emplokey";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInstallCert;
    }
}

