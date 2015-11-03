using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Emplokey_Server
{
    class DbManager
    {
        public bool createDatabase()
        {
            bool stat = true;
            string sqlCreateDBQuery;            

            sqlCreateDBQuery = " CREATE DATABASE "
                                + settingsHelper.DB_NAME
                                + " ON PRIMARY "
                                + " (NAME = " + settingsHelper.DB_NAME + "_Data, "
                                + " FILENAME = '" + settingsHelper.DB_PATH + settingsHelper.DB_NAME + ".mdf', "
                                + " SIZE = 2MB,"
                                + " FILEGROWTH = 10%) "
                                + " LOG ON (NAME =" + settingsHelper.DB_NAME + "_Log, "
                                + " FILENAME = '" + settingsHelper.DB_PATH + settingsHelper.DB_NAME + "Log.ldf', "
                                + " SIZE = 1MB, "
                                + " FILEGROWTH = 10%) ";

            SqlCommand myCommand = new SqlCommand(sqlCreateDBQuery, settingsHelper.dbConnection);
            try
            {
                settingsHelper.dbConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                stat = false;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (settingsHelper.dbConnection.State == ConnectionState.Open)
                {
                    settingsHelper.dbConnection.Close();
                }
                settingsHelper.dbConnection.Dispose();
            }
            return stat;
        }

        private void removeDatabase()
        {

        }

        private void backubDatabase()
        {

        }

        private void restoreDatabase()
        {

        }
    }
}
