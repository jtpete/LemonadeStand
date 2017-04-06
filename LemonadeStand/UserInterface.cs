using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public static class UserInterface
    {
        public static string GameStartMenu()
        {
            Console.Clear();
            Console.WriteLine(" _______________________________________________ ");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|           Welcome to Lemonade Stand           |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|_______________________________________________|");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|                1.  New Game                   |");
            Console.WriteLine("|                2.  Load Game                  |");
            Console.WriteLine("|                3.  High Scores                |");
            Console.WriteLine("|                4.  Quit                       |");
            Console.WriteLine("|_______________________________________________|");
            return Console.ReadLine();
        }


        public static string HighScoreList(List<string> names, List<double> wallets)
        {
            Console.Clear();
            Console.WriteLine(" _______________________________________________ ");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|           HERE IS THE WINNER'S LIST           |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|_______________________________________________|");
            Console.WriteLine("|                                               |");
            for(int i = 0; i < names.Count; i++)
            {
                if(i < 5)
                Console.WriteLine("|   {0,3}.  {1,-15} {2,10}            |", i+1, names.ElementAt(i), wallets.ElementAt(i).ToString("0.00"));
            }
            Console.WriteLine("|                                               |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|_______________________________________________|");
            return Console.ReadLine();
        }

        public static string DisplayTodaysMenu(Player player1, int currTemp, string currCondition)
        {
            Console.Clear();
            Console.WriteLine($" _______________________________________________ ");
            Console.WriteLine("|   TODAY          {0,4}\u00B0 - {1,-13}        |", currTemp, currCondition);
            Console.WriteLine($"|                                               | ");
            Console.WriteLine("|   Manager: {0,-12}    ${1,-10}        |", player1.Name, player1.Wallet.ToString("0.00"));
            Console.WriteLine($"|                                               |");
            Console.WriteLine($"|_______________________________________________|");
            Console.WriteLine($"|                                               |");
            Console.WriteLine($"|           1.  See Finances                    |");
            Console.WriteLine($"|           2.  Check Weather                   |");
            Console.WriteLine($"|           3.  Purchase Supplies               |");
            Console.WriteLine($"|           4.  Prepare Lemonade                |");
            Console.WriteLine($"|           5.  Start Day                       |");
            Console.WriteLine($"|_______________________________________________|");
            return Console.ReadLine();
        }

        public static void GetTodaysWeatherReport(int currTemp, string currCondition, List<int> fiveDayTemps, List<string> fiveDayConditions)
        {
            Console.Clear();
            Console.WriteLine(" _______________________________________________ ");
            Console.WriteLine("|                  WEATHER REPORT               |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|     Today: {0,3}\u00B0     {1,-13}             |", currTemp, currCondition);
            Console.WriteLine("|  Tomorrow: {0,3}\u00B0     {1,-13}             |", fiveDayTemps[0], fiveDayConditions[0]);
            Console.WriteLine("|                                               |");
            Console.WriteLine("|_______________________________________________|");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|    Day2: {0,3}\u00B0      {1,-13}              |", fiveDayTemps[1], fiveDayConditions[1]);
            Console.WriteLine("|    Day3: {0,3}\u00B0      {1,-13}              |", fiveDayTemps[2], fiveDayConditions[2]);
            Console.WriteLine("|    Day4: {0,3}\u00B0      {1,-13}              |", fiveDayTemps[3], fiveDayConditions[3]);
            Console.WriteLine("|    Day5: {0,3}\u00B0      {1,-13}              |", fiveDayTemps[4], fiveDayConditions[4]);
            Console.WriteLine("|                                               |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|         Enter to Return to Menu               |");
            Console.WriteLine("|_______________________________________________|");
             Console.ReadLine();
        }

        public static void MixLemonadeMenu(string name, double wallet, Supplies suppliesList, int amtLemon, int amtSugar, int amtIce, double price,  int numPitchers, string mixName, string message)
        {
            int supplyOffset;
            if (numPitchers == 0)
                supplyOffset = 1;
            else
                supplyOffset = numPitchers;
            Console.Clear();
            Console.WriteLine($" _____________________________________________ ");
            Console.WriteLine($"|            MIX LEMONADE PITCHERS            |");
            Console.WriteLine($"|                                             |");
            Console.WriteLine("|   Manager: {0,-12}    ${1,-10}      |", name, wallet.ToString("0.00"));
            Console.WriteLine($"|                                             |");
            Console.WriteLine($"|     Current Supplies:                       |   ");
            Console.WriteLine("|     Lemons        : {0,-5}                   |", suppliesList.MyLemons - (amtLemon * supplyOffset));
            Console.WriteLine("|     Cups of Sugar : {0,-5}                   |", suppliesList.MySugar- (amtSugar * supplyOffset));
            Console.WriteLine("|     Ice Cubes     : {0,-5}                   |", suppliesList.MyIce - (amtIce * supplyOffset));
            Console.WriteLine("|     Pitchers      : {0,-5}                   |", suppliesList.MyLemonadePitchers + numPitchers);
            Console.WriteLine($"|_____________________________________________|");
            Console.WriteLine($"|                                Per Pitcher  |");
            Console.WriteLine("|     1.  Add Lemons              {0,-5}       |", amtLemon);
            Console.WriteLine("|     2.  Add Cups of Sugar       {0,-5}       |", amtSugar);
            Console.WriteLine("|     3.  Add Ice Cubes           {0,-5}       |", amtIce);
            Console.WriteLine($"|                                             |");
            Console.WriteLine($"|                                Mixture:     |");
            Console.WriteLine("|     4.  Number of Pitchers      {0,-5}       |", numPitchers);
            Console.WriteLine("|     5.  Set Price               ${0,-6}     |", price.ToString("0.00"));
            Console.WriteLine("|     6.  Set Mix Name - {0,-15}      |", mixName);
            Console.WriteLine("|     7.  Make This Mix                       |");
            Console.WriteLine("|     8.  Leave Without Making Mix            |");
            Console.WriteLine("|     9.  Done                                |");
            Console.WriteLine($"|_____________________________________________|");
            Console.WriteLine($"|   {message}                                   ");
            Console.WriteLine($"|____________________________________________");
        }
        public static void ConfirmMixture(int amtLemon, int amtSugar, int amtIce, double price, int numPitchers, string mixName, string message)
        {
            Console.Clear();
            Console.WriteLine($" ______________________________________________ ");
            Console.WriteLine($"|                 CONFIRM TODAY'S MIX          | ");
            Console.WriteLine($"|                                              | ");
            if (price == 0)
                Console.WriteLine("|         Cost Per Cup:  FREE!                 |");
            else
                Console.WriteLine("|         Cost Per Cup:  ${0,-6}               |", price.ToString("0.00"));
            Console.WriteLine($"|                                              |");
            Console.WriteLine("|      Number of Pitchers : {0,-5}              |", numPitchers);
            Console.WriteLine("|      Mix Name - {0,-15}              |", mixName);
            Console.WriteLine($"|                                              |");
            Console.WriteLine($"|     Current Mix------------------------------|");
            Console.WriteLine("|     Lemons        : {0,-5}                    |", amtLemon);
            Console.WriteLine("|     Cups of Sugar : {0,-5}                    |", amtSugar);
            Console.WriteLine("|     Ice Cubes     : {0,-5}                    |", amtIce);
            Console.WriteLine($"|______________________________________________|");
            Console.WriteLine($"|   {message}                                   ");
            Console.WriteLine($"|_______________________________________________");
        }

        public static void PurchaseSuppliesMenu(string name, double wallet, Supplies suppliesList, Supplier vendor, string message)
        {
            Console.Clear();
            Console.WriteLine($" _______________________________________________ ");
            Console.WriteLine($"|                 PURCHASE SUPPLIES             |");
            Console.WriteLine($"|                                               |");
            Console.WriteLine("|   Manager: {0,-12}    ${1,-10}        |", name, wallet.ToString("0.00"));
            Console.WriteLine($"|                                               |");
            Console.WriteLine($"|     Current Supplies:                         |");
            Console.WriteLine("|     Lemons        : {0,-5}                     |", suppliesList.MyLemons);
            Console.WriteLine("|     Cups of Sugar : {0,-5}                     |", suppliesList.MySugar);
            Console.WriteLine("|     Ice Cubes     : {0,-5}                     |", suppliesList.MyIce);
            Console.WriteLine($"|_______________________________________________|");
            Console.WriteLine($"|                                Current Price  |");
            Console.WriteLine("|     1.  Add Lemons             ${0,-5}         |", vendor.GetPrice("Lemon").ToString("0.00"));
            Console.WriteLine("|     2.  Add Cups of Sugar      ${0,-5}         |", vendor.GetPrice("Sugar").ToString("0.00"));
            Console.WriteLine("|     3.  Add Ice Cubes          ${0,-5}         |", vendor.GetPrice("Ice").ToString("0.00"));
            Console.WriteLine("|     4.  Done                                  |");
            Console.WriteLine($"|_______________________________________________|");
            Console.WriteLine($"|   {message}                                   ");
            Console.WriteLine($"|_______________________________________________");
        }

        public static void EndOfDayReport(DailyReport report, string message)
        {
            Console.Clear();
            Console.WriteLine(" _____________________________________________");
            Console.WriteLine("| Day {0,-2} SALES       {1,3}\u00B0 - {2,-13}    |", report.DayNumber, report.WTemp, report.WCondition);
            Console.WriteLine("|                                            |");
            Console.WriteLine("|  Manager: {0,-12}                     |", report.SellerName);
            Console.WriteLine("|    Bottom Line-----------------------------|");
            Console.WriteLine("|     Total Sales               : ${0,-7}   |", report.Gross.ToString("0.00"));
            Console.WriteLine("|     Net   Sales               : ${0,-7}   |", report.Net.ToString("0.00"));
            Console.WriteLine("|                                            |");
            Console.WriteLine("|    Relevant Stats------------------------- |");
            Console.WriteLine("|     Total Pitchers Available   : {0,-2}        |", report.PitchersAvailable);
            Console.WriteLine("|     Total Pitchers Sold        : {0,-2}        |", report.PitchersSold);
            Console.WriteLine("|     Total Cups Sold            : {0,-2}        |", report.CupsSold);
            Console.WriteLine("|     Price of Cup               : ${0,-6}   |", report.PricePerCup.ToString("0.00"));
            Console.WriteLine("|     Quality of Pitcher         : {0,-6}    |", report.QualityOfSupply);
            Console.WriteLine("|     Cost    of Pitcher         : ${0,-6}   |", report.CostOfPitcher.ToString("0.00"));
            Console.WriteLine("|     Total People Outside       : {0,-2}        |", report.CrowdCount);
            Console.WriteLine("|                                            |");
            Console.WriteLine("|____________________________________________|");
            Console.WriteLine($"|   {message}                                ");
            Console.WriteLine("|____________________________________________");
        }

        public static void EndOfSeasonReport(Player person, string message)
        {
            Console.Clear();
            Console.WriteLine(" ______________________________________________ ");
            Console.WriteLine("|                  YOU MADE IT!!!              |");
            Console.WriteLine("|                                              |");
            Console.WriteLine("|   {0,-15}                            |", person.Name);
            Console.WriteLine("|                                              |");
            if (person.Wallet > 0)
                Console.WriteLine("|   ${0,-7} - Not Bad!                        |", person.Wallet.ToString("0.00"));
            else if (person.Wallet == 0)
                Console.WriteLine("|     Well you didn't lose money...           |");
            else
                Console.WriteLine("|     File for bankruptcy!!!                  |");
            Console.WriteLine("|______________________________________________|");
            Console.WriteLine($"|  {message}                                  ");
            Console.WriteLine("|______________________________________________");
            Console.ReadLine();
        }

        public static void SeasonReports(List<DailyReport> report, int dayNumber, string message)
        {
            Console.Clear();
            Console.WriteLine(" _____________________________________________");
            Console.WriteLine("| Day {0,-2} SALES      {1,3}\u00B0 - {2,-13}     |", report[dayNumber - 1].DayNumber, report[dayNumber - 1].WTemp, report[dayNumber - 1].WCondition);
            Console.WriteLine("|                                            |");
            Console.WriteLine("|  Manager: {0,-12}                     |", report[dayNumber - 1].SellerName);
            Console.WriteLine("|    Bottom Line-----------------------------|");
            Console.WriteLine("|     Total Sales               : ${0,-7}   |", report[dayNumber-1].Gross.ToString("0.00"));
            Console.WriteLine("|     Net   Sales               : ${0,-7}   |", report[dayNumber-1].Net.ToString("0.00"));
            Console.WriteLine("|                                            |");
            Console.WriteLine("|    Relevant Stats------------------------- |");
            Console.WriteLine("|     Total Pitchers Available   : {0,-2}        |", report[dayNumber - 1].PitchersAvailable);
            Console.WriteLine("|     Total Pitchers Sold        : {0,-2}        |", report[dayNumber - 1].PitchersSold);
            Console.WriteLine("|     Total Cups Sold            : {0,-2}        |", report[dayNumber - 1].CupsSold);
            Console.WriteLine("|     Price of Cup               : ${0,-6}   |", report[dayNumber - 1].PricePerCup.ToString("0.00"));
            Console.WriteLine("|     Quality of Pitcher         : {0,-6}    |", report[dayNumber - 1].QualityOfSupply);
            Console.WriteLine("|     Cost    of Pitcher         : ${0,-6}   |", report[dayNumber - 1].CostOfPitcher.ToString("0.00"));
            Console.WriteLine("|     Total People Outside       : {0,-2}        |", report[dayNumber - 1].CrowdCount);
            Console.WriteLine("|                                            |");
            Console.WriteLine("|____________________________________________|");
            Console.WriteLine($"|   {message}                                   ");
            Console.WriteLine("|____________________________________________");
            ConsoleKeyInfo info = Console.ReadKey();
            if(info.Key == ConsoleKey.RightArrow && report.Count > dayNumber)
            {
                dayNumber += 1;
                message = "Use Left or Right arrows to scroll through reports.  'Enter' when done.";
                SeasonReports(report, dayNumber, message);
            }
            else if(info.Key == ConsoleKey.RightArrow && report.Count <= dayNumber)
            {
                message = "No more reports available";
                SeasonReports(report, dayNumber, message);
            }
            else if(info.Key == ConsoleKey.LeftArrow && dayNumber == 1)
            {
                message = "At first report";
                SeasonReports(report, dayNumber, message);
            }
            else if (info.Key == ConsoleKey.LeftArrow && dayNumber > 1)
            {
                dayNumber -= 1;
                message = "Use Left or Right arrows to scroll through reports.  'Enter' when done.";
                SeasonReports(report, dayNumber, message);
            }
            else if (info.Key != ConsoleKey.Enter)
            {
                message = "Use Left or Right arrows to scroll through reports.  'Enter' when done.";
                SeasonReports(report, dayNumber, message);
            }
        }


        public static void GetStartedHeader()
        {
            Console.Clear();
            Console.WriteLine(" _______________________________________________ ");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|           Let's Get This Started!             |");
            Console.WriteLine("|_______________________________________________|");
        }

        public static string UserName(string name)
        {
            Console.WriteLine($"{name} is such a boring name, what shall I call you?.");
            return Console.ReadLine();
        }

        public static int UserGameLength(string name)
        {
            int gameLength = 0;
            Console.WriteLine($"{name}: How many weeks would you like to sell lemonade?\n");
            Console.WriteLine("                1.  One Week                   ");
            Console.WriteLine("                2.  Two Weeks                  ");
            Console.WriteLine("                3.  Three Weeks                ");
            Console.WriteLine(" ");
            string response = Console.ReadLine().ToLower();
            switch (response)
            {
                case "1":
                case "one":
                case "one week":
                case "week":
                case "o":
                    {
                        gameLength = 7;
                        break;
                    }
                case "2":
                case "two":
                case "two weeks":
                    {
                        gameLength = 14;
                        break;
                    }
                case "3":
                case "three":
                case "three weeks":
                    {
                        gameLength = 21;
                        break;
                    }
                case "t":
                case "test":
                    {
                        gameLength = 1;
                        break;
                    }
            }
            return gameLength;
        }
    }
}
