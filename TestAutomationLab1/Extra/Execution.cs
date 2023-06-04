using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace TestAutomationLab1
{
    [TestClass]
    public class Execution
    {
        int i = 0;
        public static IWebDriver driver;
        private TestContext instance;

        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            Console.WriteLine("AssemblyInitialize");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Console.WriteLine("AssemblyCleanup");
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Console.WriteLine("ClassInitialize");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Console.WriteLine("ClassCleanup");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            string testName = TestContext.TestName;
            Console.WriteLine(testName);
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Url = "http://adactinhotelapp.com/";
            Console.WriteLine("abc");
                    
                            //OR

            //driver.Navigate().GoToUrl("http://adactinhotelapp.com/");
            Console.WriteLine("abc");


            //if (i == 0)
            //{
            //    driver = new ChromeDriver();
            //    i++;
            //}
            //else if (i == 1)
            //{
            //    driver = new FirefoxDriver();
            //    i++;
            //}
            //else if (i == 2)
            //{
            //    driver = new EdgeDriver();
            //    i++;
            //}
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
