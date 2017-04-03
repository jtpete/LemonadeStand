using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public static class UserInterface
    {
        public static string GameHeader()
        {
            Console.Clear();
            Console.WriteLine(" _______________________________________________ ");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|           Welcome to Lemonade Stand           |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|_______________________________________________|");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|                1.  New Game                   |");
            Console.WriteLine("|                2.  Load Game                  |");
            Console.WriteLine("|                3.  High Scores                |");
            Console.WriteLine("|                4.  Quit                       |");
            Console.WriteLine("|_______________________________________________|");
            return Console.ReadLine();
        }
    }
}
