using System;
using System.Xml.Linq;

namespace Emplokey_Server
{
    class settingsHelper
    {
        public static XNamespace xNameSpace = "urn:lst-emp:emp";

        public static string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\EmploKey\\";
        public static string settingsFilename = "EmplokeyServer_settings.xml";
    }
}
