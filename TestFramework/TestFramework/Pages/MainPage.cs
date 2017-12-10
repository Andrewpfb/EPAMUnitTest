using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace TestFramework.Pages
{
    public class MainPage
    {
        private const string BASE_URL = "https://www.virginatlantic.com";

        [FindsBy(How = How.XPath, Using = ".//*[@id='origin']")]
        private IWebElement inputFromAirport;

        [FindsBy(How = How.XPath, Using = ".//*[@id='destination']")]
        private IWebElement inputToAirport;

        [FindsBy(How = How.XPath, Using = ".//*[@id='calendarClick']")]
        private IWebElement buttonSelectDates;

        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            System.Console.WriteLine("Main page opened");
        }

        public void FindDates(string fromAirport,string toAirport)
        {
            inputFromAirport.SendKeys(fromAirport);
            inputToAirport.SendKeys(toAirport);
            buttonSelectDates.Click();
        }
    }
}
