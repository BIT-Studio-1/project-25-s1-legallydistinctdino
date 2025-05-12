namespace LegallyDistinctDino
{
    internal class Game
    {
        static int PlayerDFS = 20; // DFS = Distance from safety
        static int Danger = 10;
        static int DangerDFP = PlayerDFS + Danger; // DFP = Distance from player
        static int ObjectPOS;
        static int PlayerPOS = 1;

        // Starting point for code, anyone can adjust as needed
        static void Main(string[] args)
        {
            TitleScreen();
            MainMenu();
        }

        // Alina
        static void TitleScreen()
        {
            // Welcome
            Console.WriteLine("   ____     ____  _________  ____       _________  _________   ____        ____  _________  ____  ");
            Console.WriteLine("   |  |     |  |  |   ____|  |  |       |   ____|  |  ____  |  |   \  __  /   |  |   ____|  |  |  ");
            Console.WriteLine("   |  | ___ |  |  |  |___    |  |       |  |       |  |  |  |  |    \/  \/    |  |  |___    |  |  ");
            Console.WriteLine("   |  \/   \/  |  |   ___|   |  |       |  |       |  |  |  |  |  |\__/\__/|  |  |   ___|   |__|  ");
            Console.WriteLine("   \     _     |  |  |_____  |  |_____  |  |_____  |  |__|  |  |  |        |  |  |  |_____  ____  ");
            Console.WriteLine("    \___/ \___/   |_______|  |_______|  |_______|  |________|  |__|        |__|  |_______|  |__|  ");
            Console.WriteLine("\n");
            Console.WriteLine("                          -- Press ENTER to go to the Main Menu --");
            Console.ReadLine();

            // Ideas to build up later
            // Changing Background-color
            // add frame
            // dynamic welcome sign
        }

        // Maria
        static void MainMenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("Press 0 to start");
            Console.WriteLine("Press 1 : Create Character");
            Console.WriteLine("Press 2 : Settings");
            Console.WriteLine("Press 3 : Exit");
            int num = Convert.ToInt32(Console.ReadLine());

            switch (num)
            {
                case 0:
                    PlayGame();
                    break;

                case 1:
                    CreateCharacter();
                    break;

                case 2:
                    SetupGame();
                    break;

                case 3:
                    EndGame();
                    break;




            }

        }

        // Samuel
        // Called before the game is started to setup variables and generate required variables
        static void SetupGame()
        {
            Console.Write("3....");
            Thread.Sleep(1000);
            Console.Write("2...");
            Thread.Sleep(1000);
            Console.Write("1..");
            Thread.Sleep(1000);
            Console.Write("GO!");
            RunGame();
        }

        // Braedon
        static void CreateCharacter()
        {

        }

        // Samuel & Braedon
        // Called to run the actual game once everything is set up and ready
        static void RunGame()
        {
            Random rand = new Random();
            

            while (LoseConditions())
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
                Thread.Sleep(200);
                Console.WriteLine($"Player is {PlayerDFS} meters from safety!");
                Console.WriteLine($"Danger is {DangerDFP - PlayerDFS} meters from Player!");
            }
            GameOver();
        }

        //Braedon
        static bool LoseConditions()
        {
            if (ObjectPOS == PlayerPOS) 
            {
                GameOver();

            }
            return ((PlayerDFS > 0) && (DangerDFP - PlayerDFS > 0));
        }

        // Called once the game has finished
        static void GameOver()
        {
            Thread.Sleep(50);
            if (PlayerDFS <= 0)
            {
                Console.WriteLine("Player made it!");
            }
            else
            {
                Console.WriteLine("Danger ate Player :(");
            }
            Console.ReadLine();

        }
    }
}
