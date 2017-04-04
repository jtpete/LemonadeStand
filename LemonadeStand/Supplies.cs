﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{

    public class Supplies
    {
        public List<Lemon> myLemons = new List<Lemon>();
        public int MyLemons { get { return myLemons.Count; } }
        public List<Sugar> mySugar = new List<Sugar>();
        public int MySugar { get { return mySugar.Count; } }
        public List<Ice> myIce = new List<Ice>();
        public int MyIce { get { return myIce.Count; } }


        public void RemoveSupply(string supplyName, int qty)
        {
            
            switch(supplyName)
            {
                case "Lemon":
                    if (qty >= myLemons.Count)
                    {
                        for (int i = 0; i < qty; i++)
                        {
                            myLemons.RemoveAt(i);
                        }
                    }
                    else
                        myLemons.RemoveAll(x => x.Name == "Lemon");
                    break;
                case "Sugar":
                    if (qty >= mySugar.Count)
                    {
                        for (int i = 0; i < qty; i++)
                        {
                            mySugar.RemoveAt(i);
                        }
                    }
                    else
                        mySugar.RemoveAll(x => x.Name == "Sugar");
                    break;
                case "Ice":
                    if (qty >= myIce.Count)
                    {
                        for (int i = 0; i < qty; i++)
                        {
                            myIce.RemoveAt(i);
                        }
                    }
                    else
                        myIce.RemoveAll(x => x.Name == "Ice");
                    break;
            }
        }

        public void RemoveAllExpiredItems()
        {
            myLemons.RemoveAll(x => { return x.BadItem();});
            mySugar.RemoveAll(x => { return x.BadItem();});
            mySugar.RemoveAll(x => { return x.BadItem();});
        }

    }
}