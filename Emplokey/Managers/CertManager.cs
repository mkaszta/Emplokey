using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Emplokey
{
    public class CertManager
    {
        public Cert LoadUsbCert(List<Cert> certList, string drive)
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

        public void CreateCert(Cert cert, string path)
        {
            cert.user = WindowsIdentity.GetCurrent().Name;
            cert.pcName = SystemInformation.ComputerName;
            cert.path = path + settingsHelper.defaultCertName;

            XDocument xCert = new XDocument(
                new XDeclaration("1.0", "UTF-16", null),
                new XElement(settingsHelper.xNameSpace + "EmplokeyCert",
                    new XElement("User", cert.user),
                    new XElement("PcName", cert.pcName),
                    new XElement("UserType", "user"),
                    new XElement("AuthKey", cert.HashedAuthKey)                    
                    ));

            xCert.Save(cert.path);
        }

        public void SetPcLockStatus(ServerInfo serverInfo, Cert cert, int lockPc)
        {
            string connString = String.Format(settingsHelper.connectionString, serverInfo.address);
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            DataClassesDataContext database = new DataClassesDataContext();
            
            try
            {
                var queryUser = from u in database.Users
                                where u.Username == cert.user
                                select u;

                if (queryUser.Count() == 0)
                {
                    User newUser = new User
                    {
                        Username = cert.user,
                        Type = "user"                        
                    };

                    database.Users.InsertOnSubmit(newUser);
                    database.SubmitChanges();
                }

                var queryPC = from u in database.Computers
                                where u.PC_name == Environment.MachineName
                                select u;

                if (queryPC.Count() == 0)
                {
                    Computer newPC = new Computer
                    {
                        PC_name = cert.pcName,
                        Lock_status = lockPc
                    };                  

                    database.Computers.InsertOnSubmit(newPC);
                    database.SubmitChanges();
                    MessageBox.Show("This PC is now LOCKED.");
                }
                else
                {
                    queryPC.First().Lock_status = lockPc;
                    database.SubmitChanges();
                    if (lockPc == 1)                                            
                        MessageBox.Show("This PC is now LOCKED.");                                                                
                    else MessageBox.Show("This PC is now UNLOCKED.");                                                             
                }

                queryUser = from u in database.Users
                                where u.Username == cert.user
                                select u;

                queryPC = from u in database.Computers
                              where u.PC_name == Environment.MachineName
                              select u;

                var queryAuth = from a in database.Auths
                                where a.ID_user == queryUser.First().ID && a.ID_pc == queryPC.First().ID
                                select a;

                if (queryAuth.Count() == 0)
                {
                    Auth newAuth = new Auth
                    {
                        ID_pc = queryPC.First().ID,
                        ID_user = queryUser.First().ID,
                        Auth_key = cert.HashedAuthKey,
                        Device = cert.deviceId                        
                    };

                    database.Auths.InsertOnSubmit(newAuth);
                    database.SubmitChanges();
                }
                else if (lockPc == 0)
                {
                    database.Auths.DeleteOnSubmit(queryAuth.First());
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        public bool GetPcLockStatus(ServerInfo serverInfo)
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

        //public bool GetUserType(Cert cert, ServerInfo serverInfo)
        //{
        //    string connString = String.Format(settingsHelper.connectionString, serverInfo.address);
        //    SqlConnection connection = new SqlConnection(connString);
        //    DataClassesDataContext database = new DataClassesDataContext();

        //    try
        //    {
        //        connection.Open();

        //        var queryUser = from u in database.Users
        //                        where u.Username == cert.user
        //                        select u;

        //        if (queryUser.Any())
        //        {
        //            if (queryUser.First().Type == "admin")
        //                return true;
        //            else
        //                return false;
        //        }
        //        else
        //        {
        //            return false;
        //        }                    
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}        

        public bool TryToAuthorize(ServerInfo serverInfo, Cert cert)
        {
            string connString = String.Format(settingsHelper.connectionString, serverInfo.address);
            SqlConnection connection = new SqlConnection(connString);
            DataClassesDataContext database = new DataClassesDataContext();

            try
            {
                connection.Open();            

                if (cert.userType == "admin")
                {                    
                    var queryAuth = from a in database.Auths
                                join u in database.Users on a.ID_user equals u.ID
                                join c in database.Computers on a.ID_pc equals c.ID
                                where u.Username == cert.user && a.Device == cert.deviceId
                                select new
                                {
                                    u.Type,
                                    a.Auth_key
                                };

                    if (!queryAuth.Any())
                        return false;
                    else if (queryAuth.First().Auth_key == cert.HashedAuthKey)
                        return true;                    
                    else
                        return false;                    
                }
                else
                {                    
                    var queryAuth = from a in database.Auths
                                join u in database.Users on a.ID_user equals u.ID
                                join c in database.Computers on a.ID_pc equals c.ID
                                where u.Username == cert.user && c.PC_name == cert.pcName
                                select new
                                {
                                    u.Type,
                                    a.Auth_key
                                };

                    if (queryAuth.Count() == 0)
                        return false;
                    else if (queryAuth.First().Auth_key == cert.HashedAuthKey)
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
    }
}
