﻿using System;
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

        public static string DisplayTodaysMenu(Player player1, int currTemp, string currCondition)
        {
            Console.Clear();
            Console.WriteLine($" _______________________________________________ ");
            Console.WriteLine($"|                     TODAY                     ");
            Console.WriteLine($"|                                                ");
            Console.WriteLine($"|   Manager: {player1.Name}                      ");
            Console.WriteLine("|   Total: ${0}                     ", player1.Wallet.ToString("0.00"));
            Console.WriteLine("|   Temp: {0}\u00B0            Conditions: {1}  ", currTemp, currCondition);
            Console.WriteLine($"|                                                 ");
            Console.WriteLine($"|______________________________________________");
            Console.WriteLine($"|                                               ");
            Console.WriteLine($"|                1.  See Finances               ");
            Console.WriteLine($"|                2.  Check Weather              ");
            Console.WriteLine($"|                3.  Purchase Supplies          ");
            Console.WriteLine($"|                4.  Prepare Lemonade           ");
            Console.WriteLine($"|                5.  Start Day                  ");
            Console.WriteLine($"|_______________________________________________");
            return Console.ReadLine();
        }

        public static void GetTodaysWeatherReport(int currTemp, string currCondition, List<int> fiveDayTemps, List<string> fiveDayConditions)
        {
            Console.Clear();
            Console.WriteLine($" _______________________________________________ ");
            Console.WriteLine($"|                  WEATHER REPORT                     ");
            Console.WriteLine($"|                                                 ");
            Console.WriteLine("|     Today: Temp: {0}\u00B0     Conditions: {1}  ", currTemp, currCondition);
            Console.WriteLine("|  Tomorrow: Temp: {0}\u00B0     Conditions: {1}  ", fiveDayTemps[0], fiveDayConditions[0]);
            Console.WriteLine($"|                                                 ");
            Console.WriteLine($"|______________________________________________");
            Console.WriteLine($"|                                               ");
            Console.WriteLine("|  Day2: Temp: {0}\u00B0     Conditions: {1}  ", fiveDayTemps[1], fiveDayConditions[1]);
            Console.WriteLine("|  Day3: Temp: {0}\u00B0     Conditions: {1}  ", fiveDayTemps[2], fiveDayConditions[2]);
            Console.WriteLine("|  Day4: Temp: {0}\u00B0     Conditions: {1}  ", fiveDayTemps[3], fiveDayConditions[3]);
            Console.WriteLine("|  Day5: Temp: {0}\u00B0     Conditions: {1}  ", fiveDayTemps[4], fiveDayConditions[4]);
            Console.WriteLine($"|                                                ");
            Console.WriteLine($"|                                                ");
            Console.WriteLine($"|         Enter to Return to Menu                ");
            Console.WriteLine($"|_______________________________________________");
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
            Console.WriteLine($" _______________________________________________ ");
            Console.WriteLine($"|                 MIX LEMONADE PITCHERS          ");
            Console.WriteLine($"|                                                ");
            Console.WriteLine($"|   {name}                                        ");
            Console.WriteLine("|   Total: ${0}                     ", wallet.ToString("0.00"));
            Console.WriteLine($"|                                                ");
            Console.WriteLine($"|     Current Supplies:                            ");
            Console.WriteLine($"|     Lemons        : {suppliesList.MyLemons - (amtLemon * supplyOffset)}");
            Console.WriteLine($"|     Cups of Sugar : {suppliesList.MySugar- (amtSugar * supplyOffset)}");
            Console.WriteLine($"|     Ice Cubes     : {suppliesList.MyIce - (amtIce * supplyOffset)}");
            Console.WriteLine($"|     Pitchers      : {suppliesList.MyLemonadePitchers + numPitchers}");
            Console.WriteLine($"|                                                ");
            Console.WriteLine($"|______________________________________________");
            Console.WriteLine($"|                                Mixture / Pitcher: ");
            Console.WriteLine("|     1.  Add Lemons              {0} ", amtLemon);
            Console.WriteLine("|     2.  Add Cups of Sugar       {0} ", amtSugar);
            Console.WriteLine("|     3.  Add Ice Cubes           {0} ", amtIce);
            Console.WriteLine($"|                                                ");
            Console.WriteLine($"|                                Mixture Details:      ");
            Console.WriteLine("|     4.  Number of Pitchers      {0} ", numPitchers);
            Console.WriteLine("|     5.  Set Price               ${0} ", price.ToString("0.00"));
            Console.WriteLine("|     6.  Set Mix Name            {0} ", mixName);
            Console.WriteLine("|     7.  Make This Mix                          ");
            Console.WriteLine("|     8.  Leave Without Making Mix               ");
            Console.WriteLine("|     9.  Done                                   ");
            Console.WriteLine($"|_______________________________________________");
            Console.WriteLine($"|   {message}                                   ");
            Console.WriteLine($"|_______________________________________________");
        }
        public static void ConfirmMixture(int amtLemon, int amtSugar, int amtIce, double price, int numPitchers, string mixName, string message)
        {
            Console.Clear();
            Console.WriteLine($" _______________________________________________ ");
            Console.WriteLine($"|                 CONFIRM TODAY'S MIX            ");
            Console.WriteLine($"|                                                ");
            if (price == 0)
                Console.WriteLine("|         Cost Per Cup:  FREE!                ");
            else
                Console.WriteLine("|         Cost Per Cup:  ${0}     ", price.ToString("0.00"));
            Console.WriteLine($"|                                                ");
            Console.WriteLine($"|     Number of Pitchers : {numPitchers}         ");
            Console.WriteLine($"|     Mix Name           : {mixName}             ");
            Console.WriteLine($"|                                                ");
            Console.WriteLine($"|     Current Mix--------------------------      ");
            Console.WriteLine($"|     Lemons        : {amtLemon}                 ");
            Console.WriteLine($"|     Cups of Sugar : {amtSugar}                ");
            Console.WriteLine($"|     Ice Cubes     : {amtIce}                   ");
            Console.WriteLine($"|_______________________________________________");
            Console.WriteLine($"|   {message}                                   ");
            Console.WriteLine($"|_______________________________________________");
        }

        public static void PurchaseSuppliesMenu(string name, double wallet, Supplies suppliesList, Supplier vendor, string message)
        {
            Console.Clear();
            Console.WriteLine($" _______________________________________________ ");
            Console.WriteLine($"|                 PURCHASE SUPPLIES              ");
            Console.WriteLine($"|                                                ");
            Console.WriteLine($"|   {name}                                        ");
            Console.WriteLine("|   Total: ${0}                     ", wallet.ToString("0.00"));
            Console.WriteLine($"|                                                ");
            Console.WriteLine($"|     Current Supplies:                            ");
            Console.WriteLine($"|     Lemons        : {suppliesList.MyLemons}");
            Console.WriteLine($"|     Cups of Sugar : {suppliesList.MySugar}");
            Console.WriteLine($"|     Ice Cubes     : {suppliesList.MyIce}");
            Console.WriteLine($"|                                                ");
            Console.WriteLine($"|______________________________________________");
            Console.WriteLine($"|                                Current Price:  ");
            Console.WriteLine("|     1.  Add Lemons             ${0} ", vendor.GetPrice("Lemon").ToString("0.00"));
            Console.WriteLine("|     2.  Add Cups of Sugar      ${0} ", vendor.GetPrice("Sugar").ToString("0.00"));
            Console.WriteLine("|     3.  Add Ice Cubes          ${0} ", vendor.GetPrice("Ice").ToString("0.00"));
            Console.WriteLine("|     4.  Done     ");
            Console.WriteLine($"|_______________________________________________");
            Console.WriteLine($"|   {message}                                   ");
            Console.WriteLine($"|_______________________________________________");
        }

        public static void EndOfDayReport(int dayNum, string name, double wallet, int startingPitcherCount, int numPitchersLeft, double totalSales, int custVisits, int temp, string condition, string message)
        {
            Console.Clear();
            Console.WriteLine($" _______________________________________________ ");
            Console.WriteLine($"|             Day {dayNum} SALES                  ");
            Console.WriteLine("|   Temp: {0}\u00B0     Conditions: {1}  ", temp, condition);
            Console.WriteLine($"|                                                ");
            Console.WriteLine($"|   {name}                                        ");
            Console.WriteLine("|   Total: ${0}                     ", wallet.ToString("0.00"));
            Console.WriteLine($"|                                                ");
            Console.WriteLine($"|     Current Supplies:                            ");
            Console.WriteLine("|     Total Income              : ${0}       ", totalSales.ToString("0.00"));
            Console.WriteLine($"|     Total Pitchers Available  : {startingPitcherCount}");
            Console.WriteLine($"|     Total Pitchers Sold       : {startingPitcherCount - numPitchersLeft}");
            Console.WriteLine($"|     Total People Outside      : {custVisits}");
            Console.WriteLine($"|                                                ");
            Console.WriteLine($"|_______________________________________________");
            Console.WriteLine($"|   {message}                                   ");
            Console.WriteLine($"|_______________________________________________");
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
            }
            return gameLength;
        }
    }
}
