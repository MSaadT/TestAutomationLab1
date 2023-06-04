using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace TestAutomationLab1
{
    [TestClass]
    public class Login : Execution
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

        [TestMethod]
        [DataRow("admin", "admin123")]
        [DataRow("fname", "lname")]
        [DataRow("MSTest", "Selenium")]
        //[Ignore("For Parallel Execution")]
        public void TestMethod1(string uname, string password)
        {
            driver.FindElement(By.Id("username")).SendKeys(uname);

            Console.WriteLine("Value1: " + uname);
            Console.WriteLine("Value2: " + password);
        }

        public IWebElement ScrollToElement(IWebElement webElement)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
            return webElement;
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "Login", DataAccessMethod.Sequential)]
        public void ValidLoginXML()
        {
            string currentDateAndTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(@"Screenshot_" + currentDateAndTime + ".png", ScreenshotImageFormat.Png);


            //string url = TestContext.DataRow["url"].ToString();
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();

            Thread.Sleep(2500);
            IWebElement username_123 = driver.FindElement(By.Id("username"));

            var abc = username_123.GetAttribute("value");
            username_123.Click();

            driver.FindElement(By.Id("username")).SendKeys(user);
            driver.FindElement(By.Name("password")).SendKeys(pass);
            driver.FindElement(By.Id("login")).Click();
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "Data#csv", "Data#csv", DataAccessMethod.Sequential)]
        public void ValidLoginCSV()
        {
            //string url = TestContext.DataRow["url"].ToString();
            string user = TestContext.DataRow["username"].ToString();
            string pass = TestContext.DataRow["password"].ToString();

            Thread.Sleep(2500);
            IWebElement username_123 = driver.FindElement(By.Id("username"));
            username_123.Click();

            driver.FindElement(By.Id("username")).SendKeys(TestContext.DataRow["username"].ToString());
            driver.FindElement(By.Name("password")).SendKeys(pass);
            driver.FindElement(By.Id("login")).Click();
        }

        #region Login
        /// <summary>
        /// This Test Case will Login using Valid Credentials
        /// </summary>
        [TestMethod]
        public void ValidLogin()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("")));

            //int i = driver.FindElements(By.TagName("input")).Count;
            //Console.WriteLine(i);

            //Thread.Sleep(15000);

            List<IWebElement> btn = new List<IWebElement>(driver.FindElements(By.TagName("input")));
            btn[0].SendKeys("admin");
            btn[1].SendKeys("admin123");
            btn[2].Click();

            string msg = driver.FindElement(By.XPath("//*[@id='login_form']/table/tbody/tr[5]/td[2]/div/b")).Text;
            Assert.AreEqual("Invalid Login details or Your Password might have expired. Click here to reset your password", msg);


            //Select Location

            //Thread.Sleep(2500);
            //IWebElement username_123 = driver.FindElement(By.Id("username"));
            //username_123.Click();

            //driver.FindElement(By.Id("username")).SendKeys(Keys.Tab + Keys.Shift);
            //driver.FindElement(By.Name("password")).SendKeys("admin123");
            //driver.FindElement(By.Id("login")).Click();

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

        public string uname = "username";
        public By uname1 = By.XPath("username");


        [TestMethod]
        public void EmptyLogin()
        {
            driver.FindElement(By.Id(uname)).Click();
            driver.FindElement(uname1).Click();


            Thread.Sleep(2500);
            //driver.FindElement(By.Id("username")).SendKeys("");
            //driver.FindElement(By.Name("password")).SendKeys("");
            driver.FindElement(By.Id("login")).Click();

            Assert.AreNotEqual("Enter UserName", driver.FindElement(By.Id("username_span")).Text);
        }
    }
}
