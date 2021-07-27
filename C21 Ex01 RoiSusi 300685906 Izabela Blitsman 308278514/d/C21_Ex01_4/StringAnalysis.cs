using System;
using System.Collections.Generic;
using System.Text;

namespace C21_Ex01_4
{
    class StringAnalysis
    {
        public static string m_StringUserInput = null;
        public  static int m_IntegerUserInput = 0;
        private const int k_ValidStringLength = 8;
        public static void Main()
        {
            if (GetStringUserInput())
            {

                PrintIsStringPalindrom(isStringPalindrom(m_StringUserInput, 0, k_ValidStringLength - 1));
                MaxUppercaseCharacterSequence(m_StringUserInput);
            }

            else if (GetIntegerUserInput())
            {
                PrintIsStringPalindrom(isStringPalindrom(m_StringUserInput, 0, k_ValidStringLength - 1));
                CheckNumberDividedByFour(m_IntegerUserInput);
            }

            Console.ReadLine();
        }

        public static bool GetStringUserInput()
        {
            Console.WriteLine("Please enter a string with 8 characters:");
            m_StringUserInput = Console.ReadLine();

            if (m_StringUserInput.Length == k_ValidStringLength)
            {
                foreach (char ch in m_StringUserInput)
                {
                    if ((ch <= 'A' && ch >= 'Z') || (ch <= 'a' && ch >= 'z') || !Char.IsLetter(ch))
                    {
                        return false;
                    }
                }
                return true;
            }

            else
            {
                Console.WriteLine("Invalid input - string length should be eight");
                return false;
            }
        }

        public static bool GetIntegerUserInput()
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

                    Console.WriteLine("Invalid input - string length should be eight");
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
                    Console.WriteLine("Invalid input - string length should be eight");
                    return false;
                }
            }

            else
            {
                Console.WriteLine("Invalid input - string should contains only characters or digits");
                return false;
            }
        }

        public static bool isStringPalindrom(String i_StringUserInput, int start, int end)
        {

            if (start == end)
            {
                return true;
            }

            if ((i_StringUserInput[start]) != (i_StringUserInput[end]))
            {
                return false;
            }

            if (start < end + 1)
            {
                return isStringPalindrom(i_StringUserInput, start + 1, end - 1);
            }

            return true;
        }

        public static void CheckNumberDividedByFour(int i_IntegerUserInput)
        {
            String result = null;

            if (i_IntegerUserInput % 4 == 0)
            {
                result = String.Format("The number {0} is divided by 4 without remained", i_IntegerUserInput);
            }

            else
            {
                result = String.Format("The number {0} is not divided by 4 without remained", i_IntegerUserInput);
            }

            Console.WriteLine(result);
        }

        public static void MaxUppercaseCharacterSequence(String i_StringUserInput)
        {
            int maxUppercaseCharactersSequence = 0;
            int currentSequenceCount = 0;

            for (int i = 0; i < k_ValidStringLength; i++)
            {

                if (Char.IsUpper(i_StringUserInput[i]))
                {
                    currentSequenceCount = 1;

                    for (int j = i + 1; j < k_ValidStringLength; j++)
                    {
                        if (Char.IsUpper(i_StringUserInput[i]) && Char.IsUpper(i_StringUserInput[j]))
                        {
                            currentSequenceCount++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (currentSequenceCount > maxUppercaseCharactersSequence)
                {
                    maxUppercaseCharactersSequence = currentSequenceCount;
                }
            }

        Console.WriteLine("The maximum string's uppercase characters sequence length is: " + maxUppercaseCharactersSequence);
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
