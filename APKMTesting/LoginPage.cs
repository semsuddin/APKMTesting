using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace APKMFrame
{
    public class LoginPage : Pages
    {
        [FindsBy (How = How.Id, Using = "cred_userid_inputtext")]
        public IWebElement UserId { get; set; }

        [FindsBy (How = How.Id, Using = "cred_password_inputtext")]
        public IWebElement Password { get; set; }

        [FindsBy (How = How.Id, Using = "cred_sign_in_button")]
        public IWebElement SignIn { get; set; }

        [FindsBy (How = How.Id, Using = "credentials")]
        public IWebElement CredentialsForm { get; set; }

        public override string Address { get; } = "http://ams.authoritypartners.com/";

        public override string Title { get; } = "Sign in to your account";

        public LoginPage()
        {
            PageFactory.InitElements(Driver.Instance, this);
        }

        public void Login()
        {
            var cd = GetCredentials.Get();
            UserId.SendKeys(cd[0]);
            Password.SendKeys(cd[1]);
            SignIn.Click();
            CredentialsForm.Submit();
            this.WaitToLoad();
        }

        
    }
}
