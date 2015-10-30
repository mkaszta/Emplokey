using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Emplokey
{
    class CertManager
    {
        public void createCert(Cert cert)
        {
            XNamespace xNameSpace = "urn:lst-emp:emp";

            XDocument xCert = new XDocument(
                new XDeclaration("1.0", "UTF-16", null),
                new XElement(xNameSpace + "EmplokeyCert",
                    new XElement("User", cert.user),
                    new XElement("Password", cert.password),
                    new XElement("Hash", "no-hash-yet")
                    ));

            xCert.Save(cert.path + settingsHelper.defaultCertName);
        }

        private void registerCert(string path)
        {

        }
    }
}
