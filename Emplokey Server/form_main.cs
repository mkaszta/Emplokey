using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Emplokey_Server
{
    public partial class Form_main : Form
    {
        DbManager dbMgr = new DbManager();
        public List<Server> serverList = new List<Server>();

        public Form_main()
        {
            InitializeComponent();
            updateComboBox();
        }

        private void btnNewDB_Click(object sender, EventArgs e)
        {
            string DbServer = textBoxAddress.Text;
            string DbName = textBoxDbName.Text;
            string Username = textBoxUsername.Text;
            string Password = textBoxPassword.Text;

            try
            {
                dbMgr.createDatabase(DbServer, DbName, Username, Password);
                updateComboBox();               
            }            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        

        private void btnSetDefault_Click(object sender, EventArgs e)
        {
            dbMgr.setDefaultServer(textBoxAddress.Text);
        }

        private void comboBoxServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxAddress.Text = serverList[comboBoxServers.SelectedIndex].address;
            textBoxDbName.Text = serverList[comboBoxServers.SelectedIndex].dbName;
            textBoxUsername.Text = serverList[comboBoxServers.SelectedIndex].userName;
            textBoxPassword.Text = "";
            btnConnect.Enabled = true;
        }

        private void updateComboBox()
        {
            comboBoxServers.Items.Clear();
            dbMgr.getServersList(this);

            foreach (var server in serverList)
            {
                comboBoxServers.Items.Add(server.address + " (" + server.dbName + ")");
                if (server.isDefault == "true")
                    comboBoxServers.SelectedIndex = comboBoxServers.Items.Count - 1;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            dbMgr.connect(serverList[comboBoxServers.SelectedIndex]);
        }
    }
}
