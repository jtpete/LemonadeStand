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
        //Day
        int seasonLength;
        public Season(int seasonLength)
        {
            this.seasonLength = seasonLength;
        }

        public void SalesSeason(Player player1)
        {
            int days = 1; 
            while (days <= seasonLength)
            {
                PrepareForDay(player1);
                //run through day
                //report on day
                days = seasonLength;
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
                    // prepare lemonade
                    break;
                case "5":
                case "start day":
                case "start":
                case "day":
                case "go":
                    // start day
                    break;
                default:
                    PrepareForDay(player1);
                    break;

            }
        }

        private void GetTodaysWeatherReport()
        {

        }
    }
 }
