namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        internal const int r_InterfacesMenuLevel = 0;
        private readonly SecondMenu r_SecondMenu;

        public MainMenu(string i_Title)
        {
            r_SecondMenu = new SecondMenu(i_Title);
        }

        public void Show()
        {
            r_SecondMenu.Show(r_InterfacesMenuLevel);
        }

        public void AddMenuItems(params MenuItem[] i_MenuItems)
        {
            r_SecondMenu.AddItem(i_MenuItems);
        }
    }
}