﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        Player player1 = new Player("Player1", 100);
        bool gameDone = false;
        bool gameReady = false;
        int gameLength = 7;

        public void PlayGame()
        {
            while (!gameDone)
            {
                SetupGame();
                if (gameReady)
                {
                    SellLemonade();
                }
            }
        }

        private void SellLemonade()
        {
            Season mySeason = new LemonadeStand.Season(gameLength);
            mySeason.SalesSeason(player1);
        }

        private void SetupGame()
        {
            string response = UserInterface.GameStartMenu().ToLower();
            switch (response)
            {
                case "1":
                case "new game":
                case "new":
                case "n":
                    {
                        UserInterface.GetStartedHeader();
                        player1.GetNameFromUser();
                        UserInterface.GetStartedHeader();
                        gameLength = UserInterface.UserGameLength(player1.Name);
                        gameReady = true;
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
                        Console.WriteLine("Check Out all the winners!!");
                        Console.ReadLine();
                        SetupGame();
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