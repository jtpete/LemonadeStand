using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Pitcher : Item
    {
        public Pitcher(double price)
        {
            this.name = "Lemonade Pitcher";
            this.shelfLifeDays = 0;
            this.price = price;
        }
    }
}
