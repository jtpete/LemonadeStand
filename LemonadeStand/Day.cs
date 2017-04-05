using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        private int todaysTemp;
        public int TodaysTemp { get { return todaysTemp; } }
        private string todaysCondition;
        public string TodaysCondition { get { return todaysCondition; } }
        private Player person;
        public Player Person { get { return person; } }
        private List<Customer> myCrowd = new List<Customer>();
        public int MyCrowd { get { return myCrowd.Count; } }
        double todaysProfit = 0;
        int dayNumber;
        public Day(int dayNumber, int currTemp, string currCond, Player person)
        {
            this.dayNumber = dayNumber;
            this.todaysTemp = currTemp;
            this.todaysCondition = currCond;
            this.person = person;
            DetermineAmountCustomers();
        }

        public void SellLemonade()
        {
            int startingPitcherCount = person.MySupplies.myLemonadePitchers.Count;
            int cupCount = person.MySupplies.myLemonadePitchers.Count * 20;
            double dailySales = 0;
            double pitchPrice = person.MySupplies.myLemonadePitchers[0].Price;
            string pitchQuality = person.MySupplies.myLemonadePitchers[0].Quality;
            Random rand = new Random();
            for (int i = 0; i < myCrowd.Count; i++)
            {

                if(MakeSale(cupCount, pitchPrice, pitchQuality, i, rand))
                {
                    dailySales += pitchPrice;
                    person.Wallet += pitchPrice;
                    cupCount -= 1;
                    if (cupCount % 10 == 0 && person.MySupplies.myLemonadePitchers.Count > 0)
                    {
                        RemovePitcher();
                    }
                }
            }
            UserInterface.EndOfDayReport(dayNumber, person.Name, person.Wallet, startingPitcherCount, person.MySupplies.myLemonadePitchers.Count, dailySales, myCrowd.Count, TodaysTemp, TodaysCondition, "Great Job! Enter To Continue.");
            Console.ReadLine();
        }

        private bool MakeSale(int cupCount, double pitchPrice, string quality, int crowd, Random rand )
        {
            if (myCrowd[crowd].Thirsty || (myCrowd[crowd].MaxPrice - pitchPrice) >= .75)
                if (myCrowd[crowd].MaxPrice >= pitchPrice)
                    if (quality != "good" && rand.Next(1,2) == 2)
                    {
                        return false;
                    }
                    else if (cupCount > 0)
                        return true;
            return false;
        }

        private void RemovePitcher()
        {
            person.MySupplies.myLemonadePitchers.RemoveAt(0);
        }

        private void DetermineAmountCustomers()
        {
            if (todaysTemp > 90 && (todaysCondition == "Sunny" || todaysCondition == "Partly Sunny"))
            {
                CreateCrowd(150);
            }
            else if (todaysTemp > 90 && (todaysCondition == "Cloudy" || todaysCondition == "Overcast"))
            {
                CreateCrowd(120);
            }
            else if (todaysTemp > 90 && todaysCondition == "Rainy")
            {
                CreateCrowd(70);
            }
            else if (todaysTemp > 90)
            {
                CreateCrowd(100);
            }
            else if (todaysTemp > 80 && (todaysCondition == "Sunny" || todaysCondition == "Partly Sunny"))
            {
                CreateCrowd(90);
            }
            else if (todaysTemp > 80 && (todaysCondition == "Cloudy" || todaysCondition == "Overcast"))
            {
                CreateCrowd(80);
            }
            else if (todaysTemp > 80 && todaysCondition == "Rainy")
            {
                CreateCrowd(50);
            }
            else if (todaysTemp > 80)
            {
                CreateCrowd(75);
            }
            else if (todaysTemp > 50 && (todaysCondition == "Sunny" || todaysCondition == "Partly Sunny"))
            {
                CreateCrowd(70);
            }
            else if (todaysTemp > 50 && (todaysCondition == "Cloudy" || todaysCondition == "Overcast"))
            {
                CreateCrowd(60);
            }
            else if (todaysTemp > 50 && todaysCondition == "Rainy")
            {
                CreateCrowd(20);
            }
            else if (todaysTemp > 50)
            {
                CreateCrowd(55);
            }
            else
            {
                CreateCrowd(75);
            }
        }

        private void CreateCrowd(int size)
        {
            Random rand = new Random();

            for (int i = 0; i < size; i++)
            {
                Customer thisCustomer = new Customer(todaysTemp, todaysCondition, rand);
                myCrowd.Add(thisCustomer);
            }
        }
    }
}
