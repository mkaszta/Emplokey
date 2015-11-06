using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Emplokey
{
    public class ConnManager
    {
        public void saveSettings(ServerInfo serverInfo)
        {            
            if (!File.Exists(settingsHelper.userPath + settingsHelper.defaultSettingsFile))
            {
                XDocument xSettings = new XDocument(
                new XDeclaration("1.0", "UTF-16", null),
                new XElement(settingsHelper.xNameSpace + "Emplokey_settings",
                    new XElement("Server",
                        new XElement("Address", serverInfo.address),
                        new XElement("DbName", serverInfo.dbName),
                        new XElement("Username", serverInfo.userName),
                        new XElement("Password", serverInfo.password)                    
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
                queryServer.Element("Username").Value = serverInfo.userName;
                queryServer.Element("Password").Value = serverInfo.password;

                xSettings.Save(settingsHelper.userPath + settingsHelper.defaultSettingsFile);
            }
        }

        public void getServerSettings(Form_main formMain)
        {
            if (File.Exists(settingsHelper.userPath + settingsHelper.defaultSettingsFile))
            {
                XDocument xSettings = XDocument.Load(settingsHelper.userPath + settingsHelper.defaultSettingsFile);

                var queryServer = (from q in xSettings.Descendants("Server")
                                   select q).First();

                formMain.serverInfo.address = queryServer.Element("Address").Value;
                formMain.serverInfo.dbName = queryServer.Element("DbName").Value;
                formMain.serverInfo.userName = queryServer.Element("Username").Value;
                formMain.serverInfo.password = queryServer.Element("Password").Value;
            }
        }      
        
        public bool tryToConnect(ServerInfo serverInfo)
        {
            string connString = String.Format("Server = {0}; database=master; User Id={1}; Password={2}", serverInfo.address, serverInfo.userName, serverInfo.password);            

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                }
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }  
    }
}
