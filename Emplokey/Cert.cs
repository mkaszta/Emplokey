using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace Emplokey
{
    class Cert
    {
        public string path { get; set; }
        public string user { get; set; }
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
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(rawPassword + settingsHelper.sha1Salt));

            var hashedPassword = new StringBuilder();

            for (int i = 0; i < hashData.Length; i++)
            {
                hashedPassword.Append(hashData[i].ToString());
            }

            return hashedPassword.ToString();
        }
    }    
}