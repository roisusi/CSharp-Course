using System;

namespace B21_Ex01_01
{
    class Program
    {
        private const int k_ValidNumberLength = 9;
        private const byte k_MaxInputSeries = 3;
        private static string[] m_UserBinaryInputSeries;

        public static void Main()
        {
            BinarySeriesStatistics();

            Console.ReadLine();
        }

        public static void BinarySeriesStatistics()
        {
            Console.WriteLine("Please enter " + k_MaxInputSeries + " binary series which length's is " + k_ValidNumberLength + ": ");
            
            GetUserBinarySeriesInput(out m_UserBinaryInputSeries);
            PrintUserBinarySeries();
            MinAndMaxBinarySeriesInput(m_UserBinaryInputSeries);
            IsAsendingSequence(m_UserBinaryInputSeries);
            IsRootOfPowOfTwo(m_UserBinaryInputSeries);
            OnesAndZerosAverage(m_UserBinaryInputSeries);
        }

        public static void GetUserBinarySeriesInput(out string[] i_UserBinaryInputSeries)
        {
            i_UserBinaryInputSeries = new string[k_MaxInputSeries];
            string binarySeriesInput = null;
            bool isBinaryNumber = false;
            bool isValidLength = false;

            for (int i = 0; i < k_MaxInputSeries; i++)
            {
                while (!(isBinaryNumber && isValidLength)) 
                {
                    binarySeriesInput = Console.ReadLine();

                    isValidLength = IsValidLength(binarySeriesInput);
                    isBinaryNumber = IsValidBinaryNumber(binarySeriesInput);

                }

                isBinaryNumber = false;
                isValidLength = false;
                i_UserBinaryInputSeries[i] = binarySeriesInput;
            }
        } 

        public static bool IsValidLength(string i_UserBinaryInput)
        {
            if (i_UserBinaryInput.Length != k_ValidNumberLength)
            {
                Console.WriteLine("Invalid input - binary series length should be " + k_ValidNumberLength);
                return false;
            }

            return true;
        }

        public static bool IsValidBinaryNumber(string i_UserBinaryInput)
        {
            int binaryNumber = 0;

            if (int.TryParse(i_UserBinaryInput, out binaryNumber))
            {
                foreach (Char digit in i_UserBinaryInput)
                {
                    if ((digit != '1') && (digit != '0'))
                    {
                        Console.WriteLine("Invalid input - binary series should contains only 1's or 0's");
                        return false;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input - binary series should contains only 1's or 0's");
                return false;
            }

            return true;
        }

        public static void PrintUserBinarySeries()
        {
            Console.WriteLine("The number of binary series:");

            for (int i = 0; i < k_MaxInputSeries; i++)
            {
                Console.Write(Convert.ToInt32(m_UserBinaryInputSeries[i], 2) + " ");
            }

            Console.Write('\n');
        }

        public static void OnesAndZerosAverage(string[] i_UserBinarySeries)
        {
            int maxNumberLengthOfArrays = k_ValidNumberLength * k_MaxInputSeries;
            int countZeros = 0;
            int countOnes = 0;
            float averageOfOnes = 0;
            float averageOfZeros = 0;

            for (int i = 0; i < k_MaxInputSeries; i ++)
            {
                for (int j = 0; j < k_ValidNumberLength; j++)
                {
                    if (i_UserBinarySeries[i][j].Equals('0'))
                    {
                        countZeros ++;
                    }
                }
            }

            countOnes = maxNumberLengthOfArrays - countZeros;
            averageOfZeros = (float)countZeros / k_MaxInputSeries;
            averageOfOnes = (float)countOnes / k_MaxInputSeries;

            Console.WriteLine("The average number of digits 1 is : " + averageOfOnes);
            Console.WriteLine("The average number of digits 0 is : " + averageOfZeros);
        }

        public static void IsRootOfPowOfTwo(string[] i_UserBinarySeries)
        {
            int countRootOfPowTwo = 0;

     
            for (int i = 0; i < k_MaxInputSeries; i++)
            {
                int decimalNumber = Convert.ToInt32(i_UserBinarySeries[i], 2);

                if (decimalNumber != 0)
                {
                    double sqrtResult = Math.Log(decimalNumber, 2);
                    double isWholeNumber = Math.Floor(sqrtResult);

                    if (sqrtResult == isWholeNumber)
                    {
                        countRootOfPowTwo++;
                    }
                }
            }

            Console.WriteLine("Number of root of pow two: " + countRootOfPowTwo);
        }

        public static void IsAsendingSequence(string[] i_UserBinarySeries)
        {
            int maxDigit = 0;
            int compereMaxDigit = 0;
            int decimalNumber = 0;
            int countAsendingSequences = 0;
            bool countAsendingDigits = true;

            for (int i = 0; i < k_MaxInputSeries; i++)
            {
                decimalNumber = Convert.ToInt32(i_UserBinarySeries[i], 2);
                decimalNumber = Math.DivRem(decimalNumber, 10, out maxDigit);
                compereMaxDigit = maxDigit;

                if (decimalNumber > 9)
                {
                    while (decimalNumber != 0)
                    {
                        decimalNumber = Math.DivRem(decimalNumber, 10, out maxDigit);

                        if (compereMaxDigit <= maxDigit)
                        {
                            countAsendingDigits = false;
                            break;
                        }

                        compereMaxDigit = maxDigit;
                    }
                }

                else
                {
                    countAsendingDigits = false;
                }

                if (countAsendingDigits)
                {
                    countAsendingSequences++;
                }

                countAsendingDigits = true;
            }

            Console.WriteLine("The count of asending numbers is: " + countAsendingSequences);
        }

        public static void MinAndMaxBinarySeriesInput(string[] i_UserBinarySeries)
        {
            int minInBinarySeries = Convert.ToInt32(i_UserBinarySeries[0], 2);
            int maxInBinarySeries = Convert.ToInt32(i_UserBinarySeries[0], 2);

            for (int i = 1; i < k_MaxInputSeries; i++)
            {
                int currentBinarySeries = Convert.ToInt32(i_UserBinarySeries[i], 2);
                maxInBinarySeries = Math.Max(maxInBinarySeries, currentBinarySeries);
                minInBinarySeries = Math.Min(minInBinarySeries, currentBinarySeries);

            }

            Console.WriteLine("The minimum number in user's binary series: " + minInBinarySeries);
            Console.WriteLine("The maximum number in user's binary series: " + maxInBinarySeries);
        }
    }
}
