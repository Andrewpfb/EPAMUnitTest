using OpenQA.Selenium;


namespace TestFramework.Steps
{
    public class Steps
    {
        IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void FindDates(string fromAirport, string toAirport)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.FindDates(fromAirport, toAirport);
        }
    }
}
