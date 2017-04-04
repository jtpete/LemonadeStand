using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Player
    {
        private string name;
        private double wallet;
        public double Wallet { get { return wallet; } }
        public string Name { get { return name; } set { name = value; } }
        private Supplies mySupplies = new Supplies();
        public Supplies MySupplies { get { return mySupplies; } }
        public Supplier mySupplier = new Supplier();

        public Player(string name, double startAmount)
        {
            this.name = name;
            wallet = startAmount;
        }

        public void GetNameFromUser()
        {
            string response = UserInterface.UserName(name);
            switch (response)
            {
                case " ":
                    GetNameFromUser();
                    break;
                default:
                    name = response;
                    break;
            }
        }

        public void PurchaseProduct()
        {
            string message = "What would you like to do?";
            UserInterface.PurchaseSuppliesMenu(name, wallet, mySupplies, mySupplier, message);
            string response = Console.ReadLine().ToLower();
            int qty;
            switch (response)
            {
                case "1":
                case "lemon":
                case "lemons":
                case "l":
                    qty = DetermineQuantityFromPlayer("Lemons");
                    if(EnoughFundsToPurchase("Lemon", qty))
                    {
                        AddSupplies("Lemon", qty);
                    }
                    else
                    {
                        message = "You need to make more money for that many lemons. Please hit Enter.";
                        UserInterface.PurchaseSuppliesMenu(name, wallet, mySupplies, mySupplier, message);
                        Console.ReadLine();
                    }
                    PurchaseProduct();
                    break;
                case "2":
                case "sugar":
                case "bag":
                case "bag of sugar":
                case "s":
                    qty = DetermineQuantityFromPlayer("Sugar");
                    if (EnoughFundsToPurchase("Sugar", qty))
                    {
                        AddSupplies("Sugar", qty);
                    }
                    else
                    {
                        message = "You need to make more money for that many cups of sugar. Please hit Enter.";
                        UserInterface.PurchaseSuppliesMenu(name, wallet, mySupplies, mySupplier, message);
                        Console.ReadLine();
                    }
                    PurchaseProduct();
                    break;
                case "3":
                case "ice":
                case "cube":
                case "cube of ice":
                case "i":
                    qty = DetermineQuantityFromPlayer("Ice");
                    if (EnoughFundsToPurchase("Ice", qty))
                    {
                        AddSupplies("Ice", qty);
                    }
                    else
                    {
                        message = "You need to make more money for that many cubes of ice. Please hit Enter.";
                        UserInterface.PurchaseSuppliesMenu(name, wallet, mySupplies, mySupplier, message);
                        Console.ReadLine();
                    }
                    PurchaseProduct();
                    break;
                case "done":
                case "4":
                    break;
                default:
                    PurchaseProduct();
                    break;
            }

        }
        private void AddSupplies(string item, int qty)
        {
            switch (item)
            {
                case "Lemon":
                    for(int i = 0; i < qty; i++)
                    {
                        mySupplies.myLemons.Add(mySupplier.ALemon);
                        wallet -= mySupplier.GetPrice("Lemon");
                    }
                    break;
                case "Sugar":
                    for (int i = 0; i < qty; i++)
                    {
                        mySupplies.mySugar.Add(mySupplier.ACupOfSugar);
                        wallet -= mySupplier.GetPrice("Sugar");
                    }
                    break;
                case "Ice":
                    for (int i = 0; i < qty; i++)
                    {
                        mySupplies.myIce.Add(mySupplier.AnIceCube);
                        wallet -= mySupplier.GetPrice("Ice");
                    }
                    break;
            }
        }

        private int DetermineQuantityFromPlayer(string item)
        {
            int qty = 0;
            string message = "How many " + item + " do you want?";
            UserInterface.PurchaseSuppliesMenu(name, wallet, mySupplies, mySupplier, message);
            string response = Console.ReadLine();
            try
            {
                qty = Int16.Parse(response);
            }
            catch
            {
                message = "What you typed did not seem to work...Let's try this again.  Please hit Enter!";
                UserInterface.PurchaseSuppliesMenu(name, wallet, mySupplies, mySupplier, message);
                Console.ReadLine();
                qty = DetermineQuantityFromPlayer(item);
            }
            return qty;

        }

        private bool EnoughFundsToPurchase(string item, int qty)
        {
            switch (item)
            {
                case "Lemon":
                    if(wallet >= qty * mySupplier.GetPrice("Lemon"))
                    {
                        return true;
                    }
                    else return false;
                    break;
                case "Sugar":
                    if (wallet >= qty * mySupplier.GetPrice("Sugar"))
                    {
                        return true;
                    }
                    else return false;
                    break;
                case "Ice":
                    if (wallet >= qty * mySupplier.GetPrice("Ice"))
                    {
                        return true;
                    }
                    else return false;
                    break;
                default:
                    return false;
            }
            return false;
        }


    }
}
