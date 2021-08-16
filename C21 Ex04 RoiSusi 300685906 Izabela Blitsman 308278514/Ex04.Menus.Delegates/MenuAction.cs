namespace Ex04.Menus.Delegates
{
    public delegate void ChooseActionEventHandler();

    public class MenuAction : MenuItem
    {
        public event ChooseActionEventHandler MenuActionChoosen;

        public MenuAction(string i_NameItem) : base(i_NameItem)
        {
        }

        protected virtual void OnActionChoosen()
        {
            if (MenuActionChoosen != null)
            {
                MenuActionChoosen.Invoke();
            }
        }

        public void PreformChosenAction()
        {
            OnActionChoosen();
        }
    }
}