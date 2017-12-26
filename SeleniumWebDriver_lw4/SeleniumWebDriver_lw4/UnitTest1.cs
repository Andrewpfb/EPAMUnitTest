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
            //firefoxDriver.Navigate().GoToUrl("https://github.com/");
            //firefoxDriver.FindElementByXPath(".//a[text() = 'Sign in']").Click();
            //firefoxDriver.FindElementById("login_field").SendKeys("testautomationuser");
            //firefoxDriver.FindElementById("password").SendKeys("Time4Death!");
            firefoxDriver.Navigate().GoToUrl("https://nordwindairlines.ru");
            firefoxDriver.FindElementsByClassName("nput__control city-input_departure__control js-location-input")[0].Clear();
            firefoxDriver.FindElementsByClassName("nput__control city-input_departure__control js-location-input")[0].SendKeys("Минск");
        }
    }
}
