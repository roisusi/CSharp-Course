using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{

    public class CountSpaces : MenuItem, IAction
    {
        private readonly ActionsCollection r_ActionsCollection = new ActionsCollection();

        public CountSpaces(string i_MenuAction) : base(i_MenuAction)
        {
        }

        public void Action()
        {
            r_ActionsCollection.CountSpaces();
        }
    }
}