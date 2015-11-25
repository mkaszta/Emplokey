using System;
using System.Windows.Forms;
using Dolinay;
using System.IO;
using System.Collections.Generic;


namespace Emplokey
{
    public partial class Form_certificates : Form
    {        
        private DriveDetector driveDetector = null;
        ServerInfo serverInfo = new ServerInfo();
        CertManager certMgr = new CertManager();
        ConnManager connMgr = new ConnManager();
        Cert masterCert = new Cert();
        bool connected = false;
        List<Cert> certList = new List<Cert>();

        public Form_certificates(ServerInfo _serverInfo, ConnManager _connMgr, CertManager _certMgr, Cert _masterCert, bool _connected, List<Cert> _certList)
        {
            InitializeComponent();

            serverInfo = _serverInfo;
            masterCert = _masterCert;
            certMgr = _certMgr;
            connMgr = _connMgr;
            connected = _connected;
            certList = _certList;

            driveDetector = new DriveDetector(this);
            driveDetector.DeviceArrived += new DriveDetectorEventHandler(OnDriveArrived);
            driveDetector.DeviceRemoved += new DriveDetectorEventHandler(OnDriveRemoved);

            UpdateDriveList();
            FillServerSettingsBoxes();

            if (!connected)
            {
                groupBoxAdmin.Enabled = true;
                groupBoxPcLock.Enabled = false;
            }
            else if (masterCert.userType == "admin")
            {
                groupBoxAdmin.Enabled = true;
            }
            else
            {
                groupBoxAdmin.Enabled = false;
            }
        }

        private void FillServerSettingsBoxes()
        {
            textBoxAddress.Text = serverInfo.address;
            textBoxDbName.Text = serverInfo.dbName;                     
        }

        private void UpdateDriveList()
        {
            listBoxDrives.Items.Clear();
            var drivesList = DriveInfo.GetDrives();
            foreach (var drive in drivesList)
            {
                if (drive.DriveType == DriveType.Removable || drive.DriveType == DriveType.Fixed)
                {
                    UpdateDriveList(drive.Name, true);
                }
            }
        }

        private void UpdateDriveList(string driveLetter, bool addDrive)
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
                            certMgr.CreateCert(masterCert, listBoxDrives.SelectedItem.ToString());
                            MessageBox.Show("Certificate created and saved under:\n" + masterCert.path);
                        }
                    }
                    else
                    {
                        certMgr.CreateCert(masterCert, listBoxDrives.SelectedItem.ToString());
                        MessageBox.Show("Certificate created and saved under:\n" + masterCert.path);
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
            Cert certTemp = certList.Find((x) => x.userType == "user");

            if (certTemp != null)
            {
                try
                {
                    certMgr.SetPcLockStatus(serverInfo, certTemp, 1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("User certificate not found.\nPC can be locked only for the specific user.");
            }            
        }

        private void btnPcUnlock_Click(object sender, EventArgs e)
        {
            Cert certTemp = certList.Find((x) => x.userType == "user");

            if (certTemp != null)
            {
                try
                {
                    certMgr.SetPcLockStatus(serverInfo, certTemp, 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("User certificate not found.\nPC can be unlocked only for the specific user.");
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
                serverInfo.address = textBoxAddress.Text;
                serverInfo.dbName = textBoxDbName.Text;

                connMgr.SaveServerInfo(serverInfo);
                MessageBox.Show("Server settings saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            FillServerSettingsBoxes();
        }

        private void OnDriveArrived(object sender, DriveDetectorEventArgs e)
        {
            e.HookQueryRemove = false;
            UpdateDriveList(e.Drive, true);
        }

        private void OnDriveRemoved(object sender, DriveDetectorEventArgs e)
        {
            UpdateDriveList(e.Drive, false);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (driveDetector != null)
            {
                driveDetector.WndProc(ref m);
            }
        }
    }
}
