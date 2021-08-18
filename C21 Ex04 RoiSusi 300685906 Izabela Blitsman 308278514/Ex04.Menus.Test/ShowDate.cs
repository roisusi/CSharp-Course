using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowDate : MenuItem, IAction
    {
        private readonly ActionsCollection r_ActionsCollection = new ActionsCollection();

        public ShowDate(string i_MenuAction) : base(i_MenuAction)
        {
        }

        public void Action()
        {
            r_ActionsCollection.ShowDate();
        }
    }
}