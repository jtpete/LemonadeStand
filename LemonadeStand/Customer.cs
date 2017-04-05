using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        private bool thirsty = false;
        public bool Thirsty { get { return thirsty; } }
        public int drinkRating;
        private double maxPrice;
        public double MaxPrice { get { return maxPrice; } }

        public Customer(int temp, string cond, Random rand)
        {
            SetThirst(temp, cond, rand);
            SetPriceTolerance(temp, cond, rand);
        }
        private void SetPriceTolerance(int temp, string cond, Random rand)
        {
            maxPrice = 1;
            int likely = rand.Next(0,10);
            if (temp >= 100)
            {
                if(likely <= 9)
                {
                    maxPrice = 3;
                }
            }
            else if (temp >= 90)
            {
                if (likely <= 6 && cond != "Rainy")
                {
                    maxPrice = 2;
                }

            }
            else if (temp >= 80)
            {
                if (likely <= 4 && cond != "Rainy")
                {
                    maxPrice = 1.5;
                }

            }
            else if (temp >= 70)
            {
                if (likely <= 7)
                {
                    maxPrice = .75;
                }

            }
            else if (cond == "Rainy")
            {
                if (likely <= 7)
                {
                    maxPrice = .50;
                }

            }
            else if (temp < 70)
            {
                if (likely <= 7)
                {
                    maxPrice = .25;
                }

            }
        }
        private void SetThirst(int temp, string cond, Random rand)
        {
            int likely = rand.Next(1, 10);
            if (temp > 90 && (cond == "Sunny" || cond == "Partly Sunny"))
            {
                if(likely <= 9)  //80% chance 
                {
                    thirsty = true;
                }
            }
            else if (temp > 90 && (cond == "Cloudy" || cond == "Overcast"))
            {
                if (likely <= 5) //50% chance 
                {
                    thirsty = true;
                }
            }
            else if (temp > 90 && (cond == "Rainy" || cond == "Breezy"))
            {
                if (likely <= 4) //40% chance
                {
                    thirsty = true;
                }
            }
            else if (temp > 80 && (cond == "Rainy" || cond == "Breezy"))
            { 
                if (likely <= 3) //30% chance
                {
                    thirsty = true;
                }
            }
            else if (temp > 80)
            {
                if (likely <= 5) //50% chance
                {
                    thirsty = true;
                }
            }
            else if (temp > 50 && (cond == "Sunny" || cond == "Partly Sunny"))
            {
                if (likely <= 4) //40% chance
                {
                    thirsty = true;
                }
            }
            else if (temp > 50)
            {
                if (likely <= 2) //20% chance
                {
                    thirsty = true;
                }

            }
            else
            {
                if (likely <= 5) //50% chance
                {
                    thirsty = true;
                }
            }
        }
    }
}
