using System;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            InterfacesMenu  interfacesMenu = new InterfacesMenu();
            interfacesMenu.Run();

            DelegatesMenu   delegatesMenu = new DelegatesMenu();
            delegatesMenu.Run();
        }
    }
}