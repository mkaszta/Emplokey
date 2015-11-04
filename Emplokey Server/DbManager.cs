using System;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Emplokey_Server
{
    class DbManager
    {
        public void createDatabase(string DbServer, string DbName, string Username, string Password)
        {
            string connString = String.Format("Server = {0}; database=master; User Id={1}; Password={2}", DbServer, Username, Password);
            SqlConnection connection = new SqlConnection(connString);

            using (var conn = connection)
            {
                using (var command = new SqlCommand())
                {
                    conn.Open();
                    command.Connection = conn;
                    command.CommandText = "Create Database " + DbName;
                    command.ExecuteNonQuery();
                    command.CommandText = "Use " + DbName + ";CREATE TABLE Users (ID int, Username text, Pass text, Type text);";
                    command.ExecuteNonQuery();
                }
            }

            updateXmlSettings(DbServer, DbName, Username);
            MessageBox.Show("Database created succesfully!");
        }

        private void updateXmlSettings(string server, string dbName, string user)
        {
            XDocument xSettings = new XDocument();

            if (!File.Exists(settingsHelper.userPath + settingsHelper.settingsFilename))
            {
                xSettings = new XDocument(
                new XDeclaration("1.0", "UTF-16", null),
                new XElement("EmplokeyServer",
                    new XElement("Database",
                        new XElement("Server", server),
                        new XElement("DbName", dbName),
                        new XElement("User", user),
                        new XElement("Default", "true")
                    )));
            }       
            else
            {
                xSettings = XDocument.Load(settingsHelper.userPath + settingsHelper.settingsFilename);

                var queryServers = from q in xSettings.Descendants("Database")
                            where (q.Element("Server").Value == server && q.Element("DbName").Value == dbName)
                            select q;

                if (queryServers.Count() == 0)
                {
                    var queryAll = from q in xSettings.Descendants("Database")
                                   select q;

                    foreach (var item in queryAll)
                    {
                        item.Element("Default").Value = "false";
                    }

                    xSettings.Element("EmplokeyServer").Add(
                        new XElement("Database",
                            new XElement("Server", server),
                            new XElement("DbName", dbName),
                            new XElement("User", user),
                            new XElement("Default", "true")
                        ));
                }
                else if (queryServers.Count() > 1)
                    MessageBox.Show("This database already exists in the settings file.\nPlease use different DB name or reaorganize settings file.");
            }     

            xSettings.Save(settingsHelper.userPath + settingsHelper.settingsFilename);
        }

        public void setDefaultServer(string server)
        {
            try
            {
                XDocument xSettings = XDocument.Load(settingsHelper.userPath + settingsHelper.settingsFilename);

                var queryServer = from q in xSettings.Descendants("Database")
                                   where q.Element("Server").Value == server
                                   select q;

                var queryAll = from q in xSettings.Descendants("Database")
                               select q;

                if (queryServer.Count() == 0)
                {
                    MessageBox.Show(String.Format("Couldn't set \"{0}\" to default.\nServer not found in settings file.", server));
                    return;
                }

                foreach (var item in queryAll)
                {
                    item.Element("Default").Value = "false";
                }                

                queryServer.First().Element("Default").Value = "true";

                xSettings.Save(settingsHelper.userPath + settingsHelper.settingsFilename);
                MessageBox.Show(String.Format("Server \"{0}\" set as default.", server));
            }   
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }         
        }

        public void getServersList(Form_main formMain)
        {
            formMain.serverList.Clear();
               
            if (File.Exists(settingsHelper.userPath + settingsHelper.settingsFilename))
            {
                XDocument xSettings = XDocument.Load(settingsHelper.userPath + settingsHelper.settingsFilename);                

                var queryAll = from q in xSettings.Descendants("Database")
                               select q;

                foreach (var item in queryAll)
                {
                    formMain.serverList.Add(
                        new Server
                        {
                            address = item.Element("Server").Value,
                            dbName = item.Element("DbName").Value,
                            userName = item.Element("User").Value,
                            isDefault = item.Element("Default").Value,
                        });
                }                
            }            
        }

        public void connect(Server server)
        {

        }
    }
}
