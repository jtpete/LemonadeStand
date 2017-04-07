using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{

    public class Supplies
    {
        public List<Lemon> myLemons = new List<Lemon>();
        public List<Lemon> MyLemons { get { return myLemons; } }
        public List<Sugar> mySugar = new List<Sugar>();
        public List<Sugar> MySugar { get { return mySugar; } }
        public List<Ice> myIce = new List<Ice>();
        public List<Ice> MyIce { get { return myIce; } }
        public List<Lemonade> myLemonadePitchers = new List<Lemonade>();
        public int MyLemonadePitchers { get { return myLemonadePitchers.Count; } }


        public void RemoveSupply<T>(List<T> supply, int qty)
        {
            if (qty <= supply.Count)
            {
                for (int i = 0; i < qty; i++)
                {
                    supply.RemoveAt(0);
                }
            }
        }
    

        public void RemoveAllExpiredItems()
        {
            myLemons.RemoveAll(x => { return x.BadItem(); });
            mySugar.RemoveAll(x => { return x.BadItem(); });
            myIce.RemoveAll(x => { return x.BadItem(); });
            myLemonadePitchers.RemoveAll(x => { return x.BadItem(); });
        }

        public void ReduceSupplyShelflife()
        {
            myLemonadePitchers.Select(c => { c.ShelfLifeDays -= 1; return c; }).ToList();
            myLemons.Select(c => { c.ShelfLifeDays -= 1; return c; }).ToList();
            mySugar.Select(c => { c.ShelfLifeDays -= 1; return c; }).ToList();
            myIce.Select(c => { c.ShelfLifeDays -= 1; return c; }).ToList();



        }
    }
}
