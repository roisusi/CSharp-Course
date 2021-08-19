using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class DelegatesMenu
    {
        public void Run()
        {
            DelegatesMenuActions    delegatesMenuActions = new DelegatesMenuActions();
            MainMenu                mainMenu = new MainMenu("Main Delegates");
            SecondMenu              versionAndSpaces = new SecondMenu("Version and Spaces");
            SecondMenu              showDateTimeMenu = new SecondMenu("Show Date/Time");
            MenuAction              showDate = new MenuAction("Show Date");
            MenuAction              showTime = new MenuAction("Show Time");
            MenuAction              countSpaces = new MenuAction("Count Spaces");
            MenuAction              showVersion = new MenuAction("Show Version");

            mainMenu.AddMenuItems(versionAndSpaces, showDateTimeMenu);
            showDateTimeMenu.AddItem(showDate, showTime);
            versionAndSpaces.AddItem(countSpaces, showVersion);
            countSpaces.ChosenMenuAction += delegatesMenuActions.ActionsCollection_CountSpaces;
            showVersion.ChosenMenuAction += delegatesMenuActions.ActionsCollection_ShowVersion;
            showDate.ChosenMenuAction += delegatesMenuActions.ActionsCollection_ShowDate;
            showTime.ChosenMenuAction += delegatesMenuActions.ActionsCollection_ShowTime;

            mainMenu.Show();
        }
    }
}