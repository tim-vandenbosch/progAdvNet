using System;
using System.Windows;

namespace _1TDD_string_calc_kata
{
    public class Calculator
    {
        #region Local Variables For Class Calculator
        
        private string[] _numbersStringArray;
        private char _splitter = ',';
        private int[] _numbersArray;
        private int _response = 0;
        private string _rawInputNumbersString;

        #endregion

        /// <summary>
        /// The given string will be checked for correct input.
        /// The delimiter will be configured (if none given it takes the default)
        /// The string will be split in string-numbers
        /// string -> int
        /// all the numbers will be added to eachother
        /// </summary>
        /// <param name="rawInputNumberString"></param>
        /// <returns></returns>
        public int Add(string rawInputNumberString)
        {
            // !!!How to avoid this?!!!
            _rawInputNumbersString = rawInputNumberString;
            // check for empty input !!!Why can't I put this in a different function?!!!
            if (string.IsNullOrEmpty(_rawInputNumbersString) || _rawInputNumbersString.Equals(" "))
                return _response = 0;

            CheckForANewDelimiter();
            CheckForNewLinesAndRemoveThem();
            _numbersStringArray = _rawInputNumbersString.Split(_splitter);
            CheckForNegativeNumbers();
            _numbersArray = new int[_numbersStringArray.Length];
            FillNumbersArray();
            AddNumbersToEachOther();
            return _response;
        }

        #region Helping Functions for Method Add

        private void CheckForNegativeNumbers()
        {
            var errorStringOfNegativeNumbers = "";
            foreach (var number in _numbersStringArray)
            {
                if (number.Contains("-"))
                {
                    errorStringOfNegativeNumbers += number + " ";
                }
            }

            if (!errorStringOfNegativeNumbers.Equals(""))
                throw new Exception("Negatives not allowed: " + errorStringOfNegativeNumbers);
        }
        
        private void CheckForANewDelimiter()
        {
            if (!_rawInputNumbersString.Contains("//")) return;

            _splitter = Convert.ToChar(_rawInputNumbersString.Substring(2, 1));
            _rawInputNumbersString = _rawInputNumbersString.Substring(3);
        }

        private void CheckForNewLinesAndRemoveThem()
        {
            if (_rawInputNumbersString.Contains("\n" + _splitter) || _rawInputNumbersString.Contains(_splitter + "\n"))
            {
                Console.WriteLine("The given rawInputNumberString is incorrect: " + _rawInputNumbersString);
                throw new Exception();
            }
            else
            {
                if (_rawInputNumbersString.StartsWith("\n"))
                    _rawInputNumbersString = _rawInputNumbersString.TrimStart('\n');

                if (_rawInputNumbersString.Contains("\n"))
                    _rawInputNumbersString = _rawInputNumbersString.Replace("\n", _splitter.ToString());
            }
        }

        private void FillNumbersArray()
        {
            for (var indexOfTheNumbersArray = 0; indexOfTheNumbersArray < _numbersArray.Length; indexOfTheNumbersArray++)
            {
                try
                {
                    _numbersArray[indexOfTheNumbersArray] = Convert.ToInt32(_numbersStringArray[indexOfTheNumbersArray]);
                }
                catch (Exception e)
                {
                    // MessageBox.Show("Invalid number: " + _numbersStringArray[_indexOfTheNumbersArray]);
                    Console.WriteLine("Invalid number: " + _numbersStringArray[indexOfTheNumbersArray]);
                    throw;
                }
            }
        }

        private void AddNumbersToEachOther()
        {
            for (var numberIndex = 0; numberIndex < _numbersStringArray.Length; numberIndex++)
                _response += _numbersArray[numberIndex];
        }

        #endregion
    }
}