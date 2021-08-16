namespace Ex04.Menus.Interfaces
{
    public abstract class MenuItem
    {
        private string m_MenuItemName;

        public MenuItem(string i_MenuItemName)
        {
            m_MenuItemName = i_MenuItemName;
        }

        public override string ToString()
        {
            return m_MenuItemName;
        }
    }
}
