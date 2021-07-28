using System;

namespace C21_Ex01_5
{
    class Program
    {
        private static int m_UserInput = 0;
        private const int k_ValidNumberLength = 9;

        public static void Main(string[] args)
        {
            NumbersStatistics();

            Console.ReadLine();

        }

        public static void NumbersStatistics()
        {
            string userInput = null;

            Console.WriteLine("Please enter a positive number with " + k_ValidNumberLength + " digits:");
            userInput = Console.ReadLine();

            if (IsUserInputValid(userInput))
            {
                MaxDigitInNumber(m_UserInput);
                NumbersDigitAverage(m_UserInput);
                CountNumberDigitsDividedByThree(m_UserInput);
                CountNumberDigitsSmallerThanUnityDigit(m_UserInput);
            }
        }

        public static bool IsUserInputValid(string i_UserInput)
        {
            if (int.TryParse(i_UserInput, out m_UserInput))
            {

                if (i_UserInput.Length != k_ValidNumberLength)
                {
                    Console.WriteLine("The input number's length should be "  + k_ValidNumberLength + " digits");
                    return false;
                }

                else
                {
                    if (m_UserInput < 0)
                    {
                        Console.WriteLine("The input number should be positive");
                        return false;
                    }

                    return true;
                }
            }

            else
            {
                Console.WriteLine("Invalid input - should be a numeric input only");
                return false;
            }
        }

        public static void MaxDigitInNumber(int i_UserInputNumber)
        {
            int maxDigit = 0;
            int currentNumberDigit = 0;

            for (int i = 0; i < k_ValidNumberLength; i++)
            {
                i_UserInputNumber = Math.DivRem(i_UserInputNumber, 10, out currentNumberDigit);


                if (currentNumberDigit > maxDigit)
                {
                    maxDigit = currentNumberDigit;
                }

            }

            Console.WriteLine("The number's max digit is: " + maxDigit);
        }

        public static void NumbersDigitAverage(int i_UserInputNumber)
        {
            float numberDigitAverage = 0F;
            int currentNumberDigit = 0;

            for(int i = 0; i < k_ValidNumberLength; i++)
            {
                i_UserInputNumber = Math.DivRem(i_UserInputNumber, 10, out currentNumberDigit);
                numberDigitAverage += currentNumberDigit;
            }

            numberDigitAverage /= k_ValidNumberLength;
             
            Console.WriteLine("The number's digits average is: " + numberDigitAverage);
        }

        public static void CountNumberDigitsDividedByThree(int i_UserInputNumber) 
        {
            int countNumberDigitsDividedByThree = 0;
            int remainder;

            for(int i = 0; i < k_ValidNumberLength; i++)
            {
                i_UserInputNumber = Math.DivRem(i_UserInputNumber, 10, out remainder);

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
            int remainder = 0;
            int unityDigit = 0;

            i_UserInputNumber = Math.DivRem(i_UserInputNumber, 10, out unityDigit);

            for(int i = 1; i < k_ValidNumberLength; i++)
            {
                i_UserInputNumber = Math.DivRem(i_UserInputNumber, 10, out remainder);

                if (remainder < unityDigit)
                {
                    countDigitsSmallerThanUnityDigit++;
                }
            }

            Console.WriteLine("The number's digits that smaller than unity digit is: " + countDigitsSmallerThanUnityDigit);
        }
    }
}
