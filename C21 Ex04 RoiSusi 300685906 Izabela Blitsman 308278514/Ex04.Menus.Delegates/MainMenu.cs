namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        internal const int r_DelegatesMenuLevel = 0;
        private readonly SecondMenu r_SecondMenu;

        public MainMenu(string i_Title)
        {
            r_SecondMenu = new SecondMenu(i_Title);
        }

        public void Show()
        {
            r_SecondMenu.Show(r_DelegatesMenuLevel);
        }

        public void AddMenuItems(params MenuItem[] i_MenuItems)
        {
            r_SecondMenu.AddItem(i_MenuItems);
        }
    }
}