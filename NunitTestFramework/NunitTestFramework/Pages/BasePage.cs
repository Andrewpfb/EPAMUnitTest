using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace NunitTestFramework.Pages
{
    /// <summary>
    /// Базовый класс страниц.
    /// </summary>
    public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
    }
}
