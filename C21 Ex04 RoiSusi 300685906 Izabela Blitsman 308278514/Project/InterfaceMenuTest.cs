using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class InterfaceMenuTest
    {
        public void Run()
        {
            MainMenu mainMenu = new MainMenu("Main Menu");
            SubMenu verisonAndSpaces = new SubMenu("Verison and Spaces");
            SubMenu dateTimeMenu = new SubMenu("Show date/time");
            ShowDate showDate = new ShowDate("Show Date");
            ShowTime showTime = new ShowTime("Show Time");
            CountSpaces countSpaces = new CountSpaces("Count Spaces");
            ShowVerison showVerison = new ShowVerison("Show Verison");

            mainMenu.AddItem(verisonAndSpaces, dateTimeMenu);
            dateTimeMenu.AddItem(showDate, showTime);
            verisonAndSpaces.AddItem(countSpaces, showVerison);
            mainMenu.Show();
        }
    }
}
