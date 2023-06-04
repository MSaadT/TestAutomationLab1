using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationLab1.POM.LoginPage
{
    [TestClass]
    public class LoginPageTC : Execution
    {
        LoginPage loginPage = new LoginPage();

        //TestCases
        [TestMethod]
        [Owner("Aun Hashmi")]
        [Description("")]
        public void LoginWithValidUserValidPassword()
        {
            loginPage.Login(driver, "AmirTester", "AmirTester");
        }

        [TestMethod]
        public void LoginWithInvalidUserInvalidPassword()
        {
            loginPage.Login(driver, "Invalid", "Invalid123");
        }
    }
}
