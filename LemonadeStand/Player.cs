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
        public double Wallet { get { return wallet; } set { wallet = value; } }
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
        public void MixLemonade()
        {
            int amtLemons = 0;
            int amtSugar = 0;
            int amtIce = 0;
            double price = 0;
            int numPitchers = 0;
            bool mixDone = false;
            string mixName = " ";
            string message = "How would you like to mix your own lemonade?";
            while (!mixDone)
            {
                UserInterface.MixLemonadeMenu(name, wallet, mySupplies, amtLemons, amtSugar, amtIce, price, numPitchers, mixName, message);
                string response = Console.ReadLine().ToLower().Trim();
                switch (response)
                {
                    case "1":
                    case "lemon":
                    case "lemons":
                    case "l":
                        numPitchers = 0;
                        amtLemons = DetermineMixQty("Lemons", amtLemons, amtSugar, amtIce, price, mixName, numPitchers);
                        if (!EnoughToMix("Lemon", amtLemons))
                        {
                            message = "You need to purchase more lemons. Please hit Enter.";
                            amtLemons = 0;
                            UserInterface.MixLemonadeMenu(name, wallet, mySupplies, amtLemons, amtSugar, amtIce, price, numPitchers, mixName, message);
                            Console.ReadLine();
                            message = "How would you like to mix your own lemonade ?";
                        }
                        break;
                    case "2":
                    case "sugar":
                    case "sugars":
                    case "s":
                        numPitchers = 0;
                        amtSugar = DetermineMixQty("Sugar", amtLemons, amtSugar, amtIce, price, mixName, numPitchers);
                        if (!EnoughToMix("Sugar", amtSugar))
                        {
                            message = "You need to purchase more sugar. Please hit Enter.";
                            amtSugar = 0;
                            UserInterface.MixLemonadeMenu(name, wallet, mySupplies, amtLemons, amtSugar, amtIce, price, numPitchers, mixName, message);
                            Console.ReadLine();
                            message = "How would you like to mix your own lemonade ?";
                        }
                        break;
                    case "3":
                    case "ice":
                    case "ice cubes":
                    case "i":
                        numPitchers = 0;
                        amtIce = DetermineMixQty("Ice", amtLemons, amtSugar, amtIce, price, mixName, numPitchers);
                        if (!EnoughToMix("Ice", amtIce))
                        {
                            message = "You need to purchase more ice. Please hit Enter.";
                            amtIce = 0;
                            UserInterface.MixLemonadeMenu(name, wallet, mySupplies, amtLemons, amtSugar, amtIce, price, numPitchers, mixName, message);
                            Console.ReadLine();
                            message = "How would you like to mix your own lemonade ?";
                        }
                        break;
                    case "4":
                    case "pitcher":
                    case "pitchers":
                    case "p":
                        numPitchers = DetermineMixQty("Pitchers", amtLemons, amtSugar, amtIce, price, mixName, numPitchers);
                        if (!EnoughForPitchers(amtLemons, amtSugar, amtIce, numPitchers))
                        {
                            message = "You do not have enough supplies for that many pitchers. Please hit Enter.";
                            numPitchers = 0;
                            UserInterface.MixLemonadeMenu(name, wallet, mySupplies, amtLemons, amtSugar, amtIce, price, numPitchers, mixName, message);
                            Console.ReadLine();
                            message = "How would you like to mix your own lemonade ?";
                        }
                        break;
                    case "5":
                    case "price":
                    case "money":
                        price = DeterminePriceFromUser(amtLemons, amtSugar, amtIce, price, mixName, numPitchers);
                        break;
                    case "6":
                    case "name":
                    case "mix":
                        mixName = DetermineMixName(amtLemons, amtSugar, amtIce, price, mixName, numPitchers);
                        break;
                    case "7":
                    case "make":
                        if (numPitchers > 0)
                        {
                            message = "Confirm mixture, hit Enter.  Cancel Mix, type No";
                            UserInterface.ConfirmMixture(amtLemons, amtSugar, amtIce, price, numPitchers, mixName, message);
                            if (Console.ReadLine().ToLower().Trim() == "no")
                            {
                                message = "Nothing happened.  Update as needed.";
                            }
                            else
                            {
                                ProducePitchers(amtLemons, amtSugar, amtIce, numPitchers, price, mixName);
                                amtLemons = 0;
                                amtSugar = 0;
                                amtIce = 0;
                                numPitchers = 0;
                                message = "Done, All Mixed!";
                            }
                        }
                        break;
                    case "8":
                    case "leave":
                        mixDone = true;
                        break;
                    case "9":
                    case "done":
                        mixDone = true;
                        break;
                    default:
                        break;

                }

            }
        }

        private void ProducePitchers(int amtLemons, int amtSugar, int amtIce, int numPitchers, double price, string mixName)
        {
            double cost = (mySupplier.ALemon.Price * amtLemons) + (mySupplier.ACupOfSugar.Price * amtSugar) + (mySupplier.AnIceCube.Price * amtIce);

            if (amtLemons > 0)
                MySupplies.RemoveSupply("Lemon", amtLemons * numPitchers);
            if (amtSugar > 0)
                MySupplies.RemoveSupply("Sugar", amtSugar * numPitchers);
            if (amtIce > 0)
                MySupplies.RemoveSupply("Ice", amtIce * numPitchers);

            for (int i = 0; i < numPitchers; i++)
            {
                Lemonade thisMix = new Lemonade("Lemonade", 0, price, cost, amtLemons, amtSugar, amtIce, mixName);
                mySupplies.myLemonadePitchers.Add(thisMix);
            }

        }

        private string DetermineMixName(int amtLemons, int amtSugar, int amtIce, double price, string mixName, int numPitchers)
        {
            string message = "What do you want to call this great mix?";
            UserInterface.MixLemonadeMenu(name, wallet, mySupplies, amtLemons, amtSugar, amtIce, price, numPitchers, mixName, message);
            return (Console.ReadLine());
        }

        private double DeterminePriceFromUser(int amtLemons, int amtSugar, int amtIce, double price, string mixName, int numPitchers)
        {
            {
                double qty = 0;
                string message = "How much do you want to sell this mix for?";
                UserInterface.MixLemonadeMenu(name, wallet, mySupplies, amtLemons, amtSugar, amtIce, price, numPitchers, mixName, message);
                string response = Console.ReadLine();
                try
                {
                    qty = Convert.ToDouble(response);
                }
                catch
                {
                    message = "What you typed did not seem to work...Let's try this again.  Please hit Enter!";
                    UserInterface.MixLemonadeMenu(name, wallet, mySupplies, amtLemons, amtSugar, amtIce, price, numPitchers, mixName, message); Console.ReadLine();
                    qty = DeterminePriceFromUser(amtLemons, amtSugar, amtIce, price, mixName, numPitchers);
                }
                return qty;

            }
        }


        private bool EnoughForPitchers(int amtLemons, int amtSugar, int amtIce, int numPitchers)
        {
            if (numPitchers * amtLemons > MySupplies.MyLemons ||
                numPitchers * amtSugar > MySupplies.MySugar ||
                numPitchers * amtIce > MySupplies.MyIce)
                return false;
            else
                return true;
        }

        private bool EnoughToMix(string item, int qty)
        {
            switch (item)
            {
                case "Lemon":
                    if (MySupplies.MyLemons >= qty)
                    {
                        return true;
                    }
                    else return false;
                    break;
                case "Sugar":
                    if (MySupplies.MySugar >= qty)
                    {
                        return true;
                    }
                    else return false;
                    break;
                case "Ice":
                    if (MySupplies.MyIce >= qty)
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

        private int DetermineMixQty(string item, int amtLemons, int amtSugar, int amtIce, double price, string mixName, int numPitchers)
        {
            {
                int qty = 0;
                string message = "How many " + item + " do you want?";
                UserInterface.MixLemonadeMenu(name, wallet, mySupplies, amtLemons, amtSugar, amtIce, price, numPitchers, mixName, message);
                string response = Console.ReadLine();
                try
                {
                    qty = Int16.Parse(response);
                }
                catch
                {
                    message = "What you typed did not seem to work...Let's try this again.  Please hit Enter!";
                    UserInterface.MixLemonadeMenu(name, wallet, mySupplies, amtLemons, amtSugar, amtIce, price, numPitchers, mixName, message); Console.ReadLine();
                    qty = DetermineMixQty(item, amtLemons, amtSugar, amtIce, price, mixName, numPitchers);
                }
                return qty;

            }
        }

        public void PurchaseProduct()
        {
            string message = "What would you like to do?";
            UserInterface.PurchaseSuppliesMenu(name, wallet, mySupplies, mySupplier, message);
            string response = Console.ReadLine().ToLower().Trim();
            int qty;
            switch (response)
            {
                case "1":
                case "lemon":
                case "lemons":
                case "l":
                    qty = DetermineQuantityFromPlayer("Lemons");
                    if (EnoughFundsToPurchase("Lemon", qty))
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
                    for (int i = 0; i < qty; i++)
                    {

                        mySupplies.myLemons.Add(mySupplier.GetNewLemon());
                        wallet -= mySupplier.GetPrice("Lemon");
                    }
                    break;
                case "Sugar":
                    for (int i = 0; i < qty; i++)
                    {
                        mySupplies.mySugar.Add(mySupplier.GetNewSugar());
                        wallet -= mySupplier.GetPrice("Sugar");
                    }
                    break;
                case "Ice":
                    for (int i = 0; i < qty; i++)
                    {
                        mySupplies.myIce.Add(mySupplier.GetNewIce());
                        wallet -= mySupplier.GetPrice("Ice");
                    }
                    break;
            }
        }

        private int DetermineQuantityFromPlayer(string item)
        {
            int qty = 0;
            string message = "How much " + item + " do you want?";
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
                    if (wallet >= qty * mySupplier.GetPrice("Lemon"))
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
