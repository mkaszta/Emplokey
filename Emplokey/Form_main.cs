using System;
using System.Drawing;
using System.Windows.Forms;
using Dolinay;
using System.Threading;
using System.Threading.Tasks;

namespace Emplokey
{
    public partial class Form_main : Form
    {
        private DriveDetector driveDetector = null;
        public Cert certLocal = new Cert() { loaded = false };
        public Cert certUSB = new Cert() { loaded = false };
        public CertManager certMgr = new CertManager();        
        public bool authorized = false;

        Task taskLocking = null;
        public static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public static CancellationToken cancellationToken = cancellationTokenSource.Token;

        public Form_main()
        {
            InitializeComponent();

            driveDetector = new DriveDetector(this);
            driveDetector.DeviceArrived += new DriveDetectorEventHandler(OnDriveArrived);
            driveDetector.DeviceRemoved += new DriveDetectorEventHandler(OnDriveRemoved);

            checkForAuthorization();        
        }

        private void checkForAuthorization()
        {
            certMgr.getLocalCert(this);
            certMgr.getUsbCert(this);

            if (certLocal.loaded)
            {
                labelRegisteredUserInfo.Text = "certificate registered";
                labelRegisteredUserInfo.ForeColor = Color.Green;
            }
            else
            {
                labelRegisteredUserInfo.Text = "no certificate registered yet";
                labelRegisteredUserInfo.ForeColor = Color.Red;
                authorized = false;
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
                authorized = false;
            }

            if (certLocal.loaded && certUSB.loaded)
                authorized = certMgr.compareCerts(this);

            if (authorized)
            {
                labelAuthorizationInfo.Text = "user authorized";
                labelAuthorizationInfo.ForeColor = Color.Green;
            }
            else
            {
                labelAuthorizationInfo.Text = "user not authorized";
                labelAuthorizationInfo.ForeColor = Color.Red;
                Task.Factory.StartNew(() => lockingProcess(), cancellationToken);
            }                
        }

        private void btnInstallCert_Click(object sender, EventArgs e)
        {
            var form_certManager = new Form_certManager(this);
            form_certManager.ShowDialog();
            checkForAuthorization();
        }

        private void OnDriveArrived(object sender, DriveDetectorEventArgs e)
        {
            
            cancellationTokenSource.Cancel();
            e.HookQueryRemove = false;
            if (!authorized)
                checkForAuthorization();
        }

        private void OnDriveRemoved(object sender, DriveDetectorEventArgs e)
        {
            if (certUSB.path != null && certUSB.path.Contains(e.Drive))
                checkForAuthorization();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            checkForAuthorization();
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
    }
}
