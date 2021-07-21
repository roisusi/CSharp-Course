using System;
using System.Collections.Generic;
using System.Text;
using C21_Ex01_2;

namespace C21_Ex01_3
{
    public class AdvanceSandMachine
    {
        private static int numberOfLines;
        public static void ChooseNumberOfSandMachineHeight()
        {
            String readInputFromTheUser = "";
            bool flagOfCorrectInputFromTheUser = false;

            while (flagOfCorrectInputFromTheUser == false){
                Console.WriteLine("Please enter the height of the Sand Machine or -1 to exit");
                readInputFromTheUser = Console.ReadLine();

                if (int.TryParse(readInputFromTheUser, out numberOfLines))
                {
                    if (numberOfLines > 0 || numberOfLines == -1)
                    {
                        flagOfCorrectInputFromTheUser = true;
                        numberOfLines = numberOfLines % 2 == 0 ? numberOfLines + 1 : numberOfLines;
                        C21_Ex01_2.BeginnersSandMachine.PrintSandMachine(C21_Ex01_2.BeginnersSandMachine.CreateSandMachine(new StringBuilder(), 0, numberOfLines));
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            ChooseNumberOfSandMachineHeight();
            Console.ReadLine();
        }

    }
}
