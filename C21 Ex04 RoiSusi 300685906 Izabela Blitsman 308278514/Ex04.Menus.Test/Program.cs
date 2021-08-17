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
        }
    }
}