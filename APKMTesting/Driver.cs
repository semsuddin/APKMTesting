using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace APKMFrame
{
    public static class Driver
    {
        public static RemoteWebDriver Instance { get; private set; }
        public static SessionId Session { get; private set; }
        public static void Initialize()
        {
            ChromeOptions opt = new ChromeOptions();
            opt.AddArgument("--start-maximized");
            Instance = new ChromeDriver(opt);
        }

        public static void InitializeRemote()
        {
            var caps = new DesiredCapabilities();
            caps = LoadFromXml.GetCapabilities();
            Instance = new RemoteWebDriver(new Uri("http://hub.crossbrowsertesting.com:80/wd/hub"), caps);
            Instance.Manage().Window.Maximize();
            Session = Instance.SessionId;
        }

        public static void Terminate()
        {
            Instance.Quit();
        }
    }
}