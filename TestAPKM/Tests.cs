using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using APKMFrame;

namespace TestAPKM
{

    [TestFixture]
    public class TestsLocal
    {
        [SetUp]
        public void InitializeDriver()
        {
            Driver.InitializeRemote();
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

        [OneTimeTearDown]
        public void TerminateDriver()
        {
            Driver.Terminate();
        }
    }
}
