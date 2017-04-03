using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        private string name;
        private double wallet;
        public string Name { get { return name; } set { name = value; } }

        public Player(string name, double startAmount)
        {
            this.name = name;
            wallet = startAmount;
        }

        public void GetNameFromUser()
        {
            string response;

            Console.WriteLine($"{name} is such a boring name, what shall I call you?.");
            response = Console.ReadLine();
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
