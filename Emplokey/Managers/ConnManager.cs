using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Emplokey
{
    public class ConnManager
    {
        public void SaveServerInfo(ServerInfo serverInfo)
        {
            if (!File.Exists(settingsHelper.userPath + settingsHelper.defaultSettingsFile))
            {
                XDocument xSettings = new XDocument(
                new XDeclaration("1.0", "UTF-16", null),
                new XElement(settingsHelper.xNameSpace + "Emplokey_settings",
                    new XElement("Server",
                        new XElement("Address", serverInfo.address),
                        new XElement("DbName", serverInfo.dbName)
                    )));

                xSettings.Save(settingsHelper.userPath + settingsHelper.defaultSettingsFile);
            }
            else
            {
                XDocument xSettings = XDocument.Load(settingsHelper.userPath + settingsHelper.defaultSettingsFile);

                var queryServer = (from q in xSettings.Descendants("Server")
                                   select q).First();

                queryServer.Element("Address").Value = serverInfo.address;
                queryServer.Element("DbName").Value = serverInfo.dbName;

                xSettings.Save(settingsHelper.userPath + settingsHelper.defaultSettingsFile);
            }
        }

        public ServerInfo LoadServerInfo()
        {
            var newServerInfo = new ServerInfo();

            if (File.Exists(settingsHelper.userPath + settingsHelper.defaultSettingsFile))
            {
                XDocument xSettings = XDocument.Load(settingsHelper.userPath + settingsHelper.defaultSettingsFile);

                var queryServer = (from q in xSettings.Descendants("Server")
                                   select q).First();

                newServerInfo.address = queryServer.Element("Address").Value;
                newServerInfo.dbName = queryServer.Element("DbName").Value;
                newServerInfo.loaded = true;
            }

            return newServerInfo;
        }

        public bool TryToConnect(ServerInfo serverInfo)
        {
            string connString = String.Format(settingsHelper.connectionString, serverInfo.address);
            SqlConnection connection = new SqlConnection(connString);

            try
            {
                connection.Open();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public void ConfirmActivity(ServerInfo serverInfo, List<Cert> certList)
        {
            string connString = String.Format(settingsHelper.connectionString, serverInfo.address);
            SqlConnection connection = new SqlConnection(connString);
            DataClassesDataContext database = new DataClassesDataContext();

            try
            {
                connection.Open();

                foreach (var cert in certList)
                {
                    var queryRequest = from r in database.Requests
                                       join l in database.Logs on r.LogId equals l.ID
                                       join u in database.Users on l.ID_user equals u.ID
                                       join c in database.Computers on l.ID_pc equals c.ID
                                       where u.Username == cert.user && c.PC_name == SystemInformation.ComputerName
                                       select r;

                    if (queryRequest.Any())
                    {
                        queryRequest.First().Confirmed = 1;
                        database.SubmitChanges();
                    }                        
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}