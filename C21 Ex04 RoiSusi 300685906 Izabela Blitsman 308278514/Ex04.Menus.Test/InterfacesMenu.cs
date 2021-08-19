using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class InterfacesMenu
    {
        public void Run()
        {
            MainMenu    mainMenu = new MainMenu("Main Interfaces");
            SecondMenu  versionAndSpacesMenu = new SecondMenu("Version and Spaces");
            SecondMenu  showDateTimeMenu = new SecondMenu("Show Date/Time");
            ShowDate    showDate = new ShowDate("Show Date");
            ShowTime    showTime = new ShowTime("Show Time");
            CountSpaces countSpaces = new CountSpaces("Count Spaces");
            ShowVersion showVersion = new ShowVersion("Show Version");

            mainMenu.AddMenuItems(versionAndSpacesMenu, showDateTimeMenu);
            showDateTimeMenu.AddItem(showDate, showTime);
            versionAndSpacesMenu.AddItem(countSpaces, showVersion);
            
            mainMenu.Show();
        }
    }
}