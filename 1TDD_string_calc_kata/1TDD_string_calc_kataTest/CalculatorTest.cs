using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using _1TDD_string_calc_kata;
using Assert = NUnit.Framework.Assert;

namespace _1TDD_string_calc_kataTest
{
    [TestFixture]
    public class CalculatorTest
    {
        // One general declaration and initiation (SetUp) of the Testclass to avoid double written code.
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
        [TestCase(" ")] // --> could be checked too IF I made it ...and I did now
        public void Test_WhenNoNumbersIsGivenToAdd(string input)
        {
            var response = _calculator.Add(input);
            Assert.That(response, Is.EqualTo(0));
        }

        [Test]
        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("3", 3)]
        public void Test_WhenOneNumberIsGivenToAdd(string input, int expected)
        {
            Check(input, expected);
        }
        
        [Test]
        [TestCase("1, 2", 3)]
        [TestCase("0, 1", 1)]
        public void Test_WhenTwoNumbersAreGivenToAdd(string input, int expected)
        {
            Check(input, expected);
        }

        [Test]
        [TestCase("1, 2, 3, 4, 5", 15)]
        [TestCase("1, 1, 1, 1, 1, 1, 1, 1, 1, 1", 10)]
        public void Test_RandomAmountOfNumbersAreGivenToAdd(string input, int expected)
        {
            Check(input, expected);
        }

        [Test]
        [TestCase("1. 2")] // not a comma
        [TestCase("a, b")] // not a number
        [TestCase("a. b")] // not a comma or a number
        [TestCase("1, b")] // an extra test
        public void Test_AnInvalidInputToAdd(string input)
        {
            Assert.That(() => _calculator.Add(input), Throws.Exception);
            // Assert.That(_calculator.Add(input), Is.NaN);
        }

        [Test]
        [TestCase("1\n2, 3", 6)]
        [TestCase("1, 2\n3", 6)]
        [TestCase("1, 2, 2\n1", 6)]
        [TestCase("\n1,2",3)]
        // [TestCase("1,\n2", ....)] // -> This is not accepted, so this should throw an error?
        public void Test_WhenANewLineIsUsedToGiveToAdd(string input, int expected)
        {
            Check(input, expected);
        }

        [Test]
        [TestCase("1,\n2")] // -> lets make it throw an error here (look at Test_WhenANewLineIsUsedToGiveToAdd)
        [TestCase("1\n,2")]
        public void Test_WhenANewLineIsIncorrectlyGivenToAdd(string input)
        {
            Assert.That(() => _calculator.Add(input), Throws.Exception);
        }

        // test if //[splitter/delimiter]\n[numbers]
        // example: //;\n1;2 OR //$\n1$2$3$4
        [Test]
        [TestCase("//;1\n1;2", 4)]
        [TestCase("//;\n1;2", 3)]
        [TestCase("//$\n1$2$3$4", 10)]
        public void Test_WhenADelimiterOrSplitterIsGivenToAdd(string input, int expected)
        {
            Check(input, expected);
        }

        //[Test]
        //[TestCase("-1, 2")]
        //[TestCase("-1, -2")]
        //public void Test_WhenANegativeNumberIsGivenToAdd(string input)
        //{
        //    // Assert.That(() => _calculator.Add(input), Throws.Exception);
        //}

        private void Check(string input, int expected)
        {
            var response = _calculator.Add(input);
            Assert.That(response, Is.EqualTo(expected));
        }
    }
}
