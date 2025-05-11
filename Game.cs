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
