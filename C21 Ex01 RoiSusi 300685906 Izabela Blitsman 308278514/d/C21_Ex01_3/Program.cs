using System;
using System.Collections.Generic;
using System.Text;
using C21_Ex01_2;

namespace C21_Ex01_3
{
    public class Program
    {
        private static int m_SandMachineHeight;

        public static void Main(string[] args)
        {
            AdvanceSandMachine();
            Console.ReadLine();
        }

        public static void AdvanceSandMachine()
        {
            string sandMahchineRows = null;
            
            Console.WriteLine("Please enter the height of the Sand Machine:");
            sandMahchineRows = Console.ReadLine();

            if (IsUserInputValid(sandMahchineRows))
            {
                CreateSandMachine();
            }
        }

        public static bool IsUserInputValid(string i_UserInput)
        {

            if (int.TryParse(i_UserInput, out m_SandMachineHeight))
            {
                if (m_SandMachineHeight > 0)
                {
                    return true;
                }
            }

            Console.WriteLine("Invalid input - input shoud be numeric");
            return false;
        }

        public static void CreateSandMachine()
        {
            m_SandMachineHeight = m_SandMachineHeight % 2 == 0 ? m_SandMachineHeight + 1 : m_SandMachineHeight;
            C21_Ex01_2.Program.PrintSandMachine(C21_Ex01_2.Program.CreateSandMachine(new StringBuilder(), 0, m_SandMachineHeight));
        }
    }
}
