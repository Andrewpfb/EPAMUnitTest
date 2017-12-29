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

        public void InitMainPage()
        {
            mainPage = new Pages.MainPage(driver);
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void SetAirportsAndFindDates(string fromAirport, string toAirport, string typeWay)
        {
            mainPage.OpenPage();
            mainPage.SetFromAirport(fromAirport);
            mainPage.SetToAirport(toAirport);
            mainPage.SetTypeWay(typeWay);
            mainPage.FindDates();
        }

        public void SetPassengersCount(string adultsCount, string childrenCount)
        {
            mainPage.SetAdultsCount(adultsCount);
            mainPage.SetChildrenCount(childrenCount);
        }

        public void SetDateDept(DateTime departmentDate)
        {
            if (departmentDate.Year> DateTime.Now.Year || departmentDate.Month > DateTime.Now.Month)
            {
                mainPage.SetDeptNextMonth();
            }
            mainPage.SetDateDept(departmentDate);
        }

        public void SetDateReturn(DateTime returnDate, bool returnNextMonth)
        {
            if (returnNextMonth)
            {
                mainPage.SetReturnNextMonth();
            }
            mainPage.SetDateReturn(returnDate);
        }

        public void GetMyFlights()
        {
            mainPage.FindMyFlights();
        }

        public void SelectEconomyDept()
        {
            mainPage.SelectEconomDept();
        }

        public void SelectEconomyReturn()
        {
            mainPage.SelectEconomReturn();
        }

        public void ConfirmSelectClass()
        {
            mainPage.ConfirmSelectClass();
        }

        public void ConfirmFlightInfo()
        {
            mainPage.ConfirmFlightInfo();
        }

        public void SelectInvalidPassengerDateOfBirth(DateTime dateOfBirth)
        {
            mainPage.SetPassengerDayOfBirth(dateOfBirth.Day.ToString());
            mainPage.SetPassengerMonthOfBirth(dateOfBirth.ToString("MMMM"));
            mainPage.SetPassengerYearOfBirth(dateOfBirth.Year.ToString());
        }

        public void SetPassengerFullInfo(Businnes_Objects.PassengerInfo passengerInfo)
        {
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
            return mainPage.GetAdress(fullAdress);
        }

        public void ConfirmPassengerAdress()
        {
            mainPage.ConfirmAdress();
        }

        public void ConfirmPayments()
        {
            mainPage.AgreeTermsAndCondition();
            mainPage.ConfirmPayments();
        }

        public void ConfirmPassInfo()
        {
            mainPage.ConfirmPassInfo();
        }

        public bool GetErrorAirport(string errorMessage)
        {
            return mainPage.GetErrorAirport(errorMessage);
        }

        public bool GetErrorFindMyFlights(string message)
        {
            return mainPage.GetErrorFlightNotFound(message);
        }

        public bool GetErrorPassengersCount(string message)
        {
            return mainPage.GetErrorPassengersCount(message);
        }

        public bool GetErrorEmptyPassInfo(string[] message)
        {
            return mainPage.GetErrorEmptyPassInfo(message);
        }

        public bool GetErrorNotInformation(string message)
        {
            return mainPage.GetErrorNotInformation(message);
        }

        public bool GetErrorInvalidYearOfBirth(string message)
        {
            return mainPage.GetErrorInvalidYearOfBirth(message);
        }

        public bool GetErrorInvalidCardNumber(string message)
        {
            return mainPage.GetErrorInvalidCardNumber(message);
        }
    }
}
