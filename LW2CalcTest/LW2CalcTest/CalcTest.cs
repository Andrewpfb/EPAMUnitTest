﻿using NUnit.Framework;


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
        private double _doubleTwoDotFive = 2.5;
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
        [Test]
        public void TestSumMaxAndTen()
        {
            _result = Calculator.Plus(_doubleMaxValue, _doubleTen);
            Assert.AreEqual(double.MaxValue, _result);
        }
        [Test]
        public void TestSumTenNegativeAndMinValue()
        {
            _result = Calculator.Plus(_doubleTenNegative, _doubleMinValue);
            Assert.AreEqual(double.MinValue, _result);
        }
        [Test]
        public void TestSumMaxAndMaxValue()
        {
            _result = Calculator.Plus(_doubleMaxValue, _doubleMaxValue);
            Assert.AreEqual(double.PositiveInfinity, _result);
        }

        #endregion

        #region TestMinus

        [Test]
        public void TestMinusMaxAndMinValue()
        {
            _result = Calculator.Minus(_doubleMaxValue, _doubleMinValue);
            Assert.AreEqual(double.PositiveInfinity, _result);
        }
        [Test]
        public void TestMinusMaxAndMaxValue()
        {
            _result = Calculator.Minus(_doubleMaxValue, _doubleMaxValue);
            Assert.AreEqual(0.0, _result);
        }
        [Test]
        public void TestMinusTenNegativeAndTenNegative()
        {
            _result = Calculator.Minus(_doubleTenNegative, _doubleTenNegative);
            Assert.AreEqual(0.0, _result);
        }
        [Test]
        public void TestMinusTenAndTenNegative()
        {
            _result = Calculator.Minus(_doubleTen, _doubleTenNegative);
            Assert.AreEqual(20.0, _result);
        }
        [Test]
        public void TestMinusTenNegativeAndTen()
        {
            _result = Calculator.Minus(_doubleTenNegative, _doubleTen);
            Assert.AreEqual(-20.0, _result);
        }

        #endregion

        #region TestDivide

        [Test]
        public void TestDivMaxAndMinValue()
        {
            _result = Calculator.Divide(_doubleMaxValue, _doubleMinValue);
            Assert.AreEqual(-1.0, _result);
        }
        [Test]
        public void TestDivMinAndMinValue()
        {
            _result = Calculator.Divide(_doubleMinValue, _doubleMinValue);
            Assert.AreEqual(1.0, _result);
        }
        [Test]
        public void TestDivTenAndTwoDotFive()
        {
            _result = Calculator.Divide(_doubleTen, _doubleTwoDotFive);
            Assert.AreEqual(4.0, _result);
        }
        [Test]
        public void TestDivTwoDotFiveAndTen()
        {
            _result = Calculator.Divide(_doubleTwoDotFive, _doubleTen);
            Assert.AreEqual(0.25, _result);
        }
        [Test]
        public void TestDivTenNegativeAndTwoDotFive()
        {
            _result = Calculator.Divide(_doubleTenNegative, _doubleTwoDotFive);
            Assert.AreEqual(-4.0, _result);
        }

        #endregion

        #region TestMultiply

        [Test]
        public void TestMultTenAndTenNegative()
        {
            _result = Calculator.Multiply(_doubleTen, _doubleTenNegative);
            Assert.AreEqual(-100.0, _result);
        }
        [Test]
        public void TestMultTenAndTwoDotFive()
        {
            _result = Calculator.Multiply(_doubleTen, _doubleTwoDotFive);
            Assert.AreEqual(25.0,_result);
        }
        [Test]
        public void TestMultMaxAndMinValue()
        {
            _result = Calculator.Multiply(_doubleMaxValue, _doubleMinValue);
            Assert.AreEqual(double.NegativeInfinity,_result);
        }
        [Test]
        public void TestMultMinAndMinValue()
        {
            _result = Calculator.Multiply(_doubleMinValue, _doubleMinValue);
            Assert.AreEqual(double.PositiveInfinity, _result);
        }
        [Test]
        public void TestMultTenNegativeAndTwoDotFive()
        {
            _result = Calculator.Multiply(_doubleTenNegative, _doubleTwoDotFive);
            Assert.AreEqual(-25.0,_result);
        }

        #endregion
    }
}
