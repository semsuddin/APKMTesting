using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace APKMFrame
{
    public static class GetCredentials
    {
        public static List<string> Get()
        {
            var cd = new List<string>();
            var cred = new XmlDocument();
            cred.Load("C:\\Users\\semsudin.sefic\\Documents\\Visual Studio 2015\\Projects\\APKMTesting\\APKMTesting\\Credentials.xml");
            cd.Add(cred.SelectSingleNode("/Credentials/Username")?.InnerText);
            cd.Add(cred.SelectSingleNode("/Credentials/Password")?.InnerText);
            return cd;
        }
    }
}
