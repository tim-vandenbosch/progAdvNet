using System;
using NUnit.Framework;
using _1TDD_string_calc_kata;

namespace _1TDD_string_calc_kataTest
{
    [TestFixture]
    public class CalculatorTest
    {
        private Calculator _calculator;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            _calculator = new Calculator();
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        // [TestCase(" ")] // --> could be checked too if I made it
        public void TestWhenNoNumbersIsGiven(string input)
        {
            // Act
            var solution = _calculator.Add(input);
            // Assert
            Assert.AreEqual(0, solution);
        }

        [Test]
        [TestCase("1", 1)]
        [TestCase("2", 2)]
        // ...
        public void TestWhenOneNumberIsGiven(string input, int expected)
        {
            var response = _calculator.Add(input);
            Assert.AreEqual(expected, response);
        }

        [Test]
        [TestCase("1,2",3)]
        // [TestCase("0,1",1)]
        public void TestWhenTwoNumbersAreGiven(string input, int expected)
        {
            var response = _calculator.Add(input);
            Assert.AreEqual(expected, response);
        }

        [Test]
        [TestCase("1,2,3,4,5",15)]
        public void TestRandomAmountOfNumbers(string input, int expected)
        {
            var response = _calculator.Add(input);
            Assert.AreEqual(expected, response);
        }
    }
}
