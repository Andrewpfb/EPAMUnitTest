using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TestFramework.Utils;

namespace TestFramework.Pages
{
    public class MainPage
    {
        private const string BASE_URL = "https://www.virginatlantic.com";

        #region Airports Elements

        [FindsBy(How = How.XPath, Using = ".//*[@id='origin']")]
        private IWebElement inputFromAirport;

        [FindsBy(How = How.XPath, Using = ".//*[@id='destination']")]
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

        [FindsBy(How = How.XPath, Using = ".//*[@id='errorContainerWrapper0']")]
        private IWebElement divErrorInvalidYearOfBirthPassenger;

        #endregion

        #region Buttons

        [FindsBy(How = How.XPath, Using = ".//*[@id='fm_rw_0_col_0']")]
        private IWebElement buttonEconomyClass;

        [FindsBy(How = How.XPath, Using = ".//*[@id='tripSummary']")]
        private IWebElement buttonNextStepAfterSelectClass;

        [FindsBy(How = How.XPath, Using = ".//*[@id='ts_submit']")]
        private IWebElement buttonConfirmFlightInfo;

        [FindsBy(How = How.XPath, Using = ".//*[@id='pass_next']")]
        private IWebElement buttonNextPass;

        [FindsBy(How = How.XPath, Using = ".//*[@id='calendarClick']")]
        private IWebElement buttonSelectDates;

        [FindsBy(How = How.XPath, Using = ".//*[@id='bookingWidgetCalenderReturn']/div/div/a[2]/span")]
        private IWebElement buttonReturnCalendarNextMonth;

        [FindsBy(How = How.XPath, Using = ".//*[@id='bookingWidgetCalenderDept']/div/div/a[2]/span")]
        private IWebElement buttonDeptCalendarNextMonth;

        [FindsBy(How = How.XPath, Using = ".//*[@id='findFlightsSubmit']")]
        private IWebElement buttonFindMyFlights;

        #endregion

        #region Passenger Elements

        [FindsBy(How = How.XPath, Using = ".//*[@id='prefix0']")]
        private IWebElement selectPassengerTitle;

        [FindsBy(How = How.XPath, Using = ".//*[@id='firstName0']")]
        private IWebElement passengerFirstName;

        [FindsBy(How = How.XPath, Using = ".//*[@id='lastName0']")]
        private IWebElement passengerLastName;

        [FindsBy(How = How.XPath, Using = ".//*[@id='day0']")]
        private IWebElement selectPassengerDayOfBirth;

        [FindsBy(How = How.XPath, Using = ".//*[@id='month0']")]
        private IWebElement selectPassengerMonthOfBirth;

        [FindsBy(How = How.XPath, Using = ".//*[@id='year0']")]
        private IWebElement selectPassengerYearOfBirth;

        [FindsBy(How = How.XPath, Using = ".//*[@id='gender10']")]
        private IWebElement passengerMaleGenderRadio;

        #endregion

        private IWebDriver driver;
        private WebDriverWait wait;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Utils.WriteFile.Write("Main page opened");
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
            Thread.Sleep(5000);
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

        public void SelectInvalidPassengerDateOfBirth(DateTime dateOfBirth)
        {
            SelectElement select = new SelectElement(selectPassengerDayOfBirth);
            select.SelectByText(dateOfBirth.Day.ToString());
            select = new SelectElement(selectPassengerMonthOfBirth);
            select.SelectByText(dateOfBirth.ToString("MMMM"));
            select = new SelectElement(selectPassengerYearOfBirth);
            select.SelectByText(dateOfBirth.Year.ToString());
        }

        public void SetPassengerInfo()
        {

        }

        public void ConfirmPassInfo()
        {
            buttonNextPass.Click();
        }

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
            WriteFile.Write(divErrorPassForm.Text);
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
    }
}
