using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Collections;
using System.Threading;

namespace TestAutomationLab1
{
    [TestClass]
    public class CrossBrowser
    {

        public string uname = "username";

        [TestMethod]
        public void Chrome()
        {


            ChromeOptions options = new ChromeOptions();
            options.AddArguments("—start - maximized");
            options.AddArguments("headless");
            options.AddArguments("incognito");
            options.AddArguments("disable-extensions");
            options.AddArguments("disable-popup-blocking");

            IWebDriver driver = new ChromeDriver(options);
            driver.Url = "https://adactinhotelapp.com/";
            driver.FindElement(By.Id("username")).SendKeys("admin");
            Thread.Sleep(5000);
            //{Tab 3},0
            //Thread.Sleep(5000);
            driver.FindElement(By.Id("password")).SendKeys("admin");
            driver.FindElement(By.Id("login")).Click();
            driver.Quit();
        }

        [TestMethod]
        public void FireFox()
        {
            //FirefoxOptions options = new FirefoxOptions();
            //options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            //options.
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://adactinhotelapp.com/";
            driver.FindElement(By.Id("username")).SendKeys("admin");
            driver.FindElement(By.Id("password")).SendKeys("admin");
            driver.FindElement(By.Id("login")).Click();
            driver.Close();
        }

        [TestMethod]
        public void FireFox1()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService("D:\\drivers\\", "geckodriver.exe");
            
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe"; 
            IWebDriver driver = new FirefoxDriver(service);
            driver.Url = "https://adactinhotelapp.com/";
            driver.FindElement(By.Id("username")).SendKeys("admin");
            driver.FindElement(By.Id("password")).SendKeys("admin123");
            driver.FindElement(By.Id("login")).Click();
            driver.Close();
        }

        [TestMethod]
        public void MSEdge()
        {
            var options = new EdgeOptions();
            IWebDriver driver = new EdgeDriver();
            driver.Url = "https://adactinhotelapp.com/";
            driver.FindElement(By.Id("username")).SendKeys("admin");
            driver.FindElement(By.Id("password")).SendKeys("admin");
            driver.FindElement(By.Id("login")).Click();
            driver.Close();
        }







    }
}
