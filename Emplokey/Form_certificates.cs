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
    public partial class Form_certificates : Form
    {
        private DriveDetector driveDetector = null;
        Form_main formMain = new Form_main();        
        CertManager certMgr = new CertManager();

        public string certPassword = "";
        public bool cancelPassword = false;

        public Form_certificates(Form_main _formMain)
        {
            InitializeComponent();

            driveDetector = new DriveDetector(this);
            driveDetector.DeviceArrived += new DriveDetectorEventHandler(OnDriveArrived);
            driveDetector.DeviceRemoved += new DriveDetectorEventHandler(OnDriveRemoved);

            formMain = _formMain;
            
            getDrivesList();            
        }

        public void getDrivesList()
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
                    Form_setPassword form_setPassword = new Form_setPassword(this);
                    form_setPassword.ShowDialog(this);

                    if (!cancelPassword)
                    {
                        if (File.Exists(listBoxDrives.SelectedItem + settingsHelper.defaultCertName))
                        {
                            DialogResult dialogResult = MessageBox.Show("Certificate under specified path already exists.\nDo you want to overwrite it?", "Certificate creation", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                certMgr.createCert(formMain, listBoxDrives.SelectedItem.ToString(), certPassword);
                                MessageBox.Show("Certificate created and saved under:\n" + formMain.certUSB.path);
                            }
                        }
                        else
                        {
                            certMgr.createCert(formMain, listBoxDrives.SelectedItem.ToString(), certPassword);
                            MessageBox.Show("Certificate created and saved under:\n" + formMain.certUSB.path);
                        }
                    }                                            
                }
                else MessageBox.Show("Please select a flash drive to create a certificate.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (listBoxDrives.SelectedItem == null)
                MessageBox.Show("Please select a certificate's path.");
            else if (!File.Exists(listBoxDrives.SelectedItem.ToString() + settingsHelper.defaultCertName))
                MessageBox.Show("There is no certificate installed on the selected drive!");
            else
            {
                try
                {
                    certMgr.registerCert(listBoxDrives.SelectedItem.ToString());                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }            
        }
    }
}
