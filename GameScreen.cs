namespace LegallyDistinctDino
{
    // Samuel's Matrix system used to render the Game animations without reprinting the entire console screen each time
    // This reduces the flickering effect and optimizes the 'rendering' process
    internal class GameScreen
    {
        public static int Rows = 30; //30 Height - By defining a row you are defining a point along the Y axis
        public static int Columns = 120; //120 Width - By defining a column you are defining a point along the X axis
        public static char[,] Screen = new char[Columns, Rows]; // Main Matrix used to print to the screen - What we are going to write to the screen th enext time Render() is called
        public static char[,] PrevScreen = new char[Columns, Rows]; // Secondary Matrix used to store what is currently on the screen

        // Clear the screen for the next render, optionally specify a filler char
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
        
        // set an entire row to an array of chars. ie set row 5 to all "-"
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

        // Change a specific char at row & col to value. ie set char on row 5 col 10 to "-"
        public static void SetCharAt(int row, int col, char value)
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Columns)
            {
                throw new ArgumentOutOfRangeException("Coordinates are out of bounds.");
            }

            Screen[col, row] = value;
        }

        // Place a string at a point on the screen, these can be multi line strings
        public static void SetStringAt(int  startRow, int startCol, string value)
        {
            if (startRow < 0 || startRow >= Rows || startCol < 0 || startCol >= Columns)
            {
                throw new ArgumentOutOfRangeException("Start Row or Start Columns is out of bounds.");
            }
            string[] lines = value.Split('\n');
            int currentRow = startRow;
            for (int i = 0; i < lines.Length; i++)
            {
                if (currentRow >= Rows) break;
                string line = lines[i];
                char[] chars = line.ToCharArray();
                int currentCol = startCol;
                for (int j = 0; j < chars.Length; j++)
                {
                    if (currentCol >= Columns) break;
                    Screen[currentCol, currentRow] = chars[j];
                    currentCol++;
                }
                currentRow++;
            }
        }

        // Clear a specified area on the screen
        public static void ClearArea(int row1, int col1, int row2, int col2)
        {
            //Still being worked on (Not currently working)
            char fill = ' ';
            for (int i=row1; i < row2; i++)
            {
                for (int j = col1; j < col2; j++)
                {
                    Screen[j, i] = fill;
                }
            }
        }
    

        // Compare what is currently on the screen to what we would like to render on the screen and print the difference, this Greatly reduces flicker 
        public static void Render()
        {
            Console.CursorVisible = false;
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

        // Clear the screen and re-render everything instead of only rendering the difference
        public static void ClearThenRender()
        {
            Clear();
            Render();
        }

        // Test the render engine by generating random chars at random points on the screen, optionally add colour to the screen
        public static void TestRenderEngine()
        {
            bool run = true;
            Random rand = new Random();
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

            char[] chars = new char[93];
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().CopyTo(chars, 0);
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToCharArray().CopyTo(chars, 25);
            "0123456789".ToCharArray().CopyTo(chars, 51);
            "`~!@#$%^&*()_+-={}|[]\\:;'<>?,./\"".ToCharArray().CopyTo(chars, 61);

            Console.CursorVisible = false;
            Console.WriteLine("Beginning render test using the below chars...");
            foreach (char c in chars)
            {
                Console.Write(c);
            }
            Console.WriteLine("\n");
            Console.WriteLine("Would you like colours in the test? (y/n)");
            bool color = false;
            if (Console.ReadLine() == "y")
            {
                color = true;
            }
            Console.WriteLine("Test Will start in 5 seconds!");
            Console.WriteLine("Press Escape at anytime to exit!");       
            Thread.Sleep(5000);
            Rows = Console.WindowHeight;
            Columns = Console.WindowWidth;
            Screen = new char[Columns, Rows]; // Main Matrix used to print to the screen
            PrevScreen = new char[Columns, Rows];
            Console.Clear();
            while (run)
            {
                if (color)
                {
                    Console.BackgroundColor = colors[rand.Next(colors.Length)];
                    Console.ForegroundColor = colors[rand.Next(colors.Length)];
                }
                SetCharAt(rand.Next(Rows), rand.Next(Columns), chars[rand.Next(chars.Length)]);
                Render();
                //if (rand.Next(10001) == 0)
                //{
                //    GameScreen.Clear();
                //}
                if (Console.KeyAvailable && Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                {
                    run = false;
                }
            }
            Console.ResetColor();
            Console.Clear();
            Clear();
        }
    }
}
