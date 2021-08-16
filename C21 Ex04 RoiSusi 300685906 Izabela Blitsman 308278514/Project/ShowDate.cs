using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowDate : MenuItem, IPerform
    {
        private readonly ActionsCollection r_ActionsCollection = new ActionsCollection();

        public ShowDate(string i_InstructionName) : base(i_InstructionName)
        {
        }

        public void Perform()
        {
            r_ActionsCollection.ShowDate();
        }
    }
}
