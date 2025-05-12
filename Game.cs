namespace LegallyDistinctDino
{
    internal class Game
    {
        // Starting point for code, anyone can adjust as needed
        static void Main(string[] args)
        {
            SetupGame();
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
        static void RunGame()
        {
            Random rand = new Random();
            int playerDFS = 20; // DFS = Distance from saftey
            int danger = 10;
            int dangerDFP = playerDFS + danger; // DFP = Distance from player

            Console.WriteLine($"\nPlayer is {playerDFS} metres from safety!");
            Console.WriteLine($"Danger is {dangerDFP - playerDFS} metres from Player!");

            while ((playerDFS > 0) && (dangerDFP - playerDFS > 0))
            {
                if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.RightArrow)
                {
                    // Player has started running instead of walking
                    Console.WriteLine("\nPlayer is Running!");
                    playerDFS--;
                }
                else
                {
                    // Player is still walking, danger increases speed
                    Console.WriteLine("\nPlayer is Walking, danger picks up speed!");
                    dangerDFP--;
                }
                // Regular 'walking' movment
                playerDFS--;
                dangerDFP--;
                Thread.Sleep(200);
                Console.WriteLine($"Player is {playerDFS} metres from safety!");
                Console.WriteLine($"Danger is {dangerDFP - playerDFS} metres from Player!");
            }
            Thread.Sleep(50);
            if (playerDFS <= 0)
            {
                Console.WriteLine("Player made it!");
            }
            else
            {
                Console.WriteLine("Danger ate Player :(");
            }
            Console.ReadLine();
        }

        //Braedon(Placed here temporarily so it doesn't get int the way)
        static void HitDetection()
        {
            int obstacle = 5;
            int player = 5;
            if (obstacle == player) 
            {
                GameOver()
            }


        }

        static void GameOver()
        {

        }
    }
}
