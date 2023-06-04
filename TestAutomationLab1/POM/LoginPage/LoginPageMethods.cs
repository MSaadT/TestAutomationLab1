using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationLab1.POM.LoginPage
{
    //2
    public partial class LoginPage
    {
        //Methods
        public void Login(IWebDriver driver, string user, string pass)
        {
            driver.FindElement(txtUsername).SendKeys(user);
            driver.FindElement(txtPassword).SendKeys(pass);
            driver.FindElement(btnLogin).Click();
        }
    }
}
