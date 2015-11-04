using System.Text;
using System.Security.Cryptography;

namespace Emplokey
{
    public class Cert
    {
        public string path { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public bool loaded { get; set; }

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