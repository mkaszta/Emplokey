using Dolinay;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Emplokey
{
    public partial class Form_main : Form
    {
        private DriveDetector driveDetector = null;
        public Cert masterCert = new Cert();
        public List<Cert> certList = new List<Cert>();
        public ServerInfo serverInfo = new ServerInfo() { loaded = false };
        public CertManager certMgr = new CertManager();
        public ConnManager connMgr = new ConnManager();        

        public bool pcLock = false;       
        public bool authorized = false;
        public bool connected = false;

        int sessionID = 0;
        
        public static CancellationTokenSource LockingCancellationTokenSource = new CancellationTokenSource();
        public static CancellationToken LockingCancellationToken = LockingCancellationTokenSource.Token;
        public static CancellationTokenSource ActivityCancellationTokenSource = new CancellationTokenSource();
        public static CancellationToken ActivityCancellationToken = ActivityCancellationTokenSource.Token;

        public Form_main()
        {
            InitializeComponent();
            RegisterAtStartup();

            driveDetector = new DriveDetector(this);
            driveDetector.DeviceArrived += new DriveDetectorEventHandler(OnDriveArrived);
            driveDetector.DeviceRemoved += new DriveDetectorEventHandler(OnDriveRemoved);

            this.WindowState = FormWindowState.Minimized;                                      
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            serverInfo = connMgr.LoadServerInfo();
            LoadCertificates();          

            if (!serverInfo.loaded)
            {
                MessageBox.Show("Server settings are not ready yet!\nGo to Certificates manager and create new connection.");
            }
            else
            {
                CheckStatuses();
            }

            UpdateStatuses();
        }

        private void Form_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Can't close the application.");
            e.Cancel = true;
        }        

        private void Form_main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }

        private void LoadCertificates()
        {
            var drivesList = DriveInfo.GetDrives();

            foreach (var drive in drivesList)
            {
                if ((drive.DriveType == DriveType.Removable || drive.DriveType == DriveType.Fixed) && File.Exists(drive.Name + settingsHelper.defaultCertName)
                    && !certList.Exists((x) => x.path.Contains(drive.Name)))
                    certList.Add(certMgr.LoadUsbCert(drive.Name));                
            }
            
            SetMasterCert();                        
        }

        private void SetMasterCert()
        {
            foreach (var cert in certList)
            {
                if (!masterCert.loaded)
                    masterCert = cert;
                else if (masterCert.userType == "user" && cert.userType == "admin")
                    masterCert = cert;

                if (cert.userType == "admin")
                    break;
            }
        }

        private void CheckStatuses()
        {
            Thread thread = new Thread(() =>
            {
                connected = connMgr.TryToConnect(serverInfo);
                if (connected)
                {
                    pcLock = certMgr.GetPcLockStatus(serverInfo);
                    if (pcLock)
                    {
                        authorized = certMgr.TryToAuthorize(serverInfo, masterCert);
                        if (authorized)
                        {
                            masterCert.authorized = true;

                            LockingCancellationTokenSource.Cancel();
                            sessionID = certMgr.StartSession(serverInfo, masterCert);

                            ActivityCancellationTokenSource = new CancellationTokenSource();
                            ActivityCancellationToken = ActivityCancellationTokenSource.Token;
                            Task.Factory.StartNew(() => ActivityProccess());
                        }                            
                        else
                        {
                            masterCert.authorized = false;

                            ActivityCancellationTokenSource.Cancel();

                            LockingCancellationTokenSource = new CancellationTokenSource();
                            LockingCancellationToken = LockingCancellationTokenSource.Token;
                            Task.Factory.StartNew(() => LockingProcess(), LockingCancellationToken);
                        }
                    }
                    else LockingCancellationTokenSource.Cancel();
                }
                else LockingCancellationTokenSource.Cancel();
            });

            thread.Start();
            thread.Join();
        }

        private void LockingProcess()
        {
            try
            {
                for (int i = settingsHelper.counter; i >= 0; i--)
                {
                    LockingCancellationToken.ThrowIfCancellationRequested();

                    if (labelCounting.InvokeRequired)
                        labelCounting.Invoke(new Action(() => labelCounting.Text = i.ToString() + "s. to lock!"));

                    Thread.Sleep(1000);
                }
                MessageBox.Show("LOCKED");
            }
            catch (OperationCanceledException)
            {
                labelCounting.Invoke(new Action(() => labelCounting.Text = ""));
            }
        }

        private void ActivityProccess()
        {
            while (true)
            {
                ActivityCancellationToken.ThrowIfCancellationRequested();
                connMgr.ConfirmActivity(serverInfo, certList);
                Thread.Sleep(settingsHelper.requestDelay);
            }
        }

        private void RegisterAtStartup()
        {
            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\MICROSOFT\\Windows\\CurrentVersion\\Run", true);
                regKey.SetValue("Emplokey", Application.ExecutablePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void UpdateStatuses()
        {            
            if (connected)
            {                
                labelServerInfo.Text = "connected";
                labelServerInfo.ForeColor = Color.Green;

                if (pcLock)
                {
                    labelLockInfo.Text = "active";
                    labelLockInfo.ForeColor = Color.Green;

                    if (authorized)
                    {                       
                        labelAuthorizationInfo.Text = "AUTHORIZED";
                        labelAuthorizationInfo.ForeColor = Color.Green;

                        if (masterCert.userType == "admin")
                        {
                            labelSuInfo.Text = "admin mode";
                            notifyIcon.ShowBalloonTip(3000, "Emplokey", "User is authorized\n(admin mode)", ToolTipIcon.Info);
                        }
                        else
                        {
                            labelSuInfo.Text = "user mode";
                            notifyIcon.ShowBalloonTip(3000, "Emplokey", "User is authorized\n(user mode)", ToolTipIcon.Info);
                        }
                    }
                    else
                    {
                        labelAuthorizationInfo.Text = "NOT AUTHORIZED";
                        labelAuthorizationInfo.ForeColor = Color.Red;
                        notifyIcon.ShowBalloonTip(3000, "Emplokey", "User is NOT authorized!", ToolTipIcon.Error);

                        labelSuInfo.Text = "";
                    }
                }
                else
                {
                    labelLockInfo.Text = "inactive";
                    labelLockInfo.ForeColor = Color.Gray;
                    labelAuthorizationInfo.Text = "-";
                    labelAuthorizationInfo.ForeColor = Color.Gray;
                }                
            }
            else
            {
                labelServerInfo.Text = "not connected";
                labelServerInfo.ForeColor = Color.Red;
                labelLockInfo.Text = "-";
                labelLockInfo.ForeColor = Color.Gray;
                labelAuthorizationInfo.Text = "-";
                labelAuthorizationInfo.ForeColor = Color.Gray;
                labelSuInfo.Text = "";
            }

            if (masterCert.loaded)
            {
                labelUsbCertificateInfo.Text = "found";
                labelUsbCertificateInfo.ForeColor = Color.Green;
            }
            else
            {
                labelUsbCertificateInfo.Text = "not found";
                labelUsbCertificateInfo.ForeColor = Color.Red;
            }   
        }                        

        private void btnCertMgr_Click(object sender, EventArgs e)
        {
            var form_certManager = new Form_certificates(serverInfo, connMgr, certMgr, masterCert, connected, certList);
            form_certManager.ShowDialog();

            serverInfo = connMgr.LoadServerInfo();
            LoadCertificates();

            if (serverInfo.address != null)
                CheckStatuses();
            UpdateStatuses();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void OnDriveArrived(object sender, DriveDetectorEventArgs e)
        {
            e.HookQueryRemove = false;

            LoadCertificates();            
            CheckStatuses();
            UpdateStatuses(); 
        }

        private void OnDriveRemoved(object sender, DriveDetectorEventArgs e)
        {            
            certList.RemoveAll((x) => x.path.Contains(e.Drive));

            if (masterCert.path != null && masterCert.path.Contains(e.Drive))
            {
                certMgr.EndSession(serverInfo, sessionID);
                sessionID = 0;
                masterCert.loaded = false;
            }                

            SetMasterCert();
            CheckStatuses();
            UpdateStatuses();
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
