using System;

using OpenQA.Selenium;


namespace TestFramework.Steps
{
    public class Steps
    {
        IWebDriver driver;
        Pages.MainPage mainPage;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void FindDates(string fromAirport, string toAirport)
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.FindDates(fromAirport, toAirport);
        }

        public bool GetErrorAirport(string errorMessage)
        {
            mainPage = new Pages.MainPage(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return mainPage.GetErrorAirport(errorMessage);
        }

        public void SetDates()
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.SetDates();
        }
    }
}
