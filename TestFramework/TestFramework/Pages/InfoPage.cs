using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace TestFramework.Pages
{
    public class InfoPage
    {
        [FindsBy(How = How.XPath, Using = ".//*[@id='warningFocus']/p")]
        private IWebElement divErrorFlightNotFound;

        private IWebDriver driver;

        public InfoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool GetErrorFlightNotFound(string message)
        {
            return divErrorFlightNotFound.Text == message;
        }
    }
}
