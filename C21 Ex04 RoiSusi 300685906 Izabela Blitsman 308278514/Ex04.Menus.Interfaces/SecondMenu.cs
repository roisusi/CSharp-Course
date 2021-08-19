using System.Collections.Generic;
using System;

namespace Ex04.Menus.Interfaces
{
    public class SecondMenu : MenuItem
    {
        private readonly int r_Exit = 0;
        private int m_InstructionNumber = 1;
        private readonly Dictionary<int, MenuItem> r_MenuItemsList = new Dictionary<int, MenuItem>();

        public SecondMenu(string i_MenuTitle) : base(i_MenuTitle)
        {
            r_MenuItemsList.Add(r_Exit, new MenuItem(i_MenuTitle));
        }

        public void Show(int i_CurrentLevel)
        {
            string      userInput = string.Empty;
            int         userInputChoice = 0;
            SecondMenu  secondMenu = null;

            do
            {
                printMenuTitle();
                printMenuItems(i_CurrentLevel);

                System.Console.WriteLine();
                System.Console.WriteLine("Please select option:");
                userInput = Console.ReadLine();

                while(!int.TryParse(userInput, out userInputChoice) || !r_MenuItemsList.ContainsKey(userInputChoice))
                {
                    Console.WriteLine("Invalid input - Please choose one of the existing options");
                    userInput = Console.ReadLine();
                }

                secondMenu = r_MenuItemsList[userInputChoice] as SecondMenu;

                if(secondMenu != null)
                {
                    secondMenu.Show(i_CurrentLevel + 1);
                }
                else if(r_MenuItemsList[userInputChoice] is IAction)
                {
                    ((IAction)r_MenuItemsList[userInputChoice]).Action();
                    System.Console.WriteLine();
                }
            }
            while(userInputChoice != r_Exit);
        }

        public void AddItem(params MenuItem[] i_MenuItems)
        {
            foreach(MenuItem menuItem in i_MenuItems)
            {
                r_MenuItemsList.Add(m_InstructionNumber++, menuItem);
            }
        }

        private void printMenuTitle()
        {
            Console.WriteLine(r_MenuItemsList[0].MenuTitle); 
        }

        private void printMenuItems(int i_CurrentLevel)
        {
            foreach(int menuOption in r_MenuItemsList.Keys)
            {
                if(menuOption != r_Exit)
                {
                    string menuItem = string.Format("{0}. {1}", menuOption, r_MenuItemsList[menuOption].MenuTitle);
                    System.Console.WriteLine(menuItem);
                }
            }
            
            System.Console.WriteLine("0. {0}", i_CurrentLevel == MainMenu.r_InterfacesMenuLevel ? "Exit" : "Back");
        }
    }
}
