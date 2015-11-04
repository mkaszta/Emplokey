using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Emplokey
{
    class settingsHelper
    {
        // Certificate settings
        public static string defaultCertName = "emplokey_cert.xml";
        public static string defaultSettingsFile = "emplokey_settings.xml";
        public static XNamespace xNameSpace = "urn:lst-emp:emp";

        // Cryptography settings
        public static string sha1Salt = "da39a3ee5e6b4b0d3255bfef95601890afd80709";

        // Gets local user path for AppData
        public static string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\EmploKey\\";

        // COunter used for auto-lock
        public static int counter = 30;
    }
}
