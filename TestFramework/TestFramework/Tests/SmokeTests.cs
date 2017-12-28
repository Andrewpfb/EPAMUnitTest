using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Threading;

namespace TestFramework.Tests
{
    /// <summary>
    /// Сводное описание для SmokeTest
    /// </summary>
    [TestClass]
    public class SmokeTests
    {
        private static Steps.Steps steps = new Steps.Steps();

        #region Airports info
        private const string FROM_AIRPORT = "New York, (JFK) US";
        private const string TO_AIRPORT = "London Heathrow, (LHR) GB";
        private const string INVALID_AIRPORT = "New Yorc";
        private const string SECOND_TO_AIRPORT_SOME_CITY = "New York Area Airports, (NYC) US";
        #endregion

        #region Passenger Info
        private const string PASSENGER_TITLE = "Dr";
        private const string PASSENGER_FIRSTNAME = "James";
        private const string PASSENGER_LASTNAME = "Wilson";
        private const int PASSENGER_DAY_OF_BIRTH = 29;
        private const int PASSENGER_MONTH_OF_BIRTH = 09; //September.
        private int PASSENGER_YEAR_OF_BIRTH_INVALID = (DateTime.Now.Year - 15);
        private int PASSENGER_YEAR_OF_BIRTH_VALID = (DateTime.Now.Year - 25);
        private const string PASSENGER_GENDER = "Male";
        #endregion

        #region Error Message
        private const string MISSING_AIRPORT_ERROR_MESSAGE = "I'm flying From airport";
        private const string MISSING_ROUTES_ERROR_MESSAGE = "No results were found for your search, please check your route. Try changing your cities, dates or any other search criteria. #101639R";
        private const string MISSING_INFORMATION_ERROR_MESSAGE = "Oops, looks like some information that we need is missing. Please select a flight to proceed further";
        private string[] MISSING_INFORMATION_PASSENGER = new string[]
        {
            "Oops, looks like some information that we need is missing. Please check the following:",
            "ADULT ",
            "Title",
            "First Name (as per passport)",
            "Last Name (as per passport)",
            "Day",
            "Month",
            "Year"
        };
        private const string INVALID_YEAR_OF_BIRTH = "Adult passengers must be above 16 years old on the date of departure";
        #endregion

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            steps.InitBrowser();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            steps.CloseBrowser();
        }

        #region Дополнительные атрибуты тестирования
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestInvalidAirport()
        {
            steps.InitBrowser();
            steps.FindDates(INVALID_AIRPORT, TO_AIRPORT);
            Assert.IsTrue(steps.GetErrorAirport(MISSING_AIRPORT_ERROR_MESSAGE));
        }

        [TestMethod]
        public void TestInvalidPlace()
        {
            steps.InitBrowser();
            steps.FindDates(FROM_AIRPORT, SECOND_TO_AIRPORT_SOME_CITY);
            steps.SetDateDept();
            steps.SetDateReturn();
            steps.GetMyFlights();
            Assert.IsTrue(steps.GetErrorFindMyFlights(MISSING_ROUTES_ERROR_MESSAGE));
        }

        [TestMethod]
        public void TestSelectOneWay()
        {
            steps.InitBrowser();
            steps.FindDates(FROM_AIRPORT, TO_AIRPORT);
            steps.SetDateDept();
            steps.SetDateReturn();
            steps.GetMyFlights();
            steps.SelectEconomyDept();
            steps.ConfirmSelectClass();
            Assert.IsTrue(steps.GetErrorNotInformation(MISSING_INFORMATION_ERROR_MESSAGE));
        }

        [TestMethod]
        public void TestPassInfo()
        {
            steps.InitBrowser();
            steps.FindDates(FROM_AIRPORT, TO_AIRPORT);
            steps.SetDateDept();
            steps.SetDateReturn();
            steps.GetMyFlights();
            steps.SelectEconomyDept();
            steps.SelectEconomyReturn();
            steps.ConfirmSelectClass();
            steps.ConfirmFlightInfo();
            steps.ConfirmPassInfo();
            Assert.IsTrue(steps.GetErrorEmptyPassInfo(MISSING_INFORMATION_PASSENGER));
        }

        [TestMethod]
        public void TestPassAge()
        {
            steps.InitBrowser();
            steps.FindDates(FROM_AIRPORT, TO_AIRPORT);
            steps.SetDateDept();
            steps.SetDateReturn();
            steps.GetMyFlights();
            steps.SelectEconomyDept();
            steps.SelectEconomyReturn();
            steps.ConfirmSelectClass();
            steps.ConfirmFlightInfo();
            steps.SelectInvalidPassengerDateOfBirth(new DateTime(
                    PASSENGER_YEAR_OF_BIRTH_INVALID,
                    PASSENGER_MONTH_OF_BIRTH,
                    PASSENGER_DAY_OF_BIRTH));
            Assert.IsTrue(steps.GetErrorInvalidYearOfBirth(INVALID_YEAR_OF_BIRTH));
        }

        [TestMethod]
        public void TestPassCardValidityAge()
        {
            steps.InitBrowser();
            steps.FindDates(FROM_AIRPORT, TO_AIRPORT);
            steps.SetDateDept();
            steps.SetDateReturn();
            steps.GetMyFlights();
            steps.SelectEconomyDept();
            steps.SelectEconomyReturn();
            steps.ConfirmSelectClass();
            steps.ConfirmFlightInfo();
            steps.SelectInvalidPassengerDateOfBirth(new DateTime(
                    PASSENGER_YEAR_OF_BIRTH_VALID,
                    PASSENGER_MONTH_OF_BIRTH,
                    PASSENGER_DAY_OF_BIRTH));
            Assert.IsTrue(steps.GetErrorInvalidYearOfBirth(INVALID_YEAR_OF_BIRTH));
        }
    }
}
