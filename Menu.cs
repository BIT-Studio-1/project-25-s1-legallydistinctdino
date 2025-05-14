using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegallyDistinctDino
{
    internal class Menu
    {

        // Alina
        public static void TitleScreen()
        {
            ConsoleColor[] colors = {
                ConsoleColor.DarkBlue,
                ConsoleColor.DarkCyan,
                ConsoleColor.DarkRed,
                ConsoleColor.DarkYellow,
                ConsoleColor.Gray,
                ConsoleColor.DarkGray,
                ConsoleColor.Blue,
                ConsoleColor.Green,
                ConsoleColor.DarkMagenta,
                ConsoleColor.Cyan,
                ConsoleColor.Red,
                ConsoleColor.Magenta,
                ConsoleColor.Yellow,
                ConsoleColor.DarkGreen
            };
            int iterator = 0;

            while (!Console.KeyAvailable)
            {
                Console.ForegroundColor = colors[iterator];
                PrintWelcome();
                Thread.Sleep(300);
                Console.Clear();
                if (iterator < (colors.Length - 1))
                {
                    iterator += 1;
                }
                else
                {
                    iterator = 0;
                }

            }

            Console.ResetColor();
            while (Console.KeyAvailable)
            {
                Console.ReadKey(intercept: true);
            }

            // MainMenu();
        }

        // print welcome
        static void PrintWelcome()
        {
            int xPosition = System.Console.WindowWidth / 2 - 52;
            int yPosition = System.Console.CursorTop;
            System.Console.SetCursorPosition(xPosition, yPosition);
            Console.WriteLine("   _____________________________________________________________________________________________________");
            System.Console.SetCursorPosition(xPosition, ++yPosition);
            Console.WriteLine("   |                                                                                                   |");
            System.Console.SetCursorPosition(xPosition, ++yPosition);
            Console.WriteLine("   |   ____     ____  _________  ____       _________  _________   ____        ____  _________  ____   |");
            System.Console.SetCursorPosition(xPosition, ++yPosition);
            Console.WriteLine("   |   |  |     |  |  |   ____|  |  |       |   ____|  |  ____  |  |   \\  __  /   |  |   ____|  |  |   |");
            System.Console.SetCursorPosition(xPosition, ++yPosition);
            Console.WriteLine("   |   |  | ___ |  |  |  |___    |  |       |  |       |  |  |  |  |    \\/  \\/    |  |  |___    |  |   |");
            System.Console.SetCursorPosition(xPosition, ++yPosition);
            Console.WriteLine("   |   |  \\/   \\/  |  |   ___|   |  |       |  |       |  |  |  |  |  |\\__/\\__/|  |  |   ___|   |__|   |");
            System.Console.SetCursorPosition(xPosition, ++yPosition);
            Console.WriteLine("   |   \\     _     |  |  |_____  |  |_____  |  |_____  |  |__|  |  |  |        |  |  |  |_____  ____   |");
            System.Console.SetCursorPosition(xPosition, ++yPosition);
            Console.WriteLine("   |    \\___/ \\___/   |_______|  |_______|  |_______|  |________|  |__|        |__|  |_______|  |__|   |");
            System.Console.SetCursorPosition(xPosition, ++yPosition);
            Console.WriteLine("   |                                                                                                   |");
            System.Console.SetCursorPosition(xPosition, ++yPosition);
            Console.WriteLine("   |                             -- Press ENTER to go to the Main Menu --                              |");
            System.Console.SetCursorPosition(xPosition, ++yPosition);
            Console.WriteLine("   |                                                                                                   |");
            System.Console.SetCursorPosition(xPosition, ++yPosition);
            Console.WriteLine("   |___________________________________________________________________________________________________|");
        }


        // Maria
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
