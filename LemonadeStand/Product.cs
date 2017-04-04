using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public abstract class Product
    {
        protected string name;
        public string Name { get { return name; } set { name = value; } }
        protected string type;
        public string Type { get { return type; } set { type = value; } }
        protected double cost;
        public double Cost { get { return cost; } set { cost = value; } }
        protected int qualityRating;
        public int QualityRating { get { return qualityRating; } set { qualityRating = value; } }
        protected string seller; 
        public string Seller { get { return seller; } set { seller = value; } }
        protected string quality;
        public string Quality { get { return quality; } set { quality = value; } }




    }
}
