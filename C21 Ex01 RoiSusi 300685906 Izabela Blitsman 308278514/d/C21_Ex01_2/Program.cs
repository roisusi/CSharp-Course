
using System;
using System.Text;

namespace C21_Ex01_2
{
    public class Program
    {
        private const int m_SandMachineHeight = 5;
        public static void Main()
        {
            BeginnersSandMachine();

            Console.ReadLine();
        }

        public static void BeginnersSandMachine()
        {
            PrintSandMachine(CreateSandMachine(new StringBuilder(), 0, m_SandMachineHeight));
        }

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
    }
}
