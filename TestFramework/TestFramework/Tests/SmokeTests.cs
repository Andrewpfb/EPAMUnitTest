using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestFramework.Tests
{
    [TestClass]
    class SmokeTests
    {
        private Steps.Steps steps = new Steps.Steps();
        private const string FROM_AIRPORT = "New York, (JFK) US";
        private const string TO_AIRPORT = "London Heathrow, (LHR) GB";

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [TestMethod]
        public void OneCanGetDates()
        {
            FirefoxDriver firefoxDriver;
            firefoxDriver = new FirefoxDriver();
            firefoxDriver.Navigate().GoToUrl("https://github.com/");
            firefoxDriver.FindElementByXPath(".//a[text() = 'Sign in']").Click();
            firefoxDriver.FindElementById("login_field").SendKeys("testautomationuser");
            firefoxDriver.FindElementById("password").SendKeys("Time4Death!");
            steps.FindDates(FROM_AIRPORT, TO_AIRPORT);
        }
    }
}
