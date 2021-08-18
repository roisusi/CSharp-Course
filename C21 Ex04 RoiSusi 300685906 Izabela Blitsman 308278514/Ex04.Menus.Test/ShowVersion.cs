using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowVersion : MenuItem, IAction
    {
        private readonly ActionsCollection r_ActionsCollection = new ActionsCollection();

        public ShowVersion(string i_MenuAction) : base(i_MenuAction)
        {
        }

        public void Action()
        {
            r_ActionsCollection.ShowVersion();
        }
    }
}