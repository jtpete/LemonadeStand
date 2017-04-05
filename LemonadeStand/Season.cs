using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Season
    {
        Weather myWeather = new Weather();
        List<DailyReport> myReports = new List<DailyReport>();
        int dayCount = 1;

        int seasonLength;
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
            UserInterface.EndOfSeasonReport(player1, seasonLength)
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
            myReports.Add(newDay.todaysReport);
            dayCount += 1;
            myWeather.AdvanceForcast();
            player1.MySupplies.ReduceSupplyShelflife();
            player1.MySupplies.RemoveAllExpiredItems();
        }
    }
}
