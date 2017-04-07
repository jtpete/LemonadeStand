using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        Player player1 = new Player("Player1", 100);
        HighScore myHighScore = new HighScore();
        LoadGame myLoadGame = new LoadGame();

        bool gameDone = false;
        bool gameReady = false;
        bool loadGame = false;
        int gameLength = 7;

        public void PlayGame()
        {
            while (!gameDone)
            {
                SetupGame();
                if (gameReady && !loadGame)
                {
                    SellLemonade();
                }
                else if (gameReady && loadGame)
                {
                    string message = "Wow, Great Season!";
                    if (myHighScore.CheckForHighScore(player1.Wallet))
                    {
                        myHighScore.AddHighScore(player1.Name, player1.Wallet);
                        message = "You made the high score list!";
                        UserInterface.EndOfSeasonReport(player1, message);
                    }
                }
            }
        }

        private void SellLemonade()
        {
            Season mySeason = new Season(gameLength);
            mySeason.SalesSeason(player1);
            string message = "Wow, Great Season!";
            if (myHighScore.CheckForHighScore(player1.Wallet))
            {
                myHighScore.AddHighScore(player1.Name, player1.Wallet);
                message = "You made the high score list!";
                UserInterface.EndOfSeasonReport(player1, message);
            }
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
                        string loadResponse = myLoadGame.LoadGameList();
                        if (myLoadGame.SetGameToLoad(loadResponse))
                        {
                            myLoadGame.LoadThisGame(player1);
                            loadGame = true;
                            gameReady = true;
                        }
                        else
                            SetupGame();
                        break;
                    }
                case "3":
                case "high scores":
                case "high":
                case "scores":
                case "h":
                    {

                        myHighScore.HighScoreList();
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
