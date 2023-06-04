using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace TestAutomationLab1
{
    [TestClass]
    public class Search : Execution
    {
        #region Login
        /// <summary>
        /// This Test Case will Login using Valid Credentials
        /// </summary>
        [TestMethod]
        public void ValidLogin()
        {
            Thread.Sleep(2500);
            IWebElement username_123 = driver.FindElement(By.Id("username"));
            username_123.Click();

            driver.FindElement(By.Id("username")).SendKeys(Keys.Tab + Keys.Shift);
            driver.FindElement(By.Name("password")).SendKeys("admin123");
            driver.FindElement(By.Id("login")).Click();

            //IWebElement element = driver.FindElement(By.Id("location"));
            //SelectElement oSelect = new SelectElement(element);

            //oSelect.SelectByIndex(0);
            //oSelect.SelectByValue("Paris");
            //oSelect.SelectByText("Paris");
        }

        /// <summary>
        /// This Test Case will Check Login Functionality using In valid Credentials
        /// </summary>
        [TestMethod]
        public void InValidLogin()
        {
            Thread.Sleep(2500);
            driver.FindElement(By.Id("username")).SendKeys("admin123");
            driver.FindElement(By.Name("password")).SendKeys("admin123");
            driver.FindElement(By.Id("login")).Click();

            string msg = driver.FindElement(By.XPath("//*[@id='login_form']/table/tbody/tr[5]/td[2]/div/b")).Text;
            Console.WriteLine(msg);
            Assert.AreEqual("Invalid Login details or Your Password might have expired. Click here to reset your password", msg);

        }
        #endregion

        #region Search
        #endregion

        [TestMethod]
        public void EmptyLogin()
        {
            Thread.Sleep(2500);
            //driver.FindElement(By.Id("username")).SendKeys("");
            //driver.FindElement(By.Name("password")).SendKeys("");
            driver.FindElement(By.Id("login")).Click();

            Assert.AreNotEqual("Enter UserName", driver.FindElement(By.Id("username_span")).Text);
        }
    }
}
