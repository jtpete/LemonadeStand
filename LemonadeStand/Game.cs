using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        Player Player1 = new Player("Player1", 100);
        bool gameDone = false;
        int gameLength = 7;

        public void PlayGame()
        {
            while (!gameDone)
            {
                SetupGame();
            }
        }

        private void SetupGame()
        {
            string response = UserInterface.GameHeader().ToLower();
            switch (response)
            {
                case "1":
                case "new game":
                case "new":
                case "n":
                    {
                        // GET Player's name & duration 
                        // Go to today menu
                        break;
                    }
                case "2":
                case "load game":
                case "load":
                case "l":
                    {
                        // Load Game Menu
                        break;
                    }
                case "3":
                case "high scores":
                case "high":
                case "scores":
                case "h":
                    {
                        // High Score Menu
                        break;
                    }
                case "4":
                case "quit":
                case "done":
                    {
                        gameDone = true;
                        break;
                    }
                default:
                    {
                        SetupGame();
                        break;
                    }
            }
        }
    }
}
