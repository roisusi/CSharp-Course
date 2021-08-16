using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class DelegateMenuTest
    {
        public void Run()
        {
            DelegateTestActions delegateTestMenuActions = new DelegateTestActions();
            MainMenu mainMenu = new MainMenu("Main Menu");
            SubMenu verisonAndSpaces = new SubMenu("Verison and Spaces");
            SubMenu dateTimeMenu = new SubMenu("Show date/time");
            MenuAction showDate = new MenuAction("Show Date");
            MenuAction showTime = new MenuAction("Show Time");
            MenuAction countSpaces = new MenuAction("Count Spaces");
            MenuAction showVerison = new MenuAction("Show Verison");

            mainMenu.AddItem(verisonAndSpaces, dateTimeMenu);
            dateTimeMenu.AddItem(showDate, showTime);
            verisonAndSpaces.AddItem(countSpaces, showVerison);
            countSpaces.MenuActionChoosen += delegateTestMenuActions.ActionsCollection_CountSpaces;
            showVerison.MenuActionChoosen += delegateTestMenuActions.ActionsCollection_ShowVerison;
            showDate.MenuActionChoosen += delegateTestMenuActions.ActionsCollection_ShowDate;
            showTime.MenuActionChoosen += delegateTestMenuActions.ActionsCollection_ShowTime;

            mainMenu.Show();
        }
    }
}