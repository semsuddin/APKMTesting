using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using APKMFrame;

namespace TestAPKM
{

    [TestFixture]
    public class TestsLocal
    {
        [OneTimeSetUp]
        public void InitializeDriver()
        {
            Driver.Initialize();
        }

        [TestCase()]
        public void Can_Open()
        {
            Pages.LoginPage.GoTo();
            Assert.IsTrue(Pages.LoginPage.IsThere());
        }

        [TestCase()]
        public void Can_LogIn()
        {
            Pages.LoginPage.GoTo();
            Pages.LoginPage.Login();
            Assert.IsTrue(Pages.HomePage.IsThere());
        }

        [TearDown]
        public void TerminateDriver()
        {
            Driver.Terminate();
        }
    }

    [TestFixture]
    public class TestsRemote
    {
        [OneTimeSetUp]
        public void Initialize()
        {
            Driver.InitializeRemote();
        }

        [TestCase()]
        public void Can_OpenRemote()
        {
            try
            {
                Pages.LoginPage.GoTo();
                Assert.IsTrue(Pages.LoginPage.IsThere());
                CBTApi.Passed();
            }
            catch (Exception e)
            {
                CBTApi.Failed(e.Message);
                throw;
            }

        }

        [TestCase()]
        public void Can_LogInRemote()
        {
            try
            {
                Pages.LoginPage.GoTo();
                Pages.LoginPage.Login();
                Thread.Sleep(3000);
                Assert.IsTrue(Pages.HomePage.IsThere());
                CBTApi.Passed();
            }
            catch (Exception e)
            {
                CBTApi.Failed(e.Message);
                throw;
            }

        }

        [TearDown]
        public void TerminateDriver()
        {
            Driver.Terminate();
        }
    }
}
