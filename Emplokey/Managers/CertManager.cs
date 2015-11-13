using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Emplokey
{
    public class CertManager
    {
        public void createCert(Form_main formMain, string path)
        {
            formMain.certUSB.user = WindowsIdentity.GetCurrent().Name;
            formMain.certUSB.pcName = SystemInformation.ComputerName;
            formMain.certUSB.path = path + settingsHelper.defaultCertName;

            XDocument xCert = new XDocument(
                new XDeclaration("1.0", "UTF-16", null),
                new XElement(settingsHelper.xNameSpace + "EmplokeyCert",
                    new XElement("User", formMain.certUSB.user),
                    new XElement("PcName", formMain.certUSB.pcName),
                    new XElement("UserType", "user"),
                    new XElement("AuthKey", formMain.certUSB.HashedAuthKey)                    
                    ));

            xCert.Save(formMain.certUSB.path);
        }

        public void setPcLockStatus(ServerInfo serverInfo, Cert certificate, int lockPc)
        {
            string connString = String.Format(settingsHelper.connectionString, serverInfo.address);
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            DataClassesDataContext database = new DataClassesDataContext();
            
            try
            {
                var queryUser = from u in database.Users
                                where u.Username == certificate.user
                                select u;

                if (queryUser.Count() == 0)
                {
                    User newUser = new User
                    {
                        Username = certificate.user,
                        Type = "user"                        
                    };

                    database.Users.InsertOnSubmit(newUser);
                }

                var queryPC = from u in database.Computers
                                where u.PC_name == Environment.MachineName
                                select u;

                if (queryPC.Count() == 0)
                {
                    Computer newPC = new Computer
                    {
                        PC_name = certificate.pcName,
                        Lock_status = lockPc
                    };                  

                    database.Computers.InsertOnSubmit(newPC);
                    MessageBox.Show("This PC is now LOCKED.");
                }
                else
                {
                    queryPC.First().Lock_status = lockPc;
                    if (lockPc == 1)
                        MessageBox.Show("This PC is now LOCKED.");
                    else MessageBox.Show("This PC is now UNLOCKED.");
                }                

                var queryAuth = from u in database.Auths
                                where u.ID_pc == queryPC.First().ID && u.ID_user == queryUser.First().ID
                                select u;

                if (queryAuth.Count() == 0)
                {
                    Auth newAuth = new Auth
                    {
                        ID_pc = queryPC.First().ID,
                        ID_user = queryUser.First().ID,
                        Auth_key = certificate.HashedAuthKey,
                        Device = certificate.deviceId                        
                    };

                    database.Auths.InsertOnSubmit(newAuth);                                                                            
                }
                else if (lockPc == 0)
                {
                    database.Auths.DeleteOnSubmit(queryAuth.First());
                }

                database.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        public void getUserType(Form_main formMain, ServerInfo serverInfo)
        {
            string connString = String.Format(settingsHelper.connectionString, serverInfo.address);
            SqlConnection connection = new SqlConnection(connString);
            DataClassesDataContext database = new DataClassesDataContext();

            try
            {
                connection.Open();

                var queryUser = from u in database.Users
                                where u.Username == formMain.certUSB.user
                                select u;

                if (queryUser.Any())
                {
                    if (queryUser.First().Type == "admin")
                        formMain.superUser = true;
                    else
                        formMain.superUser = false;
                }
                else
                {                    
                    formMain.superUser = false;
                }                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool getPcLockStatus(Form_main formMain, ServerInfo serverInfo)
        {
            string connString = String.Format(settingsHelper.connectionString, serverInfo.address);
            SqlConnection connection = new SqlConnection(connString);
            DataClassesDataContext database = new DataClassesDataContext();

            try
            {
                connection.Open();

                var queryPc = from c in database.Computers
                              where c.PC_name == Environment.MachineName
                              select c.Lock_status;

                if (queryPc.Count() > 0)
                {
                    if (queryPc.First() == 1)
                        return true;
                    else return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool tryToAuthorize(Form_main formMain, ServerInfo serverInfo)
        {
            string connString = String.Format(settingsHelper.connectionString, serverInfo.address);
            SqlConnection connection = new SqlConnection(connString);
            DataClassesDataContext database = new DataClassesDataContext();

            try
            {
                connection.Open();            

                if (formMain.superUser)
                {
                    formMain.superUser = true;
                    var queryAuth = from a in database.Auths
                                join u in database.Users on a.ID_user equals u.ID
                                join c in database.Computers on a.ID_pc equals c.ID
                                where u.Username == formMain.certUSB.user && a.Device == formMain.certUSB.deviceId
                                select new
                                {
                                    u.Type,
                                    a.Auth_key
                                };

                    if (!queryAuth.Any())
                        return false;
                    else if (queryAuth.First().Auth_key == formMain.certUSB.HashedAuthKey)
                        return true;                    
                    else
                        return false;                    
                }
                else
                {
                    formMain.superUser = false;
                    var queryAuth = from a in database.Auths
                                join u in database.Users on a.ID_user equals u.ID
                                join c in database.Computers on a.ID_pc equals c.ID
                                where u.Username == formMain.certUSB.user && c.PC_name == formMain.certUSB.pcName
                                select new
                                {
                                    u.Type,
                                    a.Auth_key
                                };

                    if (queryAuth.Count() == 0)
                        return false;
                    else if (queryAuth.First().Auth_key == formMain.certUSB.HashedAuthKey)
                        return true;
                    else
                        return false;
                }
                                      
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                        
            return false;
        }
        
        public Cert getUsbCert()
        {
            var newCert = new Cert();
            var drivesList = DriveInfo.GetDrives();
            foreach (var drive in drivesList)
            {
                if ((File.Exists(drive + settingsHelper.defaultCertName)) && (newCert.userType == null || newCert.userType == "user"))
                {
                    XDocument xCertUsb = XDocument.Load(drive + settingsHelper.defaultCertName);

                    newCert.user = xCertUsb.Descendants("User").Single().Value;
                    newCert.pcName = xCertUsb.Descendants("PcName").Single().Value;
                    newCert.userType = xCertUsb.Descendants("UserType").Single().Value;
                    newCert.path = drive + settingsHelper.defaultCertName;
                    newCert.loaded = true;                    
                }
                if (newCert.userType == "admin")
                    break;
            }
                        
            return newCert;
        }

        public Cert getUsbCert(string drive)
        {
            var newCert = new Cert();

            if (File.Exists(drive + settingsHelper.defaultCertName))
            {
                XDocument xCertUsb = XDocument.Load(drive + settingsHelper.defaultCertName);

                newCert.user = xCertUsb.Descendants("User").Single().Value;
                newCert.pcName = xCertUsb.Descendants("PcName").Single().Value;
                newCert.userType = xCertUsb.Descendants("UserType").Single().Value;
                newCert.path = drive + settingsHelper.defaultCertName;
                newCert.loaded = true;                
            }

            return newCert;
        }
    }
}
