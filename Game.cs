using static System.Net.Mime.MediaTypeNames;

namespace LegallyDistinctDino
{
    internal class Game
    {
        Random rand = new Random();
        static int PlayerDFS; // DFS = Distance from safety
        static int Danger;
        static int DangerDFP; // DFP = Distance from player
        static int ObjectPOS; // Object Position
        static int PlayerPOS = 1; // Player Position

        // Starting point for code, anyone can adjust as needed
        static void Main(string[] args)
        {
            TitleScreen();
            
        }

        // Alina
        static void TitleScreen()
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

            // Ideas to build up later
            // dynamic welcome sign
            MainMenu();
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
            Console.WriteLine("   |   ____     ____  _________  ____       _________  _________   ____        ____  _________  ____   |");
            Console.WriteLine("   |   |  |     |  |  |   ____|  |  |       |   ____|  |  ____  |  |   \\  __  /   |  |   ____|  |  |   |");
            Console.WriteLine("   |   |  | ___ |  |  |  |___    |  |       |  |       |  |  |  |  |    \\/  \\/    |  |  |___    |  |   |");
            Console.WriteLine("   |   |  \\/   \\/  |  |   ___|   |  |       |  |       |  |  |  |  |  |\\__/\\__/|  |  |   ___|   |__|   |");
            Console.WriteLine("   |   \\     _     |  |  |_____  |  |_____  |  |_____  |  |__|  |  |  |        |  |  |  |_____  ____   |");
            Console.WriteLine("   |    \\___/ \\___/   |_______|  |_______|  |_______|  |________|  |__|        |__|  |_______|  |__|   |");
            Console.WriteLine("   |                                                                                                   |");
            Console.WriteLine("   |                             -- Press ENTER to go to the Main Menu --                              |");
            Console.WriteLine("   |                                                                                                   |");
            Console.WriteLine("   |___________________________________________________________________________________________________|");
        }

        // Maria
        static void MainMenu()
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
                    SetupGame(); //starts game
                    break;

                case 1:
                    Console.Clear();
                    TitleScreen(); //back to title screen
                    break;


                case 2:
                    Console.Clear();
                    ExitGame(); 
                    break;




            }

        }

        // Samuel
        // Called before the game is started to setup variables and generate required variables
        static void SetupGame()
        {
            PlayerDFS = 20;
            Danger = 10;
            DangerDFP = PlayerDFS + Danger;
            Console.Write("3....");
            Thread.Sleep(1000);
            Console.Write("2...");
            Thread.Sleep(1000);
            Console.Write("1..");
            Thread.Sleep(1000);
            Console.Write("GO!");
            if (Console.KeyAvailable) {
                Console.ReadKey(intercept: true);
            }
            RunGame();
        }

        // Braedon & Samuel
        static void SetupBackground()
        {
            Console.WriteLine("                          _____                               ____               ");
            Console.WriteLine("                       ___|   \\                              _|   \\              ");
            Console.WriteLine("                      /________\\                           /________\\            ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("_________________________________________________________________________________");
            char[,] background = new char[120,30];
            {
                { }{ }{ }{ }{ }{ }{ }{ }{ };
                { }{ }{ }{ }{ }{ }{ }{ }{ };
                { }{ }{ }{ }{ }{ }{ }{ }{ };
                { }{ }{ }{ }{ }{ }{ }{ }{ };
                { }{ }{ }{ }{ }{ }{ }{ }{ };
                { }{ }{ }{ }{ }{ }{ }{ }{ };
                { }{ }{ }{ }{ }{ }{ }{ }{ };
                { }{ }{ }{ }{ }{ }{ }{ }{ };
                { }{ }{ }{ }{ }{ }{ }{ }{ };
                { }{ }{ }{ }{ }{ }{ }{ }{ };
                { }{ }{ }{ }{ }{ }{ }{ }{ };
                { }{ }{ }{ }{ }{ }{ }{ }{ };
            }
            background[120, 30] = 'i';

            string person = 
                "  o\r\n" +
                " /|\\\r\n" +
                " / \\";
        }

        // Samuel & Braedon
        // Called to run the actual game once everything is set up and ready
        static void RunGame()
        {
            while (PlayConditions())
            {
                if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.RightArrow)
                {
                    // Player has started running instead of walking
                    Console.WriteLine("\nPlayer is Running!");
                    PlayerDFS--;
                }
                else
                {
                    // Player is still walking, danger increases speed
                    Console.WriteLine("\nPlayer is Walking, danger picks up speed!");
                    DangerDFP--;
                }
                // Regular 'walking' movement
                PlayerDFS--;
                DangerDFP--;
                Console.WriteLine($"Player is {PlayerDFS} meters from safety!");
                Console.WriteLine($"Danger is {DangerDFP - PlayerDFS} meters from Player!");
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(intercept: true);
                }
                Thread.Sleep(200);
            }
            GameOver();
        }

        //Braedon
        static void LevelCompScreen()
        {
            Console.Clear();
            Console.WriteLine(".____                      .__    _________                       .__          __        ._. \r\n|    |    _______  __ ____ |  |   \\_   ___ \\  ____   _____ ______ |  |   _____/  |_  ____| | \r\n|    |  _/ __ \\  \\/ // __ \\|  |   /    \\  \\/ /  _ \\ /     \\\\____ \\|  | _/ __ \\   __\\/ __ \\ | \r\n|    |__\\  ___/\\   /\\  ___/|  |__ \\     \\___(  <_> )  Y Y  \\  |_> >  |_\\  ___/|  | \\  ___/\\| \r\n|_______ \\___  >\\_/  \\___  >____/  \\______  /\\____/|__|_|  /   __/|____/\\___  >__|  \\___  >_ \r\n        \\/   \\/          \\/               \\/             \\/|__|             \\/          \\/\\/");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine(" ______\n |    |\n |    |\n |    |\n/      \\\n|      |\n|      |\n|      |\n|      |\n|      |\n|      |\n________");
            Console.WriteLine("   ___ _           ___      _ _           _           _ \r\n  / _ (_)_ __     / __\\___ | | | ___  ___| |_ ___  __| |\r\n / /_\\/ | '_ \\   / /  / _ \\| | |/ _ \\/ __| __/ _ \\/ _` |\r\n/ /_\\\\| | | | | / /__| (_) | | |  __/ (__| ||  __/ (_| |\r\n\\____/|_|_| |_| \\____/\\___/|_|_|\\___|\\___|\\__\\___|\\__,_|");
        }

        //Braedon
        static bool PlayConditions()
        {
            if (ObjectPOS == PlayerPOS)
            {
                GameOver();
            }
            return (PlayerDFS > 0) && (DangerDFP - PlayerDFS > 0);
        }

        // Called once the game has finished
        static void GameOver()
        {
            Thread.Sleep(50);
            if (PlayerDFS <= 0)
            {
                Console.WriteLine("Player made it!");
                LevelCompScreen();
            }
            else
            {
                Console.WriteLine("Danger ate Player :(");
            }
            Console.ReadLine();
            MainMenu();
        }

        //when you decide you don't actually want to play
        static void ExitGame()
        {
            Console.WriteLine("\nThank you for playing!");
            Console.WriteLine("Press enter to exit...");
            Console.ReadKey(); 
            Environment.Exit(0);
        }
    }
}
