using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Supplier
    {
        private Lemon aLemon = new Lemon("Lemon", 3, 1.25);
        public Lemon ALemon { get { return aLemon; } }
        private Sugar aCupOfSugar = new Sugar("Sugar", 4, 0.75);
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

        public Lemon GetNewLemon()
        {
            return new Lemon("Lemon", 3, 1.25);
        }
        public Sugar GetNewSugar()
        {
            return new Sugar("Sugar", 4, .75);
        }
        public Ice GetNewIce()
        {
            return new Ice("Ice", 0, .25);
        }

    }
}
