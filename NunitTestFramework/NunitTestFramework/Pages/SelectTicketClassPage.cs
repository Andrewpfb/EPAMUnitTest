using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace NunitTestFramework.Pages
{
    /// <summary>
    /// Класс страницы для выбора класса билета\билетов.
    /// </summary>
    public class SelectTicketClassPage : BasePage
    {
        #region Buttons

        /// <summary>
        /// Кнопка для выбора эконом-класса.
        /// </summary>
        [FindsBy(How = How.XPath, Using = ".//*[@id='fm_rw_0_col_0']")]
        private IWebElement buttonEconomyClass;

        /// <summary>
        /// Кнопка для подтверждения выбора класса билета.
        /// </summary>
        [FindsBy(How = How.Id, Using = "tripSummary")]
        private IWebElement buttonNextStepAfterSelectClass;

        #endregion

        #region Errors

        /// <summary>
        /// Элемент, отображающий ошибку о неполной информации о полете (например не выбран класс билета для возвращения).
        /// </summary>
        [FindsBy(How = How.XPath, Using = ".//*[@id='tripSummaryError']/div/div[2]/p")]
        private IWebElement divErrorNotInformation;

        #endregion

        private IWebDriver driver;

        public SelectTicketClassPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public bool GetTicketsTable()
        {
            try
            {
                Utils.WaitElements.WaitShowElement(By.XPath("//*[@id='fareModule']/div[2]"), driver);
                return true;
            }
            catch
            {
                throw new System.Exception("Element not found");
            }
        }
        public void SelectEconomDept()
        {
            buttonEconomyClass.Click();
            //Ожидаем появления и исчезания окна прогресса.
            Utils.WaitElements.WaitShowElement(By.CssSelector("#dialog2>div"), driver);
            Utils.WaitElements.WaitHideElement(By.CssSelector("#dialog2>div"), driver);
        }
        public void SelectEconomReturn()
        {
            buttonEconomyClass.Click();
        }
        public ConfirmTripSummaryPage ConfirmSelectClass()
        {
            buttonNextStepAfterSelectClass.Click();
            return new ConfirmTripSummaryPage(driver);
        }

        public bool GetErrorNotInformation(string message)
        {
            return divErrorNotInformation.Text == message;
        }
    }
}
