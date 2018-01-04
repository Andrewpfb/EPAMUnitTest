using NUnit.Framework;
using System;
using System.Globalization;
using System.Threading;


namespace NunitTestFramework.Tests
{
    [TestFixture]
    public class Tests
    {
        private static Steps.Steps steps = new Steps.Steps();
        private static Businnes_Objects.PassengerInfo passenger;
        private static bool ReturnNextMonth;

        #region Airports info
        private const string RecentSearchCity = "JFK to LHR";
        private const string FromAirport = "New York, (JFK) US";
        private const string ToAirport = "London Heathrow, (LHR) GB";
        private const string InvalidAirport = "New Yorc";
        private const string SecondToAirportSomeCity = "New York Area Airports, (NYC) US";
        private const string Return = "Return";
        private const string OneWay = "One way";
        private const string MultiCity = "Multi city";
        #endregion

        #region Passengers count

        private const string AdultsCount = "9";
        private const string ChildrenCount = "7";

        #endregion

        #region Dates 
        private static DateTime DepartmentDate = DateTime.Now.AddDays(7);
        private static DateTime ReturnDate = DateTime.Now.AddDays(8);

        private const int PassengerDayOfBirth = 29;
        private const int PassengerMonthOfBirth = 09; //September.
        private int PassengerYearOfBirthInvalid = (DateTime.Now.Year - 15);
        #endregion

        #region Error Message
        private const string MissingAirportErrorMessage = "I'm flying From airport";
        private const string MissingRouteErrorMessage = "No results were found for your search, please check your route. Try changing your cities, dates or any other search criteria. #101639R";
        private const string InvalidCountsOfPassengers = "There are no reward seats found for your search. You might have better luck looking for a one way reward seat or by changing your dates. #101767R";
        private const string MissingInformationErrorMessage = "Oops, looks like some information that we need is missing. Please select a flight to proceed further";
        private string[] MissingInformationPassenger = new string[]
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
        private const string InvalidYearOfBirthErrorMessage = "Adult passengers must be above 16 years old on the date of departure";
        private const string InvalidCardNumberMessage = "Your card number doesn't seem to be correct. #4042R";
        #endregion


        [SetUp]
        public static void Init()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            ReturnNextMonth = ReturnDate.Year > DepartmentDate.Year || ReturnDate.Month > DepartmentDate.Month ? true : false;
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
            steps.SetAirportsAndFindDates(InvalidAirport, ToAirport, Return);
            Assert.IsTrue(steps.GetErrorAirport(MissingAirportErrorMessage));
        }

        [Test]
        public void TestFlightToSameCity()
        {
            steps.SetAirportsAndFindDates(FromAirport, SecondToAirportSomeCity, Return);
            steps.SetDateDept(DepartmentDate);
            steps.SetDateReturn(ReturnDate, ReturnNextMonth);
            steps.GetMyFlights();
            Assert.IsTrue(steps.GetErrorFlightNotFound(MissingRouteErrorMessage));
        }

        [Test]
        public void TestGetTicketsTable()
        {
            steps.SetAirportsAndFindDates(FromAirport, ToAirport, Return);
            steps.SetDateDept(DepartmentDate);
            steps.SetDateReturn(ReturnDate, ReturnNextMonth);
            steps.GetMyFlights();
            Assert.IsTrue(steps.GetTicketsTable());
        }

        [Test]
        public void TestSelectOneWay()
        {
            steps.SetAirportsAndFindDates(FromAirport, ToAirport, Return);
            steps.SetDateDept(DepartmentDate);
            steps.SetDateReturn(ReturnDate, ReturnNextMonth);
            steps.GetMyFlights();
            steps.SelectEconomyDept();
            steps.ConfirmSelectClass();
            Assert.IsTrue(steps.GetErrorNotInformation(MissingInformationErrorMessage));
        }

        [Test]
        public void TestMissingPassengerInfo()
        {
            steps.SetAirportsAndFindDates(FromAirport, ToAirport, Return);
            steps.SetDateDept(DepartmentDate);
            steps.SetDateReturn(ReturnDate, ReturnNextMonth);
            steps.GetMyFlights();
            steps.SelectEconomyDept();
            steps.SelectEconomyReturn();
            steps.ConfirmSelectClass();
            steps.ConfirmFlightInfo();
            steps.ConfirmPassInfo();
            Assert.IsTrue(steps.GetErrorEmptyPassInfo(MissingInformationPassenger));
        }

        [Test]
        public void TestPassengerAge()
        {
            steps.SetAirportsAndFindDates(FromAirport, ToAirport, Return);
            steps.SetDateDept(DepartmentDate);
            steps.SetDateReturn(ReturnDate, ReturnNextMonth);
            steps.GetMyFlights();
            steps.SelectEconomyDept();
            steps.SelectEconomyReturn();
            steps.ConfirmSelectClass();
            steps.ConfirmFlightInfo();
            steps.SelectInvalidPassengerDateOfBirth(
                new DateTime(PassengerYearOfBirthInvalid, PassengerMonthOfBirth, PassengerDayOfBirth)
                );
            Assert.IsTrue(steps.GetErrorInvalidYearOfBirth(InvalidYearOfBirthErrorMessage));
        }

        [Test]
        public void TestPassengerFindAdress()
        {
            steps.SetAirportsAndFindDates(FromAirport, ToAirport, Return);
            steps.SetDateDept(DepartmentDate);
            steps.SetDateReturn(ReturnDate, ReturnNextMonth);
            steps.GetMyFlights();
            steps.SelectEconomyDept();
            steps.SelectEconomyReturn();
            steps.ConfirmSelectClass();
            steps.ConfirmFlightInfo();
            steps.SetPassengerFullInfo(passenger);
            Assert.IsTrue(steps.GetPassengerFullAdress(passenger.FullAdress));
        }

        [Test]
        public void TestPassengerInvalidCardNumber()
        {
            steps.SetAirportsAndFindDates(FromAirport, ToAirport, Return);
            steps.SetDateDept(DepartmentDate);
            steps.SetDateReturn(ReturnDate, ReturnNextMonth);
            steps.GetMyFlights();
            steps.SelectEconomyDept();
            steps.SelectEconomyReturn();
            steps.ConfirmSelectClass();
            steps.ConfirmFlightInfo();
            steps.SetPassengerFullInfo(passenger);
            steps.ConfirmPassengerAdress();
            steps.ConfirmPayments();
            Assert.IsTrue(steps.GetErrorInvalidCardNumber(InvalidCardNumberMessage));
        }

        [Test]
        public void TestCountOfPassenger()
        {
            steps.SetAirportsAndFindDates(FromAirport, ToAirport, Return);
            steps.SetDateDept(DepartmentDate);
            steps.SetDateReturn(ReturnDate, ReturnNextMonth);
            steps.SetPassengersCount(AdultsCount, ChildrenCount);
            steps.GetMyFlights();
            Assert.IsTrue(steps.GetErrorFlightNotFound(InvalidCountsOfPassengers));
        }

        [Test]
        public void TestRecentSearch()
        {
            steps.SetAirportsAndFindDates(FromAirport, ToAirport, Return);
            steps.SetDateDept(DepartmentDate);
            steps.SetDateReturn(ReturnDate, ReturnNextMonth);
            steps.GetMyFlights();
            steps.SetAirportsAndFindDates(FromAirport, ToAirport, Return);
            Assert.IsTrue(steps.SearchOrderInRecentSearch(RecentSearchCity, DepartmentDate, ReturnDate));
        }
    }
}