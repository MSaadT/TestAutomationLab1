using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace TestAutomationLab1
{
    [TestClass]
    public class WindowHandles : Execution
    {
        [TestMethod]
        public void NewTab()
        {
            driver.Url = "https://demoqa.com/browser-windows";
            driver.FindElement(By.Id("tabButton")).Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            string text = driver.FindElement(By.Id("sampleHeading")).Text;
            
            driver.FindElement(By.Id("sampleHeading")).SendKeys("{Tab}");
            
            Console.WriteLine(text);
            Thread.Sleep(5000);
        }

        [TestMethod]
        public void NewWindow()
        {
            driver.Url = "https://demoqa.com/browser-windows";
            driver.FindElement(By.Id("windowButton")).Click();

            driver.SwitchTo().Window(driver.WindowHandles[1]);
            string text = driver.FindElement(By.Id("sampleHeading")).Text;
            Console.WriteLine(text);
            Thread.Sleep(5000);
        }

        [TestMethod]
        public void NewMessageWindow()
        {
            driver.Url = "https://demoqa.com/browser-windows";
            driver.FindElement(By.Id("messageWindowButton")).Click();

            var handlers = driver.WindowHandles;
            foreach (var handler in handlers)
            {
                driver.Title.Contains("Google Chrome");
            }
            string text = driver.FindElement(By.TagName("body")).Text;
            Console.WriteLine(text);
            Thread.Sleep(5000);
        }

    }
}
