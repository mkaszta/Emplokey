using Dolinay;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Emplokey
{
    public partial class Form_main : Form
    {
        private DriveDetector driveDetector = null;        
        public Cert certUSB = new Cert() { loaded = false };
        public CertManager certMgr = new CertManager();
        public ConnManager connMgr = new ConnManager();
        public ServerInfo serverInfo = new ServerInfo();

        public bool pcLock = false;       
        public bool authorized = false;
        public bool connected = false;
        public bool superUser = false;
        
        public static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public static CancellationToken cancellationToken = cancellationTokenSource.Token;

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
            certUSB = certMgr.GetUsbCert();

            if (serverInfo.address == null)
            {
                MessageBox.Show("Server settings are not ready yet!\nGo to Certificates manager and create new connection.");
            }
            else
            {
                CheckIfAuthorized();
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

        private void CheckIfAuthorized()
        {                        
            connected = connMgr.TryToConnect(serverInfo);
            if (connected)
            {
                pcLock = certMgr.GetPcLockStatus(serverInfo);
                if (pcLock)
                {
                    authorized = certMgr.TryToAuthorize(serverInfo, certUSB, superUser);
                    if (authorized)
                        cancellationTokenSource.Cancel();
                    else
                    {
                        cancellationTokenSource = new CancellationTokenSource();
                        cancellationToken = cancellationTokenSource.Token;
                        Task.Factory.StartNew(() => LockingProcess(), cancellationToken);
                    }
                }
                else cancellationTokenSource.Cancel();
            }
            else cancellationTokenSource.Cancel();                    
        }

        private void LockingProcess()
        {
            try
            {
                for (int i = settingsHelper.counter; i >= 0; i--)
                {
                    cancellationToken.ThrowIfCancellationRequested();

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
                        superUser = certMgr.GetUserType(certUSB, serverInfo);

                        labelAuthorizationInfo.Text = "AUTHORIZED";
                        labelAuthorizationInfo.ForeColor = Color.Green;

                        if (superUser)
                        {
                            labelSuInfo.Text = "admin mode";
                        }
                        else
                        {
                            labelSuInfo.Text = "user mode";
                        }
                    }
                    else
                    {
                        labelAuthorizationInfo.Text = "NOT AUTHORIZED";
                        labelAuthorizationInfo.ForeColor = Color.Red;

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

            if (certUSB.loaded)
            {
                labelUsbCertificateInfo.Text = "found";
                labelUsbCertificateInfo.ForeColor = Color.Green;
            }
            else
            {
                labelUsbCertificateInfo.Text = "not found";
                labelUsbCertificateInfo.ForeColor = Color.Red;
            }

            // baloon notification
            if (authorized)
            {
                if (superUser)
                    notifyIcon.ShowBalloonTip(3000, "Emplokey", "User is authorized\n(admin mode)", ToolTipIcon.Info);
                else
                    notifyIcon.ShowBalloonTip(3000, "Emplokey", "User is authorized\n(user mode)", ToolTipIcon.Info);
            }                
            else
                notifyIcon.ShowBalloonTip(3000, "Emplokey", "User is NOT authorized!", ToolTipIcon.Error);
        }                        

        private void btnCertMgr_Click(object sender, EventArgs e)
        {
            var form_certManager = new Form_certificates(this);
            form_certManager.ShowDialog();

            serverInfo = connMgr.LoadServerInfo();
            certUSB = certMgr.GetUsbCert();
            if (serverInfo.address != null)
                CheckIfAuthorized();
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

            if (!authorized)
            {
                certUSB = certMgr.GetUsbCert();
                if (certUSB.userType == "admin")
                    superUser = true;
                else superUser = false;

                if (serverInfo.address != null)
                {
                    CheckIfAuthorized();
                    UpdateStatuses();
                }
            }
            else
            {
                var tempUsbCert = certMgr.GetUsbCert(e.Drive);
                if (tempUsbCert.userType == "admin")
                    superUser = true;
                else superUser = false;

                if (tempUsbCert.userType == "admin" && certUSB.userType != "admin")
                {
                    certUSB = tempUsbCert;
                    CheckIfAuthorized();
                    if (!authorized)
                    {
                        certUSB = certMgr.GetUsbCert();
                        if (certUSB.userType == "admin")
                            superUser = true;
                        else superUser = false;

                        CheckIfAuthorized();
                    }
                    UpdateStatuses();
                }
            }
        }

        private void OnDriveRemoved(object sender, DriveDetectorEventArgs e)
        {
            if (connected && certUSB.path != null && certUSB.path.Contains(e.Drive))
            {
                certUSB = certMgr.GetUsbCert();
                if (certUSB.userType == "admin")
                    superUser = true;
                else superUser = false;

                CheckIfAuthorized();
            }

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
