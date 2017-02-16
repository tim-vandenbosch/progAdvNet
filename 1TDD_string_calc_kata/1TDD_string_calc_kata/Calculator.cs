using System;
using System.Windows;

namespace _1TDD_string_calc_kata
{
    public class Calculator
    {
        public int Add(string numbersString)
        {
            int response = 0;

            if (string.IsNullOrEmpty(numbersString))
            {
                return response = 0;
            }
            else
            {
                Char splitter = ',';
                string[] separatedNumbers = numbersString.Split(splitter);
                int[] numbersInt = new int[separatedNumbers.Length];
                int index = 0;
                foreach (var nr in separatedNumbers)
                {
                    try
                    {
                        numbersInt[index] = Convert.ToInt32(separatedNumbers[index]);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Invalid number");
                        throw;
                    }
                    index++;
                }
                for (int numberIndex = 0; numberIndex < separatedNumbers.Length; numberIndex++)
                {
                    response += numbersInt[numberIndex];
                }
                return response;
            }
        }
    }
}