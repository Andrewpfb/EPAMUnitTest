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

        [FindsBy(How = How.XPath, Using = ".//*[@id='bookWidgetErrWrapper']/div/div[2]/div/ul/li/button")]
        private IWebElement divErrorAirport;

        [FindsBy(How = How.XPath, Using = ".//*[@id='bookingWidgetCalenderDept']/div/table/tbody")]
        private IWebElement divCalendar;

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

        public void FindDates(string fromAirport, string toAirport)
        {
            inputFromAirport.SendKeys(fromAirport);
            inputToAirport.SendKeys(toAirport);
            buttonSelectDates.Click();
        }

        public bool GetErrorAirport(string errorMessage)
        {
            return divErrorAirport.Text == errorMessage;
        }

        public void SetDates()
        {
            foreach (var c in divCalendar.FindElements(By.TagName("tr")))
            {
               // foreach (var d in c.FindElements(By.TagName("td")))
              //  {
                    string tmp = c.Text;
                    System.Console.WriteLine(tmp);
               // }
            }

        }
    }
}
