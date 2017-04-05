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
                    // see financial info 
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
            dayCount += 1;
            myWeather.AdvanceForcast();
            player1.MySupplies.ReduceSupplyShelflife();
            player1.MySupplies.RemoveAllExpiredItems();
        }
    }
}
