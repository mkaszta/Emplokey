﻿using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

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
    }
}