using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace NunitTestFramework.Pages
{
    public class ConfirmTripSummaryPage
    {
        #region Buttons

        /// <summary>
        /// Кнопка для подтверждения инфомации о полете.
        /// </summary>
        [FindsBy(How = How.Id, Using = "ts_submit")]
        private IWebElement buttonConfirmFlightInfo;

        #endregion

        private IWebDriver driver;

        public ConfirmTripSummaryPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public PassengerInfoPages ConfirmFlightInfo()
        {
            buttonConfirmFlightInfo.Submit();
            return new PassengerInfoPages(driver);
        }
    }
}
