﻿using System;
using System.Windows;

namespace _1TDD_string_calc_kata
{
    public class Calculator
    {

        private string[] _numbersStringArray;
        private char _splitter = ',';
        private int[] _numbersArray;
        private int _response = 0;
        private int _indexOfTheNumbersArray = 0;
        private string _rawInputNumbersString;

        public int Add(string input)
        {
            _rawInputNumbersString = input;
            if (string.IsNullOrEmpty(_rawInputNumbersString) || _rawInputNumbersString.Equals(" "))
                return _response = 0;
            
            CheckForNewLinesAndRemoveThem();
            _numbersStringArray = _rawInputNumbersString.Split(_splitter);
            _numbersArray = new int[_numbersStringArray.Length];
            FillNumbersArray();
            AddNumbersToEachOther();
            return _response;
        }

        private void CheckForNewLinesAndRemoveThem()
        {
            if (_rawInputNumbersString.Contains("\n" + _splitter) || _rawInputNumbersString.Contains(_splitter + "\n"))
            {
                Console.WriteLine("The given input is incorrect: " + _rawInputNumbersString);
                throw new Exception();
            }
            else
            {
                if (_rawInputNumbersString.Contains("\n"))
                {
                    _rawInputNumbersString = _rawInputNumbersString.Replace("\n", _splitter.ToString());
                }
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

        private void AddNumbersToEachOther()
        {
            for (int numberIndex = 0; numberIndex < _numbersStringArray.Length; numberIndex++)
            {
                _response += _numbersArray[numberIndex];
            }
        }
    }
}