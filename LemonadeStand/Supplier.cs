using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Supplier
    {
        private Lemon aLemon = new Lemon("Lemon", 3, 2.00);
        public Lemon ALemon { get { return aLemon; } }
        private Sugar aCupOfSugar = new Sugar("Sugar", 4, 1.00);
        public Sugar ACupOfSugar { get { return aCupOfSugar; } }
        private Ice anIceCube = new Ice("Ice", 0, .25);
        public Ice AnIceCube { get { return anIceCube; } }

        public double GetPrice(string item)
        {
            double price = 0;
            switch (item)
            {
                case "Lemon":
                    price = aLemon.Price;
                    break;
                case "Sugar":
                    price = aCupOfSugar.Price;
                    break;
                case "Ice":
                    price = AnIceCube.Price;
                    break;
            }
            return price;
        }

    }
}
