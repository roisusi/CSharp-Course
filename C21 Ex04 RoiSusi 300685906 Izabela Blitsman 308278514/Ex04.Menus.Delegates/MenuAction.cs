namespace Ex04.Menus.Delegates
{
    public delegate void ChosenMenuActionEventHandler();

    public class MenuAction : MenuItem
    {
        public event ChosenMenuActionEventHandler ChosenMenuAction;

        public MenuAction(string i_MenuItemTitle) : base(i_MenuItemTitle)
        {
        }

        protected virtual void OnChosenMenuAction()
        {
            if(ChosenMenuAction != null)
            {
                ChosenMenuAction.Invoke();
            }
        }

        public void PreformeChosenAction()
        {
            OnChosenMenuAction();
        }
    }
}