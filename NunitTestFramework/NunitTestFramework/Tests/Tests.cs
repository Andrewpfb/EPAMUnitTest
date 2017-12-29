using System;
using System.Globalization;
using System.Threading;
using NUnit.Framework;

namespace NunitTestFramework.Tests
{
    [TestFixture]
    public class Tests
    {
        private static Steps.Steps steps = new Steps.Steps();
        private static Businnes_Objects.PassengerInfo passenger;

        #region Airports info
        private const string FROM_AIRPORT = "New York, (JFK) US";
        private const string TO_AIRPORT = "London Heathrow, (LHR) GB";
        private const string INVALID_AIRPORT = "New Yorc";
        private const string SECOND_TO_AIRPORT_SOME_CITY = "New York Area Airports, (NYC) US";
        #endregion

        #region Date of Birth
        private const int PASSENGER_DAY_OF_BIRTH = 29;
        private const int PASSENGER_MONTH_OF_BIRTH = 09; //September.
        private int PASSENGER_YEAR_OF_BIRTH_INVALID = (DateTime.Now.Year - 15);
        private int PASSENGER_YEAR_OF_BIRTH_VALID = (DateTime.Now.Year - 25);
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
        private const string INVALID_YEAR_OF_BIRTH_ERROR_MESSAGE = "Adult passengers must be above 16 years old on the date of departure";
        private const string INVALID_CARD_NUMBER_MESSAGE = "Your card number doesn't seem to be correct. #4042R";
        #endregion
 

        [SetUp]
        public static void Init()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            steps.InitBrowser();
            passenger = new Businnes_Objects.PassengerInfo();
        }

        [TearDown]
        public static void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void TestInvalidAirport()
        {
            steps.FindDates(INVALID_AIRPORT, TO_AIRPORT);
            Assert.IsTrue(steps.GetErrorAirport(MISSING_AIRPORT_ERROR_MESSAGE));
        }

        [Test]
        public void TestInvalidPlace()
        {
            steps.FindDates(FROM_AIRPORT, SECOND_TO_AIRPORT_SOME_CITY);
            steps.SetDateDept();
            steps.SetDateReturn();
            steps.GetMyFlights();
            Assert.IsTrue(steps.GetErrorFindMyFlights(MISSING_ROUTES_ERROR_MESSAGE));
        }

        [Test]
        public void TestSelectOneWay()
        {
            steps.FindDates(FROM_AIRPORT, TO_AIRPORT);
            steps.SetDateDept();
            steps.SetDateReturn();
            steps.GetMyFlights();
            steps.SelectEconomyDept();
            steps.ConfirmSelectClass();
            Assert.IsTrue(steps.GetErrorNotInformation(MISSING_INFORMATION_ERROR_MESSAGE));
        }

        [Test]
        public void TestPassInfo()
        {
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

        [Test]
        public void TestPassAge()
        {
            steps.FindDates(FROM_AIRPORT, TO_AIRPORT);
            steps.SetDateDept();
            steps.SetDateReturn();
            steps.GetMyFlights();
            steps.SelectEconomyDept();
            steps.SelectEconomyReturn();
            steps.ConfirmSelectClass();
            steps.ConfirmFlightInfo();
            passenger.DateOfBirth = new DateTime(PASSENGER_YEAR_OF_BIRTH_INVALID, PASSENGER_MONTH_OF_BIRTH, PASSENGER_DAY_OF_BIRTH);
            steps.SelectInvalidPassengerDateOfBirth(passenger.DateOfBirth);
            Assert.IsTrue(steps.GetErrorInvalidYearOfBirth(INVALID_YEAR_OF_BIRTH_ERROR_MESSAGE));
        }

        [Test]
        public void TestPassFindAdress()
        {
            steps.FindDates(FROM_AIRPORT, TO_AIRPORT);
            steps.SetDateDept();
            steps.SetDateReturn();
            steps.GetMyFlights();
            steps.SelectEconomyDept();
            steps.SelectEconomyReturn();
            steps.ConfirmSelectClass();
            steps.ConfirmFlightInfo();
            steps.SetPassengerFullInfo(passenger);
            Assert.IsTrue(steps.GetPassengerFullAdress(passenger.FullAdress));
        }

        [Test]
        public void TestPassInvalidCardNumber()
        {
            steps.FindDates(FROM_AIRPORT, TO_AIRPORT);
            steps.SetDateDept();
            steps.SetDateReturn();
            steps.GetMyFlights();
            steps.SelectEconomyDept();
            steps.SelectEconomyReturn();
            steps.ConfirmSelectClass();
            steps.ConfirmFlightInfo();
            steps.SetPassengerFullInfo(passenger);
            steps.ConfirmPassengerAdress();
            steps.AgreeTermsAndConditions();
            steps.ConfirmPayments();
            Assert.IsTrue(steps.GetErrorInvalidCardNumber(INVALID_CARD_NUMBER_MESSAGE));
        }
    }
}