using System;
using System.Collections.Generic;


namespace Ex04.Menus.Delegates
{
    public class SubMenu : MenuItem
    {
        private const int k_Exit = 0;
        private int m_InstructionNumber = 1;
        private readonly Dictionary<int, MenuItem> r_MenuOptionsList = new Dictionary<int, MenuItem>();

        public SubMenu(string i_Title) : base(i_Title)
        {
            r_MenuOptionsList.Add(k_Exit, null);
        }

        public void AddItem(params MenuItem[] i_NewMenuItems)
        {
            foreach (MenuItem newMenuItem in i_NewMenuItems)
            {
                r_MenuOptionsList.Add(m_InstructionNumber++, newMenuItem);
            }
        }

        public void Show(int i_CurrectLevel)
        {
            int inputUserChoice;
            SubMenu subMenu;

            do
            {
                printMenu(i_CurrectLevel);
                inputUserChoice = getChoiceFromUser();
                //System.Console.Clear();
                subMenu = r_MenuOptionsList[inputUserChoice] as SubMenu;

                if (subMenu != null)
                {
                    subMenu.Show(i_CurrectLevel + 1);
                }

                else if (r_MenuOptionsList[inputUserChoice] is MenuAction)
                {
                    ((MenuAction)r_MenuOptionsList[inputUserChoice]).PreformChosenAction();
                }
            }
            while (inputUserChoice != k_Exit);
        }

        private void printMenuTitle(int i_CurrectLevel)
        {
            if (i_CurrectLevel == 1)
            {
                System.Console.WriteLine("Main Delegates");
            }
        }

        private void printMenu(int i_CurrectLevel)
        {
            printMenuTitle(i_CurrectLevel);
            foreach (int optionNumber in r_MenuOptionsList.Keys)
            {
                if (optionNumber != k_Exit)
                {
                    string menuItem = string.Format("{0}. {1}", optionNumber, r_MenuOptionsList[optionNumber]);
                    System.Console.WriteLine(menuItem);
                }
            }

            System.Console.WriteLine("0. {0}", i_CurrectLevel == MainMenu.k_DelegateMenuLevel ? "Exit" : "Back");
        }

        private int getChoiceFromUser()
        {
            string userInput;
            int userChoice;
            userInput = Console.ReadLine();

            while (!int.TryParse(userInput, out userChoice) || !r_MenuOptionsList.ContainsKey(userChoice))
            {
                Console.WriteLine("Your input is invalid. Please choose from the existing options!");
                userInput = Console.ReadLine();
            }
            return userChoice;
        }
    }
}