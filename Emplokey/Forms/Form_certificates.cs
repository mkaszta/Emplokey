using System;
using System.Windows.Forms;
using Dolinay;
using System.IO;

namespace Emplokey
{
    public partial class Form_certificates : Form
    {
        private DriveDetector driveDetector = null;
        Form_main formMain = new Form_main();                

        public Form_certificates(Form_main formMain)
        {
            InitializeComponent();            

            driveDetector = new DriveDetector(this);
            driveDetector.DeviceArrived += new DriveDetectorEventHandler(OnDriveArrived);
            driveDetector.DeviceRemoved += new DriveDetectorEventHandler(OnDriveRemoved);
            
            getDrivesList();
            fillServerSettingsBoxes();

            if (!formMain.connected)
            {
                groupBoxAdmin.Enabled = true;
                groupBoxPcLock.Enabled = false;
            }
            else if (formMain.superUser)
                groupBoxAdmin.Enabled = true;
            else groupBoxAdmin.Enabled = false;
        }

        private void fillServerSettingsBoxes()
        {
            textBoxAddress.Text = formMain.serverInfo.address;
            textBoxDbName.Text = formMain.serverInfo.dbName;                     
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
                    
                    if (File.Exists(listBoxDrives.SelectedItem + settingsHelper.defaultCertName))
                    {
                        DialogResult dialogResult = MessageBox.Show("Certificate under specified path already exists.\nDo you want to overwrite it?", "Certificate creation", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            formMain.certMgr.createCert(formMain, listBoxDrives.SelectedItem.ToString());
                            MessageBox.Show("Certificate created and saved under:\n" + formMain.certUSB.path);
                        }
                    }
                    else
                    {
                        formMain.certMgr.createCert(formMain, listBoxDrives.SelectedItem.ToString());
                        MessageBox.Show("Certificate created and saved under:\n" + formMain.certUSB.path);
                    }                                                              
                }
                else MessageBox.Show("Please select a flash drive to create a certificate.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            listBoxDrives_SelectedIndexChanged(this, null);
        }

        private void btnPcLock_Click(object sender, EventArgs e)
        {            
            try
            {
                formMain.certMgr.setPcLockStatus(formMain.serverInfo, formMain.certUSB, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }                    
        }

        private void btnPcUnlock_Click(object sender, EventArgs e)
        {
            try
            {
                formMain.certMgr.setPcLockStatus(formMain.serverInfo, formMain.certUSB, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            foreach (var control in groupBoxServer.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    if (((TextBox)control).Text == "")
                    {
                        MessageBox.Show("Please fill in all needed data.");
                        return;
                    }                        
                }
            }

            try
            {
                formMain.serverInfo.address = textBoxAddress.Text;
                formMain.serverInfo.dbName = textBoxDbName.Text;

                formMain.connMgr.saveSettings(formMain.serverInfo);
                MessageBox.Show("Server settings saved.");
            }            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonRevert_Click(object sender, EventArgs e)
        {
            fillServerSettingsBoxes();
        }

        private void listBoxDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (File.Exists(listBoxDrives.SelectedItem + settingsHelper.defaultCertName))
            {
                btnCreateCert.Enabled = false;
                btnRemoveCert.Enabled = true;
            }
            else
            {
                btnCreateCert.Enabled = true;
                btnRemoveCert.Enabled = false;
            }
        }

        private void btnRemoveCert_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(listBoxDrives.SelectedItem + settingsHelper.defaultCertName);
                MessageBox.Show("Certificate removed from the " + listBoxDrives.SelectedItem + " drive");
                listBoxDrives_SelectedIndexChanged(this, null);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }        
    }
}
