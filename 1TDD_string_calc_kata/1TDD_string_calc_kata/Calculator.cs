using System;
using System.Windows;

namespace _1TDD_string_calc_kata
{
    public class Calculator
    {
        private string[] _numbersStringArray;
        private Char _splitter;
        private int[] _numbersArray;
        private int _response = 0;
        private int _indexOfTheNumbersArray = 0;

        public int Add(string numbersString)
        {
            if (string.IsNullOrEmpty(numbersString))
            {
                return _response = 0;
            }
            else
            {
                _splitter = ',';
                _numbersStringArray = numbersString.Split(_splitter);
                _numbersArray = new int[_numbersStringArray.Length];
                

                FillNumbersArray();
                AddNumbers();
                return _response;
            }
        }

        private void FillNumbersArray()
        {
            foreach (var nr in _numbersStringArray)
            {
                try
                {
                    _numbersArray[_indexOfTheNumbersArray] = Convert.ToInt32(_numbersStringArray[_indexOfTheNumbersArray]);
                }
                catch (Exception e)
                {
                    // MessageBox.Show("Invalid number: " + _numbersStringArray[_indexOfTheNumbersArray]);
                    Console.WriteLine("Invalid number: " + _numbersStringArray[_indexOfTheNumbersArray]);
                    throw;
                }
                _indexOfTheNumbersArray++;
            }
        }

        private void AddNumbers()
        {
            for (int numberIndex = 0; numberIndex < _numbersStringArray.Length; numberIndex++)
            {
                _response += _numbersArray[numberIndex];
            }
        }
    }
}