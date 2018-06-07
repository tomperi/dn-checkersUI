using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace checkersGUI
{
    static class Program
    {
        static void Main()
        {
            MainGame game = new MainGame();
            game.ShowDialog();
        }
    }
}
