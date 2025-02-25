using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProiectCFLP
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Set up the players for the game
            List<Player> players = new List<Player>
            {
                new Player { Name = "Mircea" },
                new Player { Name = "Petrisor" }
            };

            // Initialize the game with players
            Game game = new Game(players);

            // Set up and run the form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(game));
        }
    }
}