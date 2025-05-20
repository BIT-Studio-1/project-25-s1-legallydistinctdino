using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LegallyDistinctDino
{
    internal class Menu
    {

        // Alina
        public static void TitleScreen()
        {
            // Enum with colors to change the welcome sign
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
                PrintDino();
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

            MainMenu();
        }

        // print welcome
        static void PrintWelcome()
        {
            int xPosition = System.Console.WindowWidth / 2 - 46;
            int yPosition = System.Console.CursorTop;
            System.Console.SetCursorPosition(xPosition, yPosition);
            Console.WriteLine("____     ____  _________  ____       _________  _________   ____        ____  _________  ____");
            System.Console.SetCursorPosition(xPosition, ++yPosition);
            Console.WriteLine("|  |     |  |  |   ____|  |  |       |   ____|  |  ____  |  |   \\  __  /   |  |   ____|  |  |");
            System.Console.SetCursorPosition(xPosition, ++yPosition);
            Console.WriteLine("|  | ___ |  |  |  |___    |  |       |  |       |  |  |  |  |    \\/  \\/    |  |  |___    |  |");
            System.Console.SetCursorPosition(xPosition, ++yPosition);
            Console.WriteLine("|  \\/   \\/  |  |   ___|   |  |       |  |       |  |  |  |  |  |\\__/\\__/|  |  |   ___|   |__|");
            System.Console.SetCursorPosition(xPosition, ++yPosition);
            Console.WriteLine("\\     _     |  |  |_____  |  |_____  |  |_____  |  |__|  |  |  |        |  |  |  |_____  ____");
            System.Console.SetCursorPosition(xPosition, ++yPosition);
            Console.WriteLine(" \\___/ \\___/   |_______|  |_______|  |_______|  |________|  |__|        |__|  |_______|  |__|");
            System.Console.SetCursorPosition(xPosition, ++yPosition);
            Console.WriteLine("\n");
            System.Console.SetCursorPosition(xPosition, ++yPosition);
            Console.WriteLine("                                 -- Press ENTER to go to the Main Menu --");
        }

        static void PrintDino()
        {
            System.Console.WriteLine("                              ______________");
            System.Console.WriteLine("                            __|  __         |__");
            System.Console.WriteLine("                           |    |__|           |");
            System.Console.WriteLine("                           |                   |");
            System.Console.WriteLine("                           |         __________|");
            System.Console.WriteLine("                           |         |_____");
            System.Console.WriteLine("___                      __|       ________|");
            System.Console.WriteLine("|  |                  __|          |");
            System.Console.WriteLine("|  |__             __|             |_____");
            System.Console.WriteLine("|     |__        __|                ___  |");
            System.Console.WriteLine("|        |______|                  |  |__|");
            System.Console.WriteLine("|                                |");
            System.Console.WriteLine("|__                            __|");
            System.Console.WriteLine("   |__                      __|");
            System.Console.WriteLine("      |__                __|");
            System.Console.WriteLine("         |__       ___   |");
            System.Console.WriteLine("            |    __|  |  |");
            System.Console.WriteLine("            |  __|    |  |");
            System.Console.WriteLine("            |  |__    |  |__ ");
            System.Console.WriteLine("            |_____|   |_____|");
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
            Console.WriteLine("Press 3 : INTERACTIVE TEST");
            Console.WriteLine("Press 4 : How to play");
            int num = Convert.ToInt32(Console.ReadLine());

            switch (num)
            {
                case 0:
                    Console.Clear();
                    Game.SetupGame(); //starts game
                    break;

                case 1:
                    Console.Clear();
                    TitleScreen(); //back to title screen
                    break;


                case 2:
                    Console.Clear();
                    Game.ExitGame();
                    break;

                case 3:
                    Console.Clear();
                    Interactive.Calls();
                    break;

                case 4:
                    Console.Clear();
                    HowToPlay();
                    break;

                case 9999: // Dev menu item to test render engine
                    GameScreen.TestRenderEngine();
                    TitleScreen();
                    break;



            }

            
        }
        public static void HowToPlay()
        {
            //Says "How To Play!" in ascii art
            Console.WriteLine(" _   _                 _____       ____  _             _ \r\n| | | | _____      __ |_   _|__   |  _ \\| | __ _ _   _| |\r\n| |_| |/ _ \\ \\ /\\ / /   | |/ _ \\  | |_) | |/ _` | | | | |\r\n|  _  | (_) \\ V  V /    | | (_) | |  __/| | (_| | |_| |_|\r\n|_| |_|\\___/ \\_/\\_/     |_|\\___/  |_|   |_|\\__,_|\\__, (_)\r\n                                                 |___/   ");
            Console.WriteLine(new string('-',80));
            Console.WriteLine("In this game you're playing Vaughn and being chased while running and jumping over obstacles.\n How to play: \n Press Space to jump \n Press C to crouch \n Press right arrow to run faster");
            Console.WriteLine("-- Press ENTER to return to the Main Menu! --");
            Console.ReadLine();
            MainMenu();
        }

    }

}
