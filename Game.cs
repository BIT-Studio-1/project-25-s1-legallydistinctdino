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

        }

        // Maria
        static void MainMenu()
        {

        }

        // Samuel
        static void SetupGame()
        {
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

        static void GameOver()
        {

        }
    }
}
