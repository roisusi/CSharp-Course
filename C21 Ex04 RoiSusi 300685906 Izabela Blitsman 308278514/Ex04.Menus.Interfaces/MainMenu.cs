namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        internal const int k_InterfaceMenuLevel = 1;
        private readonly SubMenu r_SubMenu;

        public MainMenu(string i_Title)
        {
            r_SubMenu = new SubMenu(i_Title);
        }

        public void Show()
        {
            r_SubMenu.Show(k_InterfaceMenuLevel);
        }

        public void AddItem(params MenuItem[] i_NewMenuItems)
        {
            r_SubMenu.AddItem(i_NewMenuItems);
        }
    }
}