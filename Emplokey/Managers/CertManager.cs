using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;

namespace Emplokey
{
    public class CertManager
    {
        public void createCert(Form_main formMain, string path, string password)
        {
            formMain.certUSB.user = WindowsIdentity.GetCurrent().Name;
            formMain.certUSB.password = password;
            formMain.certUSB.path = path + settingsHelper.defaultCertName;

            XDocument xCert = new XDocument(
                new XDeclaration("1.0", "UTF-16", null),
                new XElement(settingsHelper.xNameSpace + "EmplokeyCert",
                    new XElement("User", formMain.certUSB.user),
                    new XElement("Password", formMain.certUSB.hashedPassword)                    
                    ));

            xCert.Save(formMain.certUSB.path);
        }

        public void registerCert(string certPath)
        {
            if (!Directory.Exists(settingsHelper.userPath))
                Directory.CreateDirectory(settingsHelper.userPath);
            
            if (!File.Exists(settingsHelper.userPath + settingsHelper.defaultCertName))
            {
                File.Copy(certPath + settingsHelper.defaultCertName, settingsHelper.userPath + settingsHelper.defaultCertName, false);
                MessageBox.Show("Certificate registered!");
            }            
            else
            {   
                DialogResult dialogResult = MessageBox.Show("There is one certificate already registered.\nDO you want to replace it?", "Certificate warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    File.Copy(certPath + settingsHelper.defaultCertName, settingsHelper.userPath + settingsHelper.defaultCertName, true);
                    MessageBox.Show("Certificate registered!");
                }                    
            }
        }

        public bool compareCerts(Form_main formMain)
        {
            if (formMain.certLocal.user == formMain.certUSB.user && formMain.certLocal.password == formMain.certUSB.password)
                return true;
            else return false;                            
        }        
        
        public void getLocalCert(Form_main formMain)
        {
            if (File.Exists(settingsHelper.userPath + settingsHelper.defaultCertName))
            {
                XDocument xCertLocal = XDocument.Load(settingsHelper.userPath + settingsHelper.defaultCertName);

                formMain.certLocal.user = xCertLocal.Descendants("User").Single().Value;
                formMain.certLocal.password = xCertLocal.Descendants("Password").Single().Value;
                formMain.certLocal.path = settingsHelper.userPath + settingsHelper.defaultCertName;
                formMain.certLocal.loaded = true;
            }
            else formMain.certLocal.loaded = false;          
        }   
        
        public void getUsbCert(Form_main formMain)
        {
            var drivesList = DriveInfo.GetDrives();
            foreach (var drive in drivesList)
            {
                if (File.Exists(drive + settingsHelper.defaultCertName))
                {
                    XDocument xCertUsb = XDocument.Load(drive + settingsHelper.defaultCertName);

                    formMain.certUSB.user = xCertUsb.Descendants("User").Single().Value;
                    formMain.certUSB.password = xCertUsb.Descendants("Password").Single().Value;
                    formMain.certUSB.path = drive + settingsHelper.defaultCertName;
                    formMain.certUSB.loaded = true;

                    break;
                }
                else formMain.certUSB.loaded = false;                             
            }                   
        }
    }
}
