using System;
using System.Collections.Generic;
using System.Text;

namespace C21_Ex01_4
{
    class Program
    {
        public static string m_StringUserInput = null;
        public  static int m_IntegerUserInput = 0;
        private const int k_ValidStringLength = 8;
        public static void Main()
        {
            StringAnalysis();

            Console.ReadLine();
        }

        public static void StringAnalysis()
        {
            Console.WriteLine("Please enter a string with 8 characters:");
            m_StringUserInput = Console.ReadLine();

            if (IsUserInputStringValid())
            {

                PrintIsStringPalindrom(IsPalindrom(m_StringUserInput, 0, k_ValidStringLength - 1));
                CountUppercaseCharacter(m_StringUserInput);
            }

            else if (IsUserInputIntegerValid())
            {
                PrintIsStringPalindrom(IsPalindrom(m_StringUserInput, 0, k_ValidStringLength - 1));
                IsNumberDividedByFour(m_IntegerUserInput);
            }
        }

        public static bool IsUserInputStringValid()
        {

            if (m_StringUserInput.Length == k_ValidStringLength)
            {
                foreach (char character in m_StringUserInput)
                {
                    if (!IsEnglishLetter(character) || !Char.IsLetter(character))
                    {
                        return false;
                    }
                }
                return true;
            }

            else
            {
                return false;
            }
        }

        public static bool IsUserInputIntegerValid()
        {
            if (int.TryParse(m_StringUserInput, out m_IntegerUserInput))
            {
                if (m_StringUserInput.Length == (k_ValidStringLength + 1))
                {
                    if (m_IntegerUserInput < 0)
                    {
                        m_IntegerUserInput *= -1;
                        m_StringUserInput = m_IntegerUserInput.ToString();

                        return true;
                    }

                    Console.WriteLine("Invalid input - input string length should be " + k_ValidStringLength);
                    return false;
                }

                else if (m_StringUserInput.Length == k_ValidStringLength)
                {
                    if (m_IntegerUserInput < 0)
                    {
                        return false;
                    }

                    return true;
                }

                else
                {
                    Console.WriteLine("Invalid input - input string length should be " + k_ValidStringLength);
                    return false;
                }
            }

            else
            {
                Console.WriteLine("Invalid input - string should contains only english characters or digits");
                return false;
            }
        }

        public static bool IsEnglishLetter(Char i_Character)
        {
            if ((i_Character >= 'A' && i_Character <= 'Z') || (i_Character >= 'a' && i_Character <= 'z'))
            {
                return true;
            }

            return false;
        }

        public static bool IsPalindrom(String i_StringUserInput, int i_StartIndex, int i_EndIndex)
        {

            if (i_StartIndex == i_EndIndex)
            {
                return true;
            }

            if ((i_StringUserInput[i_StartIndex]) != (i_StringUserInput[i_EndIndex]))
            {
                return false;
            }

            if (i_StartIndex < i_EndIndex + 1)
            {
                return IsPalindrom(i_StringUserInput, i_StartIndex + 1, i_EndIndex - 1);
            }

            return true;
        }

        public static void IsNumberDividedByFour(int i_IntegerUserInput)
        {
            String stringResult = null;

            if (i_IntegerUserInput % 4 == 0)
            {
                stringResult = String.Format("The number {0} is divided by 4 without remained", i_IntegerUserInput);
            }

            else
            {
                stringResult = String.Format("The number {0} is not divided by 4 without remained", i_IntegerUserInput);
            }

            Console.WriteLine(stringResult);
        }

        public static void CountUppercaseCharacter(String i_StringUserInput)
        {
            int countUppercaseCharacters = 0;
            

            for (int i = 0; i < k_ValidStringLength; i++)
            {

                if (Char.IsUpper(i_StringUserInput[i]))
                {
                    countUppercaseCharacters++;
                }
            }

            Console.WriteLine("The maximum string's uppercase characters sequence length is: " + countUppercaseCharacters);
        }

        public static void PrintIsStringPalindrom(bool i_StringPalindromResult)
        {
            if (i_StringPalindromResult)
            {
                Console.WriteLine("The user's input string is a palindrom");
            }

            else
            {
                Console.WriteLine("The user's input string is not a palinrom");
            }
        }
    }
}
