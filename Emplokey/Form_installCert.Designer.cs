﻿namespace Emplokey
{
    partial class Form_installCert
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
            this.SuspendLayout();
            // 
            // listBoxDrives
            // 
            this.listBoxDrives.FormattingEnabled = true;
            this.listBoxDrives.Location = new System.Drawing.Point(12, 33);
            this.listBoxDrives.Name = "listBoxDrives";
            this.listBoxDrives.Size = new System.Drawing.Size(136, 186);
            this.listBoxDrives.TabIndex = 0;
            // 
            // btnCreateCert
            // 
            this.btnCreateCert.Location = new System.Drawing.Point(173, 33);
            this.btnCreateCert.Name = "btnCreateCert";
            this.btnCreateCert.Size = new System.Drawing.Size(124, 23);
            this.btnCreateCert.TabIndex = 1;
            this.btnCreateCert.Text = "Create certificate";
            this.btnCreateCert.UseVisualStyleBackColor = true;
            this.btnCreateCert.Click += new System.EventHandler(this.btnCreateCert_Click);
            // 
            // Form_installCert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 261);
            this.Controls.Add(this.btnCreateCert);
            this.Controls.Add(this.listBoxDrives);
            this.Name = "Form_installCert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormInstallCert";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxDrives;
        private System.Windows.Forms.Button btnCreateCert;
    }
}