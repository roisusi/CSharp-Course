
using System;
using System.Text;

namespace C21_Ex01_2
{
    public class BeginnersSandMachine
    {

        public static StringBuilder CreateSandMachine(StringBuilder i_SandMachineStringBuilder , int i_SandMachineRows , int i_SandMachineHeight)
        {
            if (i_SandMachineRows == i_SandMachineHeight)
                return i_SandMachineStringBuilder;

            if (i_SandMachineRows < i_SandMachineHeight / 2)
            {
                i_SandMachineStringBuilder.AppendLine(new string(' ', i_SandMachineRows) + new string('*', i_SandMachineHeight - (2 * i_SandMachineRows)));
            }
            else
            {
                i_SandMachineStringBuilder.AppendLine(new string(' ', i_SandMachineHeight - i_SandMachineRows - 1) + new string('*', (2 * i_SandMachineRows) - i_SandMachineHeight + 2));
            }

            CreateSandMachine(i_SandMachineStringBuilder, i_SandMachineRows + 1, i_SandMachineHeight);

            return i_SandMachineStringBuilder;

        }

        public static void PrintSandMachine(StringBuilder i_stringBuilder)
        {
            Console.WriteLine(i_stringBuilder);
        }


        public static void Main()
        {
            PrintSandMachine(CreateSandMachine(new StringBuilder(), 0, 4));
            Console.ReadLine();
        }


    }
}
