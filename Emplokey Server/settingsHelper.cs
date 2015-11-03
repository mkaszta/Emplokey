using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Emplokey_Server
{
    class settingsHelper
    {
        // DB settings
        public static string DB_NAME = "Emplokey";
        public static string DB_PATH = "C:\\Emplokey_db\\";
        public static SqlConnection dbConnection = new SqlConnection("Server = localhost\\SQLEXPRESS; Integrated security = SSPI; database=master;");
    }
}
