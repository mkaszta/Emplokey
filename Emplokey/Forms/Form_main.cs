﻿using Dolinay;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            driveDetector = new DriveDetector(this);
            driveDetector.DeviceArrived += new DriveDetectorEventHandler(OnDriveArrived);
            driveDetector.DeviceRemoved += new DriveDetectorEventHandler(OnDriveRemoved);                                         
        }        

        private void checkForAuthorization()
        {                        
            connected = connMgr.tryToConnect(serverInfo);
            if (connected)
            {
                pcLock = certMgr.getPcLockStatus(this);
                if (pcLock)
                {
                    authorized = certMgr.tryToAuthorize(this);
                    if (authorized)
                        cancellationTokenSource.Cancel();
                    else
                    {
                        cancellationTokenSource = new CancellationTokenSource();
                        cancellationToken = cancellationTokenSource.Token;
                        Task.Factory.StartNew(() => lockingProcess(), cancellationToken);
                    }
                }
                else cancellationTokenSource.Cancel();
            }
            else cancellationTokenSource.Cancel();                    
        }

        private void updateStatuses()
        {
            certMgr.getUserType(this);            

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
        }

        private void btnCertMgr_Click(object sender, EventArgs e)
        {
            var form_certManager = new Form_certificates(this);
            form_certManager.ShowDialog();

            connMgr.getServerSettings(this);
            certUSB = certMgr.getUsbCert();
            checkForAuthorization();
            updateStatuses();
        }

        private void OnDriveArrived(object sender, DriveDetectorEventArgs e)
        {                        
            e.HookQueryRemove = false;

            if (!authorized)
            {
                certUSB = certMgr.getUsbCert();

                if (serverInfo.address != null)
                {
                    checkForAuthorization();                    
                    updateStatuses();
                }                                 
            }
            else
            {
                var tempUsbCert = certMgr.getUsbCert(e.Drive);
                if (tempUsbCert.userType == "admin" && certUSB.userType != "admin")
                {
                    certUSB = tempUsbCert;
                    checkForAuthorization();
                    if (!authorized)
                    {
                        certUSB = certMgr.getUsbCert();
                        checkForAuthorization();
                    }                                  
                    updateStatuses();
                }
            }             
        }

        private void OnDriveRemoved(object sender, DriveDetectorEventArgs e)
        {
            certUSB = certMgr.getUsbCert();

            if (connected && certUSB.path != null && certUSB.path.Contains(e.Drive))            
                checkForAuthorization();                            

            updateStatuses();
        }        

        private void lockingProcess()
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

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (driveDetector != null)
            {
                driveDetector.WndProc(ref m);
            }
        }

        private void Form_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Can't close the application.");
            e.Cancel = true;
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            connMgr.getServerSettings(this);
            certUSB = certMgr.getUsbCert();

            if (serverInfo.address == null)
            {
                MessageBox.Show("Server settings are not ready yet!\nGo to Certificates manager and create new connection.");
            }
            else
            {
                checkForAuthorization();
            }

            updateStatuses();
        }
    }
}
