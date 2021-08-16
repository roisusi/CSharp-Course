namespace Ex04.Menus.Delegates
{
    public abstract class MenuItem
    {
        private readonly string r_MenuItemName;

        public MenuItem(string i_MenuItemName)
        {
            r_MenuItemName = i_MenuItemName;
        }

        public override string ToString()
        {
            return r_MenuItemName;
        }
    }
}