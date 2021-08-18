using System;
using System.Text;
using System.Collections.Generic;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowTime : MenuItem, IAction
    {
        private readonly ActionsCollection r_ActionsCollection = new ActionsCollection();

        public ShowTime(string i_MenuAction) : base(i_MenuAction)
        {
        }

        public void Action()
        {
            r_ActionsCollection.ShowTime();
        }
    }
}