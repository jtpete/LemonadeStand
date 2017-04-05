using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Lemonade : Item
    {
        string mixName;
        int amtLemons;
        int amtSugar;
        int amtIce;
        private string quality;
        public string Quality { get { return quality; } }
        public Lemonade(string name, int shelfLifeDays, double price, int amtLemons, int amtSugar, int amtIce, string mixName)
        {
            this.name = name;
            this.shelfLifeDays = shelfLifeDays;
            this.price = price;
            this.amtLemons = amtLemons;
            this.amtSugar = amtSugar;
            this.amtIce = amtIce;
            this.quality = DetermineQuality(amtLemons, amtSugar, amtIce);
            this.mixName = mixName;
        }

        private string DetermineQuality(int amtLemons, int amtSugar, int amtIce)
        {
            string quality = "good";
            if (amtLemons > 8)
                quality = "sour";
            else if (amtSugar > 5)
                quality = "sweet";
            else if (amtIce < 5)
                quality = "warm";
            else if (amtLemons < 2 && amtSugar <= 1)
                quality = "weak";
            else if (amtLemons == 0 || amtSugar == 0)
                quality = "bad";
            return quality;
        }
    }
}
