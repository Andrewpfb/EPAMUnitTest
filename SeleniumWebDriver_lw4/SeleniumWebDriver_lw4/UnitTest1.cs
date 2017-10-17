using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriver_lw4
{
    [TestClass]
    public class UnitTest1
    {
        FirefoxDriver firefoxDriver;
        [TestMethod]
        public void TestMethod1()
        {
            firefoxDriver = new FirefoxDriver();
            firefoxDriver.Navigate().GoToUrl("https://github.com/");
        }
    }
}
