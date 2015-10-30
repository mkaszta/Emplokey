using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dolinay;
using System.IO;

namespace Emplokey
{
    public partial class Form_installCert : Form
    {
        private DriveDetector driveDetector = null;        

        public Form_installCert()
        {
            InitializeComponent();

            driveDetector = new DriveDetector(this);
            driveDetector.DeviceArrived += new DriveDetectorEventHandler(OnDriveArrived);
            driveDetector.DeviceRemoved += new DriveDetectorEventHandler(OnDriveRemoved);

            getDrivesList();            
        }

        private void getDrivesList()
        {
            listBoxDrives.Items.Clear();
            var drivesList = DriveInfo.GetDrives();
            foreach (var drive in drivesList)
            {
                if (drive.DriveType == DriveType.Removable || drive.DriveType == DriveType.Fixed)
                {
                    updateDriveList(drive.Name, true);
                }
            }
        }

        private void updateDriveList(string driveLetter, bool addDrive)
        {
            if (addDrive)
                listBoxDrives.Items.Add(driveLetter);
            else
            {
                for (int i = 0; i < listBoxDrives.Items.Count; i++)
                {
                    if (listBoxDrives.Items[i].ToString().Contains(driveLetter))
                    {
                        listBoxDrives.Items.RemoveAt(i);
                        break;
                    }                       
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (driveDetector != null)
            {
                driveDetector.WndProc(ref m);
            }
        }

        private void OnDriveArrived(object sender, DriveDetectorEventArgs e)
        {
            e.HookQueryRemove = false;
            updateDriveList(e.Drive, true);
        }

        private void OnDriveRemoved(object sender, DriveDetectorEventArgs e)
        {
            updateDriveList(e.Drive, false);
        }

        private void btnCreateCert_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxDrives.SelectedIndex != -1)
                {
                    var cert = new Cert() { user = "mkaszta", password = "pass", path = listBoxDrives.SelectedItem.ToString() };                    

                    if (File.Exists(cert.path + settingsHelper.defaultCertName))
                    {
                        DialogResult dialogResult = MessageBox.Show("Certificate under specified path already exists.\nDo you want to overwrite it?", "Certificate creation", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {                            
                            var certMgr = new CertManager();                            
                            certMgr.createCert(cert);
                            MessageBox.Show("Certificate created and saved under:\n" + cert.path + settingsHelper.defaultCertName);
                        }
                    } else
                    {                        
                        var certMgr = new CertManager();
                        certMgr.createCert(cert);
                        MessageBox.Show("Certificate created and saved under:\n" + cert.path + settingsHelper.defaultCertName);
                    }                   
                }
                else MessageBox.Show("Please select a flash drive to create a certificate.");
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
