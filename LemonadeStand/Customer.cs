using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        private bool thirsty = false;
        public bool Thirsty { get { return thirsty; } }
        public int drinkRating;

        public Customer(int temp, string cond)
        {
            Random rand = new Random();
            int likely; 
            if (temp > 90 && cond == "Sunny" || cond == "Partly Sunny")
            {
                //75% chance 
                likely = rand.Next(0, 4);
                if(likely == 1 || likely == 2 || likely == 3)
                {
                    thirsty = true;
                }
            }
            if (temp > 90 && cond == "Cloudy" || cond == "Overcast")
            {
                //50% chance 
                likely = rand.Next(0, 1);
                if (likely == 1)
                {
                    thirsty = true;
                }
            }
            if (temp > 90 && cond == "Rainy" || cond == "Breezy")
            {
                //40% chance 
                likely = rand.Next(0, 10);
                if (likely == 1 || likely == 2 || likely == 3 || likely == 4)
                {
                    thirsty = true;
                }
            }
            if (temp > 80 && cond == "Rainy" || cond == "Breezy")
            {
                //30% chance 
                likely = rand.Next(0, 10);
                if (likely == 1 || likely == 2 || likely == 3)
                {
                    thirsty = true;
                }
            }
            else if (temp > 80)
            {
                //50% chance 
                likely = rand.Next(0, 1);
                if (likely == 1)
                {
                    thirsty = true;
                }
            }
            else if (temp > 50 && cond == "Sunny" || cond == "Partly Sunny")
            {
                //40% chance 
                likely = rand.Next(0, 10);
                if (likely == 1 || likely == 2 || likely == 3 || likely == 4)
                {
                    thirsty = true;
                }
            }
            else if (temp > 50)
            {
                //20% chance 
                likely = rand.Next(0, 10);
                if (likely == 1 || likely == 2)
                {
                    thirsty = true;
                }
            }


        }
    }
}
