using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace NunitTestFramework.Pages
{
    public class MainPage
    {
        private const string BASE_URL = "https://www.virginatlantic.com";

        

        #region Airports Elements

        [FindsBy(How = How.Id, Using = "origin")]
        private IWebElement inputFromAirport;

        [FindsBy(How = How.Id, Using = "destination")]
        private IWebElement inputToAirport;

        #endregion

        #region Date Elements

        [FindsBy(How = How.XPath, Using = ".//*[@id='bookingWidgetCalenderDept']/div/table/tbody")]
        private IWebElement deptCalendar;

        [FindsBy(How = How.XPath, Using = ".//*[@id='bookingWidgetCalenderReturn']/div/table/tbody")]
        private IWebElement returnCalendar;
        #endregion

        #region Errors Elements
        [FindsBy(How = How.XPath, Using = ".//*[@id='bookWidgetErrWrapper']/div/div[2]/div/ul/li/button")]
        private IWebElement divErrorAirport;

        [FindsBy(How = How.XPath, Using = ".//*[@id='warningFocus']/p")]
        private IWebElement divErrorFlightNotFound;

        [FindsBy(How = How.XPath, Using = ".//*[@id='tripSummaryError']/div/div[2]/p")]
        private IWebElement divErrorNotInformation;

        [FindsBy(How = How.XPath, Using = ".//*[@id='pass_block']/div[1]/div/div[2]")]
        private IWebElement divErrorPassForm;

        [FindsBy(How = How.Id, Using = "errorContainerWrapper0")]
        private IWebElement divErrorInvalidYearOfBirthPassenger;

        [FindsBy(How = How.XPath, Using = "//*[@id='paymentInfoErrorHolder']/div/p")]
        private IWebElement divErrorInvalidCardNumber;

        #endregion

        #region Buttons

        //[FindsBy(How = How.Id, Using = "fm_rw_0_col_0")]
        [FindsBy(How = How.XPath, Using = ".//*[@id='fm_rw_0_col_0']")]
        private IWebElement buttonEconomyClass;

        [FindsBy(How = How.Id, Using = "tripSummary")]
        private IWebElement buttonNextStepAfterSelectClass;

        [FindsBy(How = How.Id, Using = "ts_submit")]
        private IWebElement buttonConfirmFlightInfo;

        [FindsBy(How = How.Id, Using = "pass_next")]
        private IWebElement buttonNextPass;

        [FindsBy(How = How.Id, Using = "paxReviewPurchaseBtn")]
        private IWebElement buttonNextContact;

        [FindsBy(How = How.Id, Using = "calendarClick")]
        private IWebElement buttonSelectDates;

        [FindsBy(How = How.XPath, Using = ".//*[@id='bookingWidgetCalenderReturn']/div/div/a[2]/span")]
        private IWebElement buttonReturnCalendarNextMonth;

        [FindsBy(How = How.XPath, Using = ".//*[@id='bookingWidgetCalenderDept']/div/div/a[2]/span")]
        private IWebElement buttonDeptCalendarNextMonth;

        [FindsBy(How = How.Id, Using = "findFlightsSubmit")]
        private IWebElement buttonFindMyFlights;

        [FindsBy(How = How.XPath, Using = "//button[. = 'Find address']")]
        private IWebElement buttonFindAdress;

        [FindsBy(How = How.Id, Using = "continue_button")]
        private IWebElement buttonMakePayments;

        #endregion

        #region Passenger Elements

        [FindsBy(How = How.Id, Using = "prefix0")]
        private IWebElement selectPassengerTitle;

        [FindsBy(How = How.Id, Using = "firstName0")]
        private IWebElement passengerFirstName;

        [FindsBy(How = How.Id, Using = "lastName0")]
        private IWebElement passengerLastName;

        [FindsBy(How = How.Id, Using = "day0")]
        private IWebElement selectPassengerDayOfBirth;

        [FindsBy(How = How.Id, Using = "month0")]
        private IWebElement selectPassengerMonthOfBirth;

        [FindsBy(How = How.Id, Using = "year0")]
        private IWebElement selectPassengerYearOfBirth;

        [FindsBy(How = How.Id, Using = "gender0")]
        private IWebElement passengerMaleGenderRadio;

        [FindsBy(How = How.Id, Using = "gender10")]
        private IWebElement passengerFemaleGenderRadio;

        [FindsBy(How = How.Id, Using = "email")]

        private IWebElement passengerEmailAdress;

        [FindsBy(How = How.Id, Using = "reEmail")]
        private IWebElement confirmPassengerEmailAdress;

        [FindsBy(How = How.Id, Using = "deviceType")]
        private IWebElement selectPassengerPhoneType;

        [FindsBy(How = How.Id, Using = "countryCode0")]
        private IWebElement selectPassengerNumberLocal;

        [FindsBy(How = How.Id, Using = "telephoneNumber0")]
        private IWebElement passengerContactNumber;

        [FindsBy(How = How.Id, Using = "notLogInAccNumber")]
        private IWebElement passengerCardNumber;

        [FindsBy(How = How.Id, Using = "notLogInFirstName")]
        private IWebElement passengerCardFirstname;

        [FindsBy(How = How.Id, Using = "notLogInLastName")]
        private IWebElement passengerCardLastname;

        [FindsBy(How = How.Id, Using = "notLogInExpMonth")]
        private IWebElement selectPassengerCardMonthExpire;

        [FindsBy(How = How.Id, Using = "notLogInExpYear")]
        private IWebElement selectPassengerCardYearExpire;

        [FindsBy(How = How.Id, Using = "cvv")]
        private IWebElement passengerCardSecurityNumber;

        [FindsBy(How = How.Id, Using = "countryCode")]
        private IWebElement selectPassengerCountry;

        [FindsBy(How = How.Id, Using = "houseNo")]
        private IWebElement passengerHouseNameOrNumber;

        [FindsBy(How = How.Id, Using = "qasPostal")]
        private IWebElement passengerZipCode;

        [FindsBy(How = How.XPath, Using = ".//*[@id='addressList']/li/span[2]")]
        private IWebElement passengerFullAdress;

        #endregion

        #region Other

        //*[@id="flightResults"] для окна всплывающего
        [FindsBy(How = How.Id, Using = "flightResults")]
        private IWebElement WaitWindow;

        [FindsBy(How = How.Id, Using = "termsAndConditionCheck")]
        private IWebElement agreeTermsAndConditions;

        #endregion


        private IWebDriver driver;
        private SelectElement select;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void FindDates(string fromAirport, string toAirport)
        {
            inputFromAirport.SendKeys(fromAirport);
            inputToAirport.SendKeys(toAirport);
            buttonSelectDates.Click();
        }

        public void SetDateDept()
        {
            if (DateTime.Now.AddDays(7) > DateTime.Now)
            {
                buttonDeptCalendarNextMonth.Click();
            }
            string date = (DateTime.Now.AddDays(7)).Day.ToString();
            foreach (var c in deptCalendar.FindElements(By.TagName("tr")))
            {
                foreach (var d in c.FindElements(By.TagName("td")))
                {
                    if (d.Text.Contains(date))
                    {
                        d.Click();
                        return;
                    }
                }
            }
        }
        public void SetDateReturn()
        {
            if (DateTime.Now.AddDays(7) > DateTime.Now)
            {
                buttonReturnCalendarNextMonth.Click();
            }
            string date = (DateTime.Now.AddDays(7)).Day.ToString();
            foreach (var c in returnCalendar.FindElements(By.TagName("tr")))
            {
                foreach (var d in c.FindElements(By.TagName("td")))
                {
                    if (d.Text.Contains(date))
                    {
                        d.Click();
                        return;
                    }
                }
            }
        }

        public void FindMyFlights()
        {
            buttonFindMyFlights.Submit();
        }

        public void SelectEconomDept()
        {
            buttonEconomyClass.Click();
            //Thread.Sleep(5000);
        }
        public void SelectEconomReturn()
        {
            Thread.Sleep(5000);
            buttonEconomyClass.Click();
            Thread.Sleep(5000);
        }

        public void ConfirmSelectClass()
        {
            Thread.Sleep(5000);
            buttonNextStepAfterSelectClass.Click();
        }

        public void ConfirmFlightInfo()
        {
            buttonConfirmFlightInfo.Submit();
        }

        #region SetPassengerInfo

        #region Adult
        public void SetPassengerTitle(string title)
        {
            select = new SelectElement(selectPassengerTitle);
            select.SelectByText(title);
        }
        public void SetPassengerFirstname(string firstname)
        {
            passengerFirstName.SendKeys(firstname);
        }
        public void SetPassengerLastname(string lastname)
        {
            passengerLastName.SendKeys(lastname);
        }
        public void SetPassengerDayOfBirth(string dayOfBirth)
        {
            select = new SelectElement(selectPassengerDayOfBirth);
            select.SelectByText(dayOfBirth);
        }
        public void SetPassengerMonthOfBirth(string monthOfBirth)
        {
            select = new SelectElement(selectPassengerMonthOfBirth);
            select.SelectByText(monthOfBirth);
        }
        public void SetPassengerYearOfBirth(string year)
        {
            select = new SelectElement(selectPassengerYearOfBirth);
            select.SelectByText(year);
        }
        public void SetPassengerGender(string gender)
        {
            if (gender == "Male")
            {
                passengerMaleGenderRadio.Click();
            } 
            else if(gender == "Female")
            {
                passengerFemaleGenderRadio.Click();
            }
        }
        public void ConfirmPassInfo()
        {
            buttonNextPass.Click();
        }
        #endregion

        #region Contact Information
        public void SetPassengerEmail(string email)
        {
            int start = DateTime.Now.Second;
            while(!passengerEmailAdress.Displayed)
            {
                if (DateTime.Now.Second - start == 30)
                {
                    throw new Exception("Timeout");
                }
            }
            passengerEmailAdress.SendKeys(email);
        }
        public void ConfirmPassengerEmail(string email)
        {
            confirmPassengerEmailAdress.SendKeys(email);
        }
        public void SetPassengerPhoneType(string type)
        {
            select = new SelectElement(selectPassengerPhoneType);
            select.SelectByText(type);
        }
        public void SetPassengerPhoneLocale(string locale)
        {
            select = new SelectElement(selectPassengerNumberLocal);
            select.SelectByText(locale);
        }
        public void SetPassengerPhoneNumber(string number)
        {
            passengerContactNumber.SendKeys(number);
        }
        public void ConfirmContactInfo()
        {
            buttonNextContact.Click();
        }
        #endregion

        #region Payment
        public void SetPassengerCardNumber(string cardNumber)
        {
            passengerCardNumber.SendKeys(cardNumber);
        }
        public void SetPassengerCardFirstname(string firstname)
        {
            passengerCardFirstname.SendKeys(firstname);
        }
        public void SetPassengerCardLastname(string lastname)
        {
            passengerCardLastname.SendKeys(lastname);
        }
        public void SetPassengerCardMonthExpire(string month)
        {
            select = new SelectElement(selectPassengerCardMonthExpire);
            select.SelectByText(month);
        }
        public void SetPassengerCardYearExpire(string year)
        {
            select = new SelectElement(selectPassengerCardYearExpire);
            select.SelectByText(year);
        }
        public void SetPassengerCardSecurityNumber(string securityNumber)
        {
            passengerCardSecurityNumber.SendKeys(securityNumber);
        }
        #endregion

        #region Billing adress
        public void SetPassengerCountry(string country)
        {
            select = new SelectElement(selectPassengerCountry);
            select.SelectByText(country);
        }
        public void SetPassengerHouseNameOrNumber(string houseNameOrNumber)
        {
            passengerHouseNameOrNumber.SendKeys(houseNameOrNumber);
        }
        public void SetPassengerZipCode(string zipCode)
        {
            passengerZipCode.SendKeys(zipCode);
        }
        public void FindAdress()
        {
            buttonFindAdress.Click();
        }
        public bool GetAdress(string fullAdress)
        {
            return passengerFullAdress.Text == fullAdress;
        }
        public void ConfirmAdress()
        {
            passengerFullAdress.Click();
        }
        #endregion

        #endregion

        public void AgreeTermsAndCondition()
        {
            agreeTermsAndConditions.Click();
        }
        public void ConfirmPayments()
        {
            buttonMakePayments.Click();
        }

        #region Error messages

        public bool GetErrorAirport(string errorMessage)
        {
            return divErrorAirport.Text == errorMessage;
        }
        public bool GetErrorFlightNotFound(string message)
        {
            return divErrorFlightNotFound.Text == message;
        }
        public bool GetErrorEmptyPassInfo(string[] message)
        {
            bool result = false;
            int index = 2;
            IWebElement tmp = driver.FindElement(By.XPath("//*[@id='pass_block']/div[1]/div/div[2]/div"));
            result = divErrorPassForm.FindElement(By.TagName("p")).Text == message[0];
            result = tmp.FindElement(By.TagName("h4")).Text == message[1];
            tmp = driver.FindElement(By.XPath("//*[@id='pass_block']/div[1]/div/div[2]/div/ul"));
            if (result == false)
            {
                return result;
            }
            foreach (var li in tmp.FindElements(By.TagName("li")))
            {
                result = li.Text == message[index];
                index++;
                if (result == false)
                {
                    return result;
                }
            }
            return result;
        }
        public bool GetErrorNotInformation(string message)
        {
            return divErrorNotInformation.Text == message;
        }
        public bool GetErrorInvalidYearOfBirth(string message)
        {
            return divErrorInvalidYearOfBirthPassenger.Text == message;
        }
        public bool GetErrorInvalidCardNumber(string message)
        {
            return divErrorInvalidCardNumber.Text == message;
        }

        #endregion
    }
}
