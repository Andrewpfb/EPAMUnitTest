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
            return mainPage.GetErrorAirport(errorMessage);
        }

        public void SetDateDept()
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.SetDateDept();
        }
        public void SetDateReturn()
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.SetDateReturn();
        }
        public void GetMyFlights()
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.FindMyFlights();
        }
        public bool GetErrorFindMyFlights(string message)
        {
            mainPage = new Pages.MainPage(driver);
            return mainPage.GetErrorFlightNotFound(message);
        }

        public void SelectEconomyDept()
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.SelectEconomDept();
        }

        public void SelectEconomyReturn()
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.SelectEconomReturn();
        }

        public void ConfirmSelectClass()
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.ConfirmSelectClass();
        }

        public void ConfirmFlightInfo()
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.ConfirmFlightInfo();
        }

        public void ConfirmPassInfo()
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.ConfirmPassInfo();
        }

        public bool GetErrorEmptyPassInfo(string[] message)
        {
            mainPage = new Pages.MainPage(driver);
            return mainPage.GetErrorEmptyPassInfo(message);
        }

        public bool GetErrorNotInformation(string message)
        {
            mainPage = new Pages.MainPage(driver);
            return mainPage.GetErrorNotInformation(message);
        }
    }
}
