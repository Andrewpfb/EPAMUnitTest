using System;
using OpenQA.Selenium;


namespace NunitTestFramework.Steps
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

        public void SelectInvalidPassengerDateOfBirth(DateTime dateOfBirth)
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.SetPassengerDayOfBirth(dateOfBirth.Day.ToString());
            mainPage.SetPassengerMonthOfBirth(dateOfBirth.ToString("MMMM"));
            mainPage.SetPassengerYearOfBirth(dateOfBirth.Year.ToString());
        }

        public void SetPassengerFullInfo(Businnes_Objects.PassengerInfo passengerInfo)
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.SetPassengerTitle(passengerInfo.Title);
            mainPage.SetPassengerFirstname(passengerInfo.Firstname);
            mainPage.SetPassengerLastname(passengerInfo.Lastname);
            mainPage.SetPassengerDayOfBirth(passengerInfo.DateOfBirth.Day.ToString());
            mainPage.SetPassengerMonthOfBirth(passengerInfo.DateOfBirth.ToString("MMMM"));
            mainPage.SetPassengerYearOfBirth(passengerInfo.DateOfBirth.Year.ToString());
            mainPage.SetPassengerGender(passengerInfo.Gender);
            mainPage.ConfirmPassInfo();

            mainPage.SetPassengerEmail(passengerInfo.Email);
            mainPage.ConfirmPassengerEmail(passengerInfo.Email);
            mainPage.SetPassengerPhoneType(passengerInfo.PhoneType);
            mainPage.SetPassengerPhoneLocale(passengerInfo.NumberLocal);
            mainPage.SetPassengerPhoneNumber(passengerInfo.ContactNumber);
            mainPage.ConfirmContactInfo();

            mainPage.SetPassengerCardNumber(passengerInfo.CardNumber);
            mainPage.SetPassengerCardFirstname(passengerInfo.FirstnameCard);
            mainPage.SetPassengerCardLastname(passengerInfo.LastnameCard);
            mainPage.SetPassengerCardMonthExpire(passengerInfo.ExpiryDateCard.ToString("MMM"));
            mainPage.SetPassengerCardYearExpire(passengerInfo.ExpiryDateCard.Year.ToString());
            mainPage.SetPassengerCardSecurityNumber(passengerInfo.SecurityCode);

            mainPage.SetPassengerCountry(passengerInfo.Country);
            mainPage.SetPassengerHouseNameOrNumber(passengerInfo.HouseNameOrNumber);
            mainPage.SetPassengerZipCode(passengerInfo.ZipCode);
            mainPage.FindAdress();
        }

        public bool GetPassengerFullAdress(string fullAdress)
        {
            mainPage = new Pages.MainPage(driver);
            return mainPage.GetAdress(fullAdress);
        }

        public void ConfirmPassengerAdress()
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.ConfirmAdress();
        }

        public void AgreeTermsAndConditions()
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.AgreeTermsAndCondition();
        }

        public void ConfirmPayments()
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.ConfirmPayments();
        }

        public void ConfirmPassInfo()
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.ConfirmPassInfo();
        }

        public bool GetErrorAirport(string errorMessage)
        {
            mainPage = new Pages.MainPage(driver);
            return mainPage.GetErrorAirport(errorMessage);
        }

        public bool GetErrorFindMyFlights(string message)
        {
            mainPage = new Pages.MainPage(driver);
            return mainPage.GetErrorFlightNotFound(message);
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

        public bool GetErrorInvalidYearOfBirth(string message)
        {
            mainPage = new Pages.MainPage(driver);
            return mainPage.GetErrorInvalidYearOfBirth(message);
        }

        public bool GetErrorInvalidCardNumber(string message)
        {
            mainPage = new Pages.MainPage(driver);
            return mainPage.GetErrorInvalidCardNumber(message);
        }
    }
}
