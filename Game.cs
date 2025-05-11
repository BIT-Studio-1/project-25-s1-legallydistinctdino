namespace LegallyDistinctDino
{
    internal class Game
    {
        // Starting point for code, anyone can adjust as needed
        static void Main(string[] args)
        {

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

        }

        // Braedon
        static void CreateCharacter()
        {

        }

        // Samuel & Braedon
        static void PlayGame()
        {

        }

        static void EndGame()
        {

        }
    }
}
