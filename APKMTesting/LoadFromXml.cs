using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Cache;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using OpenQA.Selenium.Remote;

namespace APKMFrame
{
    public static class LoadFromXml
    {
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public static List<string> GetCredentials()
        {
            var cd = new List<string>();
            var cred = new XmlDocument();
            cred.Load(Path.Combine(AssemblyDirectory, "config\\Credentials.xml"));
            cd.Add(cred.SelectSingleNode("/Credentials/Username")?.InnerText);
            cd.Add(cred.SelectSingleNode("/Credentials/Password")?.InnerText);
            return cd;
        }

        public static DesiredCapabilities GetCapabilities()
        {
            var caps = new DesiredCapabilities();
            var capsxml = new XmlDocument();
            capsxml.Load(Path.Combine(AssemblyDirectory, "config\\Capabilities.xml"));

            caps.SetCapability("name",              capsxml.SelectSingleNode("/Capabilities/Name")?.InnerText);
            caps.SetCapability("build",             capsxml.SelectSingleNode("/Capabilities/Build")?.InnerText);
            caps.SetCapability("browser_api_name",  capsxml.SelectSingleNode("/Capabilities/Browser_api_name")?.InnerText);
            caps.SetCapability("os_api_name",       capsxml.SelectSingleNode("/Capabilities/Os_api_name")?.InnerText);
            caps.SetCapability("screen_resolution", capsxml.SelectSingleNode("/Capabilities/Screen_resolution")?.InnerText);
            caps.SetCapability("record_video",      capsxml.SelectSingleNode("/Capabilities/Record_video")?.InnerText);
            caps.SetCapability("record_network",    capsxml.SelectSingleNode("/Capabilities/Record_network")?.InnerText);
            caps.SetCapability("username",          capsxml.SelectSingleNode("/Capabilities/Username")?.InnerText);
            caps.SetCapability("password",          capsxml.SelectSingleNode("/Capabilities/Password")?.InnerText);

            return caps;
        } 
    }
}
