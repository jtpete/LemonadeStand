using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Ice : Item
    {
        public Ice(string name, int shelfLifeDays, double price)
        {
            this.name = name;
            this.shelfLifeDays = shelfLifeDays;
            this.price = price;
        }
    }
}
