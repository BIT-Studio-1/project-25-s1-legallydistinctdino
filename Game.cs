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

        // timer variables
        static int seconds = 0;
        static int minutes = 0;
        static bool isPlaying = true;



        // Starting point for code, anyone can adjust as needed
        static void Main(string[] args)
        {
            
            Menu.TitleScreen();
            
            
        }

        public static async Task StartTimer()
        {
            // isPlaying has to be set to false when GameOver
            while (isPlaying)
            {
                // print the current minutes and seconds
                GameScreen.SetStringAt(System.Console.WindowWidth - 5, 1, minutes + ":0" + seconds);
                GameScreen.Render();

                // counting and printing the seconds
                for (int i = 0; i < 60; i++) {
                    await Task.Delay(1000);
                    seconds++;
                    if (seconds < 10)
                    {
                        GameScreen.SetStringAt(System.Console.WindowWidth - 5, 1, minutes + ":0" + seconds);
                        GameScreen.Render();
                    }
                    else
                    {
                        GameScreen.SetStringAt(System.Console.WindowWidth - 5, 1, minutes + ":" + seconds);
                        GameScreen.Render();
                    }
                }
                minutes+=1;
                seconds = 0;
            }
        }

        // Samuel
        // Called before the game is started to setup variables and generate required variables
        public static void SetupGame()
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
            //Console.CursorVisible = false;
            //ClearGameScreen();
            //SetRow(new string(' ', 120).ToCharArray(), 28);
            RunGame();
        }

        // Samuel & Braedon
        // Called to run the actual game once everything is set up and ready
        public static void RunGame()
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

        //(Braedon) Prints a screen when you complete a level
        static void LevelCompScreen()
        {
            Console.Clear();
            //This ASCII art says level complete
            Console.WriteLine(".____                      .__    _________                       .__          __        ._. \r\n|    |    _______  __ ____ |  |   \\_   ___ \\  ____   _____ ______ |  |   _____/  |_  ____| | \r\n|    |  _/ __ \\  \\/ // __ \\|  |   /    \\  \\/ /  _ \\ /     \\\\____ \\|  | _/ __ \\   __\\/ __ \\ | \r\n|    |__\\  ___/\\   /\\  ___/|  |__ \\     \\___(  <_> )  Y Y  \\  |_> >  |_\\  ___/|  | \\  ___/\\| \r\n|_______ \\___  >\\_/  \\___  >____/  \\______  /\\____/|__|_|  /   __/|____/\\___  >__|  \\___  >_ \r\n        \\/   \\/          \\/               \\/             \\/|__|             \\/          \\/\\/");
            Thread.Sleep(1000);
            Console.Clear();
            //Clears and then prints a bottle of gin in ASCII and says gin collected in ASCII
            Console.WriteLine(" ______\n |    |\n |    |\n |    |\n/      \\\n|      |\n|      |\n|      |\n|      |\n|      |\n|      |\n________");
            Console.WriteLine("   ___ _           ___      _ _           _           _ \r\n  / _ (_)_ __     / __\\___ | | | ___  ___| |_ ___  __| |\r\n / /_\\/ | '_ \\   / /  / _ \\| | |/ _ \\/ __| __/ _ \\/ _` |\r\n/ /_\\\\| | | | | / /__| (_) | | |  __/ (__| ||  __/ (_| |\r\n\\____/|_|_| |_| \\____/\\___/|_|_|\\___|\\___|\\__\\___|\\__,_|");


        }

        //(Braedon) Checks if the conditions for playing are active and returns if changes allowing the game to end
        public static bool PlayConditions()
        {
            if (ObjectPOS == PlayerPOS)
            {
                GameOver();
            }
            return (PlayerDFS > 0) && (DangerDFP - PlayerDFS > 0);
        }

        // Called once the game has finished
        public static void GameOver()
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
            while (Console.KeyAvailable)
            {
                Console.ReadKey(intercept: true);
            }
            Console.ReadLine();
            Console.Clear();
        }

        //when you decide you don't actually want to play
        public static void ExitGame()
        {
            Console.WriteLine("\nThank you for playing!");
            Console.WriteLine("Press enter to exit...");
            Console.ReadKey(); 
            Environment.Exit(0);
            
        }
    }
}
