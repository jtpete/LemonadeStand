using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public abstract class Item
    {
        protected string name;
        public string Name { get { return name; } set { name = value; } }

        protected int shelfLifeDays;
        public int ShelfLifeDays { get { return shelfLifeDays; } set { shelfLifeDays = value; } }
        protected double price;
        public double Price { get { return price; } set { price = value; } }


        public void ReduceShelfLife()
        {
            shelfLifeDays -= 1;
        }

        public bool BadItem()
        {
            if (shelfLifeDays < 0)
                return true;
            else
                return false;
        }

    }
}
