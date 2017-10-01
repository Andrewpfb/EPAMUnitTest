using NUnit.Framework;


namespace LW2CalcTest
{
    [TestFixture]
    public class CalcTest
    {
        #region Variables
        private double _doubleTenNegative = -10.0;
        private double _doubleMaxValue = double.MaxValue;
        private double _doubleMinValue = double.MinValue;
        private double _doubleTen = 10.0;
        private double _result;
        #endregion

        #region TestSum
        [Test]
        public void TestSumTenAndTenNegative()
        {
            _result = Calculator.Plus(_doubleTenNegative, _doubleTen);
            Assert.AreEqual(0.0, _result);
        }
        [Test]
        public void TestSumMaxAndMinValue()
        {
            _result = Calculator.Plus(_doubleMaxValue, _doubleMinValue);
            Assert.AreEqual(0.0, _result);
        }
        public void TestSumMaxAndTen()
        {
            _result = Calculator.Plus(_doubleMaxValue, _doubleTen);
            Assert.AreEqual(double.PositiveInfinity, _result);
        }
        public void TestSumTenNegativeAndMinValue()
        {
            _result = Calculator.Plus(_doubleTenNegative, _doubleMinValue);
            Assert.AreEqual(double.NegativeInfinity, _result);
        }
        [Test]
        public void TestSumMaxAndMaxValue()
        {
            _result = Calculator.Plus(_doubleMaxValue, _doubleMaxValue);
            Assert.AreEqual(double.PositiveInfinity, _result);
        }
        #endregion
    }
}
