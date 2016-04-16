using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace APKMFrame
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }
        
        public static void Initialize()
        {
            ChromeOptions opt = new ChromeOptions();
            opt.AddArgument("--start-maximized");
            Instance = new ChromeDriver(opt);
        }

        public static void Terminate()
        {
            Instance.Quit();
        }
    }

   
}