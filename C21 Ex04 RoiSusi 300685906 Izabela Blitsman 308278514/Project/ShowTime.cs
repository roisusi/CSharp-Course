using System;
using System.Text;
using System.Collections.Generic;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowTime : MenuItem, IPerform
    {
        private readonly ActionsCollection r_ActionsCollection = new ActionsCollection();

        public ShowTime(string i_InstructionName) : base(i_InstructionName)
        {
        }

        public void Perform()
        {
            r_ActionsCollection.ShowTime();
        }
    }
}
