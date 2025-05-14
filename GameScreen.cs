namespace LegallyDistinctDino
{
    // Samuel's Matrix system used to render the Game animations without reprinting the entire console screen each time
    // This reduces the flickering effect and optimizes the 'rendering' process
    internal class GameScreen
    {
        public static int Rows = 30; //30
        public static int Columns = 120; //120
        public static char[,] Screen = new char[Columns, Rows]; // Main Matrix used to print to the screen
        public static char[,] PrevScreen = new char[Columns, Rows];

        // Clear the current screen, optionally specify a filler char
        public static void Clear(char fill = ' ')
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    Screen[col, row] = fill;
                }
            }
        }

        // set an entire row to an array of chars
        public static void SetRow(char[] rowData, int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= Rows)
            {
                throw new ArgumentOutOfRangeException(nameof(rowIndex), "Row index is out of bounds.");
            }

            if (rowData.Length > Columns)
            {
                throw new ArgumentException("Row data is too long.");
            }

            for (int col = 0; col < rowData.Length; col++)
            {
                Screen[col, rowIndex] = rowData[col];
            }
        }

        // Change a specific chars at row & col to value
        public static void SetCharAt(int row, int col, char value)
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Columns)
            {
                throw new ArgumentOutOfRangeException("Coordinates are out of bounds.");
            }

            Screen[col, row] = value;
        }

        // Print the Gamescreen to the console, but only print the changes and not the whole screen, this Greatly reduces flicker 
        public static void Render()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    if (Screen[col, row] != PrevScreen[col, row])
                    {
                        Console.SetCursorPosition(col, row);
                        Console.Write(Screen[col, row]);
                        PrevScreen[col, row] = Screen[col, row];
                    }
                }
            }
        }

        // Clear the screen and re-render everything instead of just what has changed
        public static void ClearThenRender()
        {
            Clear();
            Render();
        }

        public static void TestRenderEngine()
        {
            bool run = true;
            Random rand = new Random();
            char[] chars = new char[128];
            Rows = Console.WindowWidth;
            Columns = Console.WindowHeight;
            
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().CopyTo(chars, 0);
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToCharArray().CopyTo(chars, 25);
            "123456789".ToCharArray().CopyTo(chars, 51);
            "`~!@#$%^&*()_+-={}|[]\\:;'<>?,./".ToCharArray().CopyTo(chars, 61);

            Console.CursorVisible = false;
            Console.WriteLine("Beginning render test using the below chars...");
            foreach (char c in chars)
            {
                Console.Write(c);
            }
            Console.WriteLine("\n");
            Console.WriteLine("Press Escape to exit!");
            
            Thread.Sleep(5000);
            Console.Clear();
            while (run)
            {
                GameScreen.SetCharAt(rand.Next(GameScreen.Rows), rand.Next(GameScreen.Columns), Convert.ToChar(chars[rand.Next(chars.Length)]));
                GameScreen.Render();
                //if (rand.Next(10001) == 0)
                //{
                //    GameScreen.Clear();
                //}
                if (Console.KeyAvailable && Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                {
                    run = false;
                }
            }
            Console.Clear();
            GameScreen.Clear();
        }
    }
}
