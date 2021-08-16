using System;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            InterfaceMenuTest interfaceMenuTest = new InterfaceMenuTest();
            interfaceMenuTest.Run();

            DelegateMenuTest delegateMenuTest = new DelegateMenuTest();
            delegateMenuTest.Run();

            Console.WriteLine("Bye Bye, press any key to exit:");
            Console.ReadLine();

        }
    }
}