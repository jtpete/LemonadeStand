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
    }
}
