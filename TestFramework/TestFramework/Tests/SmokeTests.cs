using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestFramework.Tests
{
    /// <summary>
    /// Сводное описание для SmokeTest
    /// </summary>
    [TestClass]
    public class SmokeTests
    {
        private static Steps.Steps steps = new Steps.Steps();

        private const string FROM_AIRPORT = "New York, (JFK) US";
        private const string TO_AIRPORT = "London Heathrow, (LHR) GB";
        private const string INVALID_AIRPORT = "New Yorc";
        private const string SECOND_TO_AIRPORT_SOME_CITY = "New York Area Airports, (NYC) US";
        private const string MISSING_AIRPORT_ERROR_MESSAGE = "I'm flying From airport";

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
            steps.SetDates();
        }
    }
}
