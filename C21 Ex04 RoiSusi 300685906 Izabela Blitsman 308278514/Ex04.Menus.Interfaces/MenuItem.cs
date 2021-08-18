namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private string m_MenuTitle;

        public MenuItem(string i_MenuTitle)
        {
            m_MenuTitle = i_MenuTitle;
        }

        public string MenuTitle
        {
            get { return m_MenuTitle; }
        }
    }
}