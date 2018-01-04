using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace NunitTestFramework.Pages
{
    /// <summary>
    /// Класс главной страницы сайта.
    /// </summary>
    public class MainPage : BasePage
    {
        private const string BaseUrl = "https://www.virginatlantic.com";

        #region Route Elements

        /// <summary>
        /// Элемент для выбора параметров полета из ранее сделанного заказа.
        /// </summary>
        [FindsBy(How = How.Id, Using = "preferenceItinId")]
        private IWebElement selectRecentSearch;

        /// <summary>
        /// Элемент для ввода аэропорта вылета.
        /// </summary>
        [FindsBy(How = How.Id, Using = "origin")]
        private IWebElement inputFromAirport;

        /// <summary>
        /// Элемент для ввода аэропорта прилета.
        /// </summary>
        [FindsBy(How = How.Id, Using = "destination")]
        private IWebElement inputToAirport;

        /// <summary>
        /// Элемент для выбора типа полета. В одну сторону, с возвращением, с пересадками.
        /// </summary>
        [FindsBy(How = How.Id, Using = "returndropdown")]
        private IWebElement selectTypeWay;

        #endregion

        #region Passenger's count info Elements

        /// <summary>
        /// Элемент для выбора количества взрослых в заказе.
        /// </summary>
        [FindsBy(How = How.Id, Using = "adult")]
        private IWebElement selectAdultsCount;

        /// <summary>
        /// Элемент для выбора количества детей в заказе.
        /// </summary>
        [FindsBy(How = How.Id, Using = "children")]
        private IWebElement selectChildrenCount;

        #endregion

        #region Date Elements

        /// <summary>
        /// Элемент (календарь) для выбора даты вылета.
        /// </summary>
        [FindsBy(How = How.XPath, Using = ".//*[@id='bookingWidgetCalenderDept']/div/table/tbody")]
        private IWebElement deptCalendar;

        /// <summary>
        /// Элемент (календарь) для выбора даты прилета.
        /// </summary>
        [FindsBy(How = How.XPath, Using = ".//*[@id='bookingWidgetCalenderReturn']/div/table/tbody")]
        private IWebElement returnCalendar;
        #endregion

        #region Errors Elements

        /// <summary>
        /// Элемент, отображающий ошибку об отсутствии аэропорта (например неправильно введено название).
        /// </summary>
        [FindsBy(How = How.XPath, Using = ".//*[@id='bookWidgetErrWrapper']/div/div[2]/div/ul/li/button")]
        private IWebElement divErrorAirport;

        /// <summary>
        /// Элемент, отображающий ошибку о количестве пассажиров.
        /// </summary>
        [FindsBy(How = How.XPath, Using = ".//*[@id='bookingWidgetPaxAndPay']/p")]
        private IWebElement divErrorPassengersCount;

        /// <summary>
        /// Элемент, отображающий ошибку об отсутствии полетов для выбранных параметров.
        /// </summary>
        [FindsBy(How = How.XPath, Using = ".//*[@id='warningFocus']/p")]
        private IWebElement divErrorFlightNotFound;

        #endregion

        #region Buttons

        /// <summary>
        /// Кнопка для открытия главной страницы.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "virginAtlanticLogo")]
        private IWebElement buttonGoToMain;

        /// <summary>
        /// Кнопка для отображения календаря для выбора дат.
        /// </summary>
        [FindsBy(How = How.Id, Using = "calendarClick")]
        private IWebElement buttonSelectDates;

        /// <summary>
        /// Кнопка для выбора следующего месяца на календаре вылета.
        /// </summary>
        [FindsBy(How = How.XPath, Using = ".//*[@id='bookingWidgetCalenderReturn']/div/div/a[2]/span")]
        private IWebElement buttonReturnCalendarNextMonth;

        /// <summary>
        /// Кнопка для выбора следующего месяца на календаре прилета.
        /// </summary>
        [FindsBy(How = How.XPath, Using = ".//*[@id='bookingWidgetCalenderDept']/div/div/a[2]/span")]
        private IWebElement buttonDeptCalendarNextMonth;

        /// <summary>
        /// Кнопка для поиска билетов на выбранную дату\даты.
        /// </summary>
        [FindsBy(How = How.Id, Using = "findFlightsSubmit")]
        private IWebElement buttonFindMyFlights;

        #endregion

        private IWebDriver driver;
        private SelectElement select;

        public MainPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            driver.Url = BaseUrl;
        }

        public bool SearchOrderInRecentSearch(string recentSearchString)
        {
            try
            {
                Utils.WaitElements.WaitShowElement(By.Id("preferenceItinId"), driver);
            }
            catch
            {
                throw new Exception("Element not found");
            }
            select = new SelectElement(selectRecentSearch);
            foreach (var option in select.Options)
            {
                if (option.Text == recentSearchString)
                {
                    return true;
                }
            }
            return false;
        }
        public void SetFromAirport(string fromAirport)
        {
            inputFromAirport.SendKeys(fromAirport);
        }
        public void SetToAirport(string toAirport)
        {
            inputToAirport.SendKeys(toAirport);
        }
        public void SetTypeWay(string typeWay)
        {
            select = new SelectElement(selectTypeWay);
            select.SelectByText(typeWay);
        }
        public void FindDates()
        {
            buttonSelectDates.Click();
        }

        public void SetDateDept(DateTime departmentDate)
        {
            //Календарь сверстан в виде таблицы. Поэтому выбор даты происходит путем последовательного просмотра
            //ячеек таблицы до ячейки с днем вылета. Когда ячейка найдена,
            //происходит нажатие на неё и метода завершает работу.
            string date = departmentDate.Day.ToString();
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
        public void SetDeptNextMonth()
        {
            buttonDeptCalendarNextMonth.Click();
        }
        public void SetDateReturn(DateTime returnDate)
        {
            //Календарь сверстан в виде таблицы. Поэтому выбор даты происходит путем последовательного просмотра
            //ячеек таблицы до ячейки с днем прилета. Когда ячейка найдена,
            //происходит нажатие на неё и метода завершает работу.
            string date = returnDate.Day.ToString();
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
        public void SetReturnNextMonth()
        {
            buttonReturnCalendarNextMonth.Click();
        }

        public void SetAdultsCount(string adultsCount)
        {
            select = new SelectElement(selectAdultsCount);
            select.SelectByText(adultsCount);
        }
        public void SetChildrenCount(string childrenCount)
        {
            select = new SelectElement(selectChildrenCount);
            select.SelectByText(childrenCount);
        }

        public SelectTicketClassPage FindMyFlights()
        {
            buttonFindMyFlights.Submit();
            return new SelectTicketClassPage(driver);
        }

        #region Error messages

        public bool GetErrorAirport(string errorMessage)
        {
            return divErrorAirport.Text == errorMessage;
        }
        public bool GetErrorPassengersCount(string message)
        {
            return divErrorPassengersCount.Text == message;
        }
        public bool GetErrorFlightNotFound(string message)
        {
            return divErrorFlightNotFound.Text == message;
        }

        #endregion
    }
}
