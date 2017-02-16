using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using _1TDD_string_calc_kata;

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
        // [TestCase(" ")] // --> could be checked too IF I made it
        public void Test_WhenNoNumbersIsGivenToAdd(string input)
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
        public void Test_WhenOneNumberIsGivenToAdd(string input, int expected)
        {
            var response = _calculator.Add(input);
            // Assert.AreEqual(expected, response);
            Assert.That(response, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("1,2",3)]
        [TestCase("0,1",1)]
        public void Test_WhenTwoNumbersAreGivenToAdd(string input, int expected)
        {
            var response = _calculator.Add(input);
            // Assert.AreEqual(expected, response);
            Assert.That(response, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("1,2,3,4,5",15)]
        [TestCase("1,1,1,1,1,1,1,1,1,1",10)]
        public void Test_RandomAmountOfNumbersAreGivenToAdd(string input, int expected)
        {
            var response = _calculator.Add(input);
            // Assert.AreEqual(expected, response);
            Assert.That(response, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("1.2")] // not a comma
        [TestCase("a,b")] // not a number
        [TestCase("a.b")] // not a comma or a number
        public void Test_AnInvalidInputToAdd(string input)
        {
            var response = _calculator.Add(input);
            // Assert.Throws(); it throws an error?
        }

        [Test]
        [TestCase("1\n2,3", 6)]
        // [TestCase("1,\n2", ....)] // -> This is not accepted, so this should throw an error?
        public void Test_WhenANewLineIsUsedToGiveToAdd(string input, int expected)
        {
            
        }

        //test if //[splitter/delimiter]\n[numbers]
        // example: //;\n1;2 OR //$\n1$2$3$4
    }
}
