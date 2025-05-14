using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegallyDistinctDino
{
    internal class Menu
    {
        public static void MainMenu()
        {
            Console.Clear();

            Console.WriteLine(" __   __  _______  ___   __    _      __   __  _______  __    _  __   __ ");
            Console.WriteLine("|  |_|  ||   _   ||   | |  |  | |    |  |_|  ||       ||  |  | ||  | |  |");
            Console.WriteLine("|       ||  |_|  ||   | |   |_| |    |       ||    ___||   |_| ||  | |  |");
            Console.WriteLine("|       ||       ||   | |       |    |       ||   |___ |       ||  |_|  |");
            Console.WriteLine("|       ||       ||   | |  _    |    |       ||    ___||  _    ||       |");
            Console.WriteLine("| ||_|| ||   _   ||   | | | |   |    | ||_|| ||   |___ | | |   ||       |");
            Console.WriteLine("|_|   |_||__| |__||___| |_|  |__|    |_|   |_||_______||_|  |__||_______|");
            Console.WriteLine();
            Console.WriteLine("Press 0 to start");
            Console.WriteLine("Press 1 : Back to Title Screen");
            Console.WriteLine("Press 2 : Exit");
            int num = Convert.ToInt32(Console.ReadLine());

            switch (num)
            {
                case 0:
                    Console.Clear();
                    Game.SetupGame(); //starts game
                    break;

                case 1:
                    Console.Clear();
                    Game.PrintWelcome(); //back to title screen
                    break;


                case 2:
                    Console.Clear();
                    Game.ExitGame();
                    break;




            }
        }
    }
}
