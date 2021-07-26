using System;
using System.Collections.Generic;
using System.Text;

namespace C21_Ex01_5
{
    class NumbersStatistics
    {
        private static int m_UserInput;
        private const int k_LigalLengthNumber = 9;

        public static void Main(string[] args)
        {
            if (GetUserInput()) 
            {
                MaxDigitInNumber(m_UserInput);
                NumbersDigitAverage(m_UserInput);
                CountNumberDigitsDividedByThree(m_UserInput);
                CountNumberDigitsSmallerThanUnityDigit(m_UserInput);
            }

            Console.ReadLine();

        }

        public static Boolean GetUserInput()
        {
            string stringUserInput = null;

            Console.WriteLine("Please enter a positive number with 9 digits:");
            stringUserInput = Console.ReadLine();


            //TODO: maybe should check string[0] for positive or negative
            if (int.TryParse(stringUserInput, out m_UserInput))
            {

                if (stringUserInput.Length != k_LigalLengthNumber)
                {
                    Console.WriteLine("Number's length should be 9 digits");
                    return false;
                }

                else 
                {
                    if (m_UserInput < 0)
                    {
                        Console.WriteLine("Number should be positive");
                        return false;
                    }
                    return true;
                }
            }

            else
            {
                Console.WriteLine("Illegal input - should be a number");
                return false;
            }
        }

        public static void MaxDigitInNumber(int i_UserInputNumber)
        {
            int maxDigit = 0;
            int numberDigit = 0;

            for (int i = 0; i < k_LigalLengthNumber; i++)
            {
                i_UserInputNumber = Math.DivRem(i_UserInputNumber, 10, out numberDigit);


                if (numberDigit > maxDigit)
                {
                    maxDigit = numberDigit;
                }

            }

            Console.WriteLine("The max digit in number is: " + maxDigit);
        }

        public static void NumbersDigitAverage(int i_UserInputNumber)
        {
            int numberDigitAverage = 0;
            int numberDigit;

            for (int i = 0; i < k_LigalLengthNumber; i++)
            {
                i_UserInputNumber = Math.DivRem(i_UserInputNumber, 10, out numberDigit);
                numberDigitAverage += numberDigit;
            }

            numberDigitAverage /= k_LigalLengthNumber; 
            Console.WriteLine("The number's digits average is: " + numberDigitAverage);
        }

        public static void CountNumberDigitsDividedByThree(int i_UserInputNumber) 
        {
            int countNumberDigitsDividedByThree = 0;
            int remainder;

            for (int i = 0; i < k_LigalLengthNumber; i++)
            {
                i_UserInputNumber =  Math.DivRem(i_UserInputNumber, 10, out remainder);

                if ((remainder % 3) == 0)
                {
                    countNumberDigitsDividedByThree++;
                }
            }

            Console.WriteLine("The number's digits that divided by three without remainder is: " + countNumberDigitsDividedByThree);
        }

        public static void CountNumberDigitsSmallerThanUnityDigit(int i_UserInputNumber)
        {
            int countDigitsSmallerThanUnityDigit = 0;
            int remainder;
            int unityDigit;

            i_UserInputNumber = Math.DivRem(i_UserInputNumber, 10, out unityDigit);

            for (int i = 0; i < k_LigalLengthNumber - 1; i++)
            {
                i_UserInputNumber = Math.DivRem(i_UserInputNumber, 10, out remainder);

                if (remainder < unityDigit)
                {
                    countDigitsSmallerThanUnityDigit++;
                }
            }

            Console.WriteLine("The numer's digits that smaller than unity digit is: " + countDigitsSmallerThanUnityDigit);
        }
    }
}
