using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FourInRow
{
    static class Program
    {
        static void Main()
        {
            GameSettings gameSettings = new GameSettings();
            gameSettings.ShowDialog();
        }
    }
}
