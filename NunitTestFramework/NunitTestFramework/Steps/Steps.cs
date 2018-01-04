using OpenQA.Selenium;
using System;
using System.Text;


namespace NunitTestFramework.Steps
{
    public class Steps
    {
        public void OpenMainPage()
        {
            mainPage.OpenPage();
        }
        IWebDriver driver;
        Pages.MainPage mainPage;
        Pages.SelectTicketClassPage selectTicketClassPage;
        Pages.ConfirmTripSummaryPage confirmTripSummaryPage;
        Pages.PassengerInfoPages passengerInfoPages;

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

        public bool SearchOrderInRecentSearch(string recentSearchCity, DateTime departmentDate, DateTime returnDate)
        {
            StringBuilder recentSearchString = new StringBuilder(recentSearchCity);
            recentSearchString.Append(" [");
            recentSearchString.Append(departmentDate.ToString("MMM"));
            recentSearchString.Append(' ');
            recentSearchString.Append(departmentDate.ToString("dd"));
            recentSearchString.Append(" - ");
            recentSearchString.Append(returnDate.ToString("MMM"));
            recentSearchString.Append(' ');
            recentSearchString.Append(returnDate.ToString("dd"));
            recentSearchString.Append(']');
            return mainPage.SearchOrderInRecentSearch(recentSearchString.ToString());
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
            if (departmentDate.Year > DateTime.Now.Year || departmentDate.Month > DateTime.Now.Month)
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
            selectTicketClassPage = mainPage.FindMyFlights();
        }

        public bool GetTicketsTable()
        {
            return selectTicketClassPage.GetTicketsTable();
        }

        public void SelectEconomyDept()
        {
            selectTicketClassPage.SelectEconomDept();
        }
        public void SelectEconomyReturn()
        {
            selectTicketClassPage.SelectEconomReturn();
        }
        public void ConfirmSelectClass()
        {
            confirmTripSummaryPage = selectTicketClassPage.ConfirmSelectClass();
        }
        public void ConfirmFlightInfo()
        {
            passengerInfoPages = confirmTripSummaryPage.ConfirmFlightInfo();
        }

        public void SelectInvalidPassengerDateOfBirth(DateTime dateOfBirth)
        {
            passengerInfoPages.SetPassengerDayOfBirth(dateOfBirth.Day.ToString());
            passengerInfoPages.SetPassengerMonthOfBirth(dateOfBirth.ToString("MMMM"));
            passengerInfoPages.SetPassengerYearOfBirth(dateOfBirth.Year.ToString());
        }
        public void ConfirmPassInfo()
        {
            passengerInfoPages.ConfirmPassInfo();
        }
        public void SetPassengerFullInfo(Businnes_Objects.PassengerInfo passengerInfo)
        {
            passengerInfoPages.SetPassengerTitle(passengerInfo.Title);
            passengerInfoPages.SetPassengerFirstname(passengerInfo.Firstname);
            passengerInfoPages.SetPassengerLastname(passengerInfo.Lastname);
            passengerInfoPages.SetPassengerDayOfBirth(passengerInfo.DateOfBirth.Day.ToString());
            passengerInfoPages.SetPassengerMonthOfBirth(passengerInfo.DateOfBirth.ToString("MMMM"));
            passengerInfoPages.SetPassengerYearOfBirth(passengerInfo.DateOfBirth.Year.ToString());
            if (passengerInfo.Gender == "Male")
            {
                passengerInfoPages.SetPassengerGenderMale();
            }
            else if (passengerInfo.Gender == "Female")
            {
                passengerInfoPages.SetPassengerGenderFemale();
            }
            passengerInfoPages.ConfirmPassInfo();

            passengerInfoPages.SetPassengerEmail(passengerInfo.Email);
            passengerInfoPages.ConfirmPassengerEmail(passengerInfo.Email);
            passengerInfoPages.SetPassengerPhoneType(passengerInfo.PhoneType);
            passengerInfoPages.SetPassengerPhoneLocale(passengerInfo.PhoneNumberLocal);
            passengerInfoPages.SetPassengerPhoneNumber(passengerInfo.PhoneContactNumber);
            passengerInfoPages.ConfirmContactInfo();

            passengerInfoPages.SetPassengerCardNumber(passengerInfo.NumberCard);
            passengerInfoPages.SetPassengerCardFirstname(passengerInfo.FirstnameCard);
            passengerInfoPages.SetPassengerCardLastname(passengerInfo.LastnameCard);
            passengerInfoPages.SetPassengerCardMonthExpire(passengerInfo.ExpiryDateCard.ToString("MMM"));
            passengerInfoPages.SetPassengerCardYearExpire(passengerInfo.ExpiryDateCard.Year.ToString());
            passengerInfoPages.SetPassengerCardSecurityNumber(passengerInfo.SecurityCodeCard);

            passengerInfoPages.SetPassengerCountry(passengerInfo.Country);
            passengerInfoPages.SetPassengerHouseNameOrNumber(passengerInfo.HouseNameOrNumber);
            passengerInfoPages.SetPassengerZipCode(passengerInfo.ZipCode);
            passengerInfoPages.FindAdress();
        }
        public bool GetPassengerFullAdress(string fullAdress)
        {
            return passengerInfoPages.GetAdress(fullAdress);
        }
        public void ConfirmPassengerAdress()
        {
            passengerInfoPages.ConfirmAdress();
        }
        public void ConfirmPayments()
        {
            passengerInfoPages.AgreeTermsAndCondition();
            passengerInfoPages.ConfirmPayments();
        }

        #region Errors

        public bool GetErrorAirport(string errorMessage)
        {
            return mainPage.GetErrorAirport(errorMessage);
        }
        public bool GetErrorPassengersCount(string message)
        {
            return mainPage.GetErrorPassengersCount(message);
        }
        public bool GetErrorFlightNotFound(string message)
        {
            return mainPage.GetErrorFlightNotFound(message);
        }
        public bool GetErrorNotInformation(string message)
        {
            return selectTicketClassPage.GetErrorNotInformation(message);
        }
        public bool GetErrorEmptyPassInfo(string[] message)
        {
            return passengerInfoPages.GetErrorEmptyPassInfo(message);
        }
        public bool GetErrorInvalidYearOfBirth(string message)
        {
            return passengerInfoPages.GetErrorInvalidYearOfBirth(message);
        }
        public bool GetErrorInvalidCardNumber(string message)
        {
            return passengerInfoPages.GetErrorInvalidCardNumber(message);
        }

        #endregion
    }
}
