using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace APKMFrame
{
    public abstract class Pages
    {
        protected abstract string Address { get; }
        protected abstract string Title { get; }

        public virtual void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Address);
        }

        public virtual bool IsThere()
        {
            return Driver.Instance.Title == this.Title;
        }

        protected virtual void WaitToLoad()
        {
            //Thread.Sleep(5000);
            IWait<IWebDriver> wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(30.00));
            wait.Until(d => d.FindElement(By.ClassName("amsBodyMaster")));
        }

        public static LoginPage LoginPage
        {
            get
            {
                var loginPage = new LoginPage();
                PageFactory.InitElements(Driver.Instance, loginPage);
                return loginPage;
            }
        }

        public static HomePage HomePage
        {
            get
            {
                var homePage = new HomePage();
                PageFactory.InitElements(Driver.Instance, homePage);
                return homePage;
            }
        }
    }
}
