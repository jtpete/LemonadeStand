using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Season
    {
        Weather myWeather = new Weather();
        protected List<DailyReport> myReports = new List<DailyReport>();
        public List<DailyReport> MyReports { get { return myReports; } set { myReports = value; } }
        protected int dayCount = 1;
        public int DayCount { get { return dayCount; } set { dayCount = value; } }

        protected int seasonLength;
        public Season(int seasonLength)
        {
            this.seasonLength = seasonLength;
        }

        public void SalesSeason(Player player1)
        {

            while (dayCount <= seasonLength)
            {
                PrepareForDay(player1);
            }
     
            
        }

        public void PrepareForDay(Player player1)
        {
            string response = UserInterface.DisplayTodaysMenu(player1, myWeather.CurrentTemp, myWeather.CurrentCondition).ToLower();
            switch (response)
            {
                case "1":
                case "see finances":
                case "see":
                case "finances":
                case "f":
                case "s":
                    if (myReports.Count > 0)
                    {
                        UserInterface.SeasonReports(myReports, dayCount-1, "Use Left or Right arrows to scroll through reports.  'Enter' when done.");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, no reports available on your first day. Enter to continue.");
                        Console.ReadLine();
                    }
                    break;
                case "2":
                case "check weather":
                case "check":
                case "weather":
                case "c":
                case "w":
                    UserInterface.GetTodaysWeatherReport(myWeather.CurrentTemp, myWeather.CurrentCondition, myWeather.FiveDayTemps, myWeather.FiveDayConditions);
                    break;
                case "3":
                case "purchase supplies":
                case "purchase":
                case "supplies":
                case "p":
                    player1.PurchaseProduct();
                    break;
                case "4":
                case "prepare lemonade":
                case "prepare":
                case "lemonade":
                case "l":
                    player1.MixLemonade();
                    break;
                case "5":
                case "start day":
                case "start":
                case "day":
                case "go":
                    RunThroughDay(player1);
                    break;
                default:
                    PrepareForDay(player1);
                    break;

            }
        }

        private void RunThroughDay(Player player1)
        {
            Day newDay = new Day(dayCount, myWeather.CurrentTemp, myWeather.CurrentCondition, player1);
            if (player1.MySupplies.myLemonadePitchers.Count > 0)
            {
                newDay.SellLemonade();
            }
            CompleteDay(player1);
            ReportDay(player1, newDay);
            SaveDay(player1, newDay.todaysReport);
            dayCount += 1;

        }

        private void CompleteDay(Player player1)
        {
            myWeather.AdvanceForcast();
            player1.MySupplies.ReduceSupplyShelflife();
            player1.MySupplies.RemoveAllExpiredItems();
        }

        private void SaveDay(Player player1, DailyReport aReport)
        {
            SaveGame mySave = new SaveGame();
            DateTime myGame = DateTime.Now;
            
            if (dayCount == 1)
            {
                mySave.InsertIntoPlayer(player1, myGame, seasonLength);
                player1.PlayerId = mySave.GetPlayerId(player1, myGame);
            }
            mySave.InsertIntoReport(aReport, player1.PlayerId);
            if(player1.MySupplies.MyLemons.Count > 0)
                mySave.InsertIntoLemons(player1.MySupplies.MyLemons, player1.PlayerId, dayCount);
            if (player1.MySupplies.MySugar.Count > 0)
                mySave.InsertIntoSugar(player1.MySupplies.MySugar, player1.PlayerId, dayCount);

        }

        private void ReportDay(Player player1, Day newDay)
        {
            myReports.Add(newDay.todaysReport);
        }
    }
}
