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
        private static bool ReturnNextMonth;

        #region Airports info
        private const string FROM_AIRPORT = "New York, (JFK) US";
        private const string TO_AIRPORT = "London Heathrow, (LHR) GB";
        private const string INVALID_AIRPORT = "New Yorc";
        private const string SECOND_TO_AIRPORT_SOME_CITY = "New York Area Airports, (NYC) US";
        private const string RETURN = "Return";
        private const string ONE_WAY = "One way";
        private const string MULTI_CITY = "Multi city";
        #endregion

        #region Passengers count

        private const string ADULTS_COUNT = "9";
        private const string CHILDREN_COUNT = "7";

        #endregion

        #region Dates 
        private static DateTime Department_date = DateTime.Now.AddDays(7);
        private static DateTime Return_date = DateTime.Now.AddDays(8);

        private const int PASSENGER_DAY_OF_BIRTH = 29;
        private const int PASSENGER_MONTH_OF_BIRTH = 09; //September.
        private int Passenger_year_of_birth_invalid = (DateTime.Now.Year - 15);
        private int Passenger_year_of_birth_valid = (DateTime.Now.Year - 25);
        #endregion

        #region Error Message
        private const string MISSING_AIRPORT_ERROR_MESSAGE = "I'm flying From airport";
        private const string MISSING_ROUTES_ERROR_MESSAGE = "No results were found for your search, please check your route. Try changing your cities, dates or any other search criteria. #101639R";
        private const string INVALID_COUNTS_OF_PASSENGERS = "There are no reward seats found for your search. You might have better luck looking for a one way reward seat or by changing your dates. #101767R";
        private const string MISSING_INFORMATION_ERROR_MESSAGE = "Oops, looks like some information that we need is missing. Please select a flight to proceed further";
        private string[] Missing_information_passenger = new string[]
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
            ReturnNextMonth = Return_date.Year > Department_date.Year || Return_date.Month > Department_date.Month ? true : false;
            steps.InitBrowser();
            passenger = new Businnes_Objects.PassengerInfo();
            steps.InitMainPage();
        }

        [TearDown]
        public static void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void TestInvalidAirport()
        {
            steps.SetAirportsAndFindDates(INVALID_AIRPORT, TO_AIRPORT, RETURN);
            Assert.IsTrue(steps.GetErrorAirport(MISSING_AIRPORT_ERROR_MESSAGE));
        }

        [Test]
        public void TestInvalidPlace()
        {
            steps.SetAirportsAndFindDates(FROM_AIRPORT, SECOND_TO_AIRPORT_SOME_CITY, RETURN);
            steps.SetDateDept(Department_date);
            steps.SetDateReturn(Return_date, ReturnNextMonth);
            steps.GetMyFlights();
            Assert.IsTrue(steps.GetErrorFindMyFlights(MISSING_ROUTES_ERROR_MESSAGE));
        }

        [Test]
        public void TestSelectOneWay()
        {
            steps.SetAirportsAndFindDates(FROM_AIRPORT, TO_AIRPORT, RETURN);
            steps.SetDateDept(Department_date);
            steps.SetDateReturn(Return_date, ReturnNextMonth);
            steps.GetMyFlights();
            steps.SelectEconomyDept();
            steps.ConfirmSelectClass();
            Assert.IsTrue(steps.GetErrorNotInformation(MISSING_INFORMATION_ERROR_MESSAGE));
        }

        [Test]
        public void TestPassInfo()
        {
            steps.SetAirportsAndFindDates(FROM_AIRPORT, TO_AIRPORT, RETURN);
            steps.SetDateDept(Department_date);
            steps.SetDateReturn(Return_date, ReturnNextMonth);
            steps.GetMyFlights();
            steps.SelectEconomyDept();
            steps.SelectEconomyReturn();
            steps.ConfirmSelectClass();
            steps.ConfirmFlightInfo();
            steps.ConfirmPassInfo();
            Assert.IsTrue(steps.GetErrorEmptyPassInfo(Missing_information_passenger));
        }

        [Test]
        public void TestPassAge()
        {
            steps.SetAirportsAndFindDates(FROM_AIRPORT, TO_AIRPORT, RETURN);
            steps.SetDateDept(Department_date);
            steps.SetDateReturn(Return_date, ReturnNextMonth);
            steps.GetMyFlights();
            steps.SelectEconomyDept();
            steps.SelectEconomyReturn();
            steps.ConfirmSelectClass();
            steps.ConfirmFlightInfo();
            passenger.DateOfBirth = new DateTime(Passenger_year_of_birth_invalid, PASSENGER_MONTH_OF_BIRTH, PASSENGER_DAY_OF_BIRTH);
            steps.SelectInvalidPassengerDateOfBirth(passenger.DateOfBirth);
            Assert.IsTrue(steps.GetErrorInvalidYearOfBirth(INVALID_YEAR_OF_BIRTH_ERROR_MESSAGE));
        }

        [Test]
        public void TestPassFindAdress()
        {
            steps.SetAirportsAndFindDates(FROM_AIRPORT, TO_AIRPORT, RETURN);
            steps.SetDateDept(Department_date);
            steps.SetDateReturn(Return_date, ReturnNextMonth);
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
            steps.SetAirportsAndFindDates(FROM_AIRPORT, TO_AIRPORT, RETURN);
            steps.SetDateDept(Department_date);
            steps.SetDateReturn(Return_date, ReturnNextMonth);
            steps.GetMyFlights();
            steps.SelectEconomyDept();
            steps.SelectEconomyReturn();
            steps.ConfirmSelectClass();
            steps.ConfirmFlightInfo();
            steps.SetPassengerFullInfo(passenger);
            steps.ConfirmPassengerAdress();
            steps.ConfirmPayments();
            Assert.IsTrue(steps.GetErrorInvalidCardNumber(INVALID_CARD_NUMBER_MESSAGE));
        }

        [Test]
        public void TestCountOfPassenger()
        {
            steps.SetAirportsAndFindDates(FROM_AIRPORT, TO_AIRPORT, RETURN);
            steps.SetDateDept(Department_date);
            steps.SetDateReturn(Return_date, ReturnNextMonth);
            steps.SetPassengersCount(ADULTS_COUNT, CHILDREN_COUNT);
            steps.GetMyFlights();
            Assert.IsTrue(steps.GetErrorFindMyFlights(INVALID_COUNTS_OF_PASSENGERS));
        }
    }
}