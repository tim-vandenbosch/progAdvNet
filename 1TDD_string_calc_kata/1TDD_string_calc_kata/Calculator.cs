using System;

namespace _1TDD_string_calc_kata
{
    public class Calculator
    {
        public int Add(string numbersString)
        {
            int response = 0;

            if (String.IsNullOrEmpty(numbersString))
            {
                return response = 0;
            }
            else
            {
                Char splitter = ',';
                String[] separatedNumbers = numbersString.Split(splitter);
                int[] numbersInt = new int[separatedNumbers.Length];
                int index = 0;
                foreach (var nr in separatedNumbers)
                {
                    numbersInt[index] = Convert.ToInt32(separatedNumbers[index]);
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