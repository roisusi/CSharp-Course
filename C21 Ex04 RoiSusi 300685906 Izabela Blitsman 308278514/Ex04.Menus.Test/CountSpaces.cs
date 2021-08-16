using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{

    public class CountSpaces : MenuItem, IPerform
    {
        private readonly ActionsCollection r_ActionsCollection = new ActionsCollection();

        public CountSpaces(string i_InstruciontName) : base(i_InstruciontName)
        {
        }

        public void Perform()
        {
            r_ActionsCollection.CountSpaces();
        }
    }
}