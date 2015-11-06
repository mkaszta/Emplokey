using System.Text;
using System.Security.Cryptography;

namespace Emplokey
{
    public class Cert
    {
        public string path { get; set; }
        public string user { get; set; }
        public string userType { get; set; }
        public string pcName { get; set; }        
        public bool loaded { get; set; }

        public string HashedAuthKey
        {
            get
            {
                return hashedAuthKey;
            }

            set
            {
                hashedAuthKey = value;
            }
        }

        private string _hashedAuthKey;
        private string hashedAuthKey
        {
            set { }
            get { return _hashedAuthKey = getHashedAuthKey(user, pcName); }
        }

        public static string getHashedAuthKey(string user, string pcName)
        {
            SHA1 sha1 = SHA1.Create();
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(settingsHelper.sha1Salt + user + pcName + settingsHelper.sha1Salt));

            var hashedPassword = new StringBuilder();

            for (int i = 0; i < hashData.Length; i++)
            {
                hashedPassword.Append(hashData[i].ToString());
            }

            return hashedPassword.ToString();
        }
    }    
}