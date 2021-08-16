using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowVerison : MenuItem, IPerform
    {
        private readonly ActionsCollection r_ActionsCollection = new ActionsCollection();

        public ShowVerison(string i_InstructionName) : base(i_InstructionName)
        {
        }

        public void Perform()
        {
            r_ActionsCollection.ShowVerison();
        }
    }
}