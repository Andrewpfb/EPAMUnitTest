using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace NunitTestFramework.Pages
{
    /// <summary>
    /// Класс страницы подтверждения информации о полете.
    /// </summary>
    public class ConfirmTripSummaryPage : BasePage
    {
        #region Buttons

        /// <summary>
        /// Кнопка для подтверждения инфомации о полете.
        /// </summary>
        [FindsBy(How = How.Id, Using = "ts_submit")]
        private IWebElement buttonConfirmFlightInfo;

        #endregion

        private IWebDriver driver;

        public ConfirmTripSummaryPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public PassengerInfoPages ConfirmFlightInfo()
        {
            buttonConfirmFlightInfo.Submit();
            return new PassengerInfoPages(driver);
        }
    }
}
