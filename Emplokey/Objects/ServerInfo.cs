using System.Text;
using System.Security.Cryptography;

namespace Emplokey
{
    public class ServerInfo
    {
        public string address { get; set; }
        public string dbName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        private string _hashedPassword;

        public string hashedPassword
        {
            set { }
            get { return _hashedPassword = getHashedPassword(password); }
        }

        public static string getHashedPassword(string rawPassword)
        {
            SHA1 sha1 = SHA1.Create();
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(settingsHelper.sha1Salt + rawPassword));

            var hashedPassword = new StringBuilder();

            for (int i = 0; i < hashData.Length; i++)
            {
                hashedPassword.Append(hashData[i].ToString());
            }

            return hashedPassword.ToString();
        }
    }
}
