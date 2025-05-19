namespace LegallyDistinctDino
{
    // Samuel's Matrix system used to render the Game animations without reprinting the entire console screen each time
    // This reduces the flickering effect and optimizes the 'rendering' process
    internal class GameScreen
    {
        public static int Width = 120; // Width of the screen we are rendering or the X coordinate
        public static int Height = 30; // Height of the screen we are rendering or the Y coordinate
        public static char[,] NextFrame = new char[Width, Height]; // Main Matrix used to print to the screen - What we are going to write to the screen the next time Render() is called
        public static char[,] CurrentFrame = new char[Width, Height]; // Secondary Matrix used to store what is currently rendered on the screen

        // Clear the screen for the next render, optionally specify a filler char
        public static void Clear(char fill = ' ')
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    NextFrame[x, y] = fill;
                }
            }
        }

        // set an entire row to an array of chars. ie set 5y to all "-"
        public static void SetRow(char[] rowData, int y)
        {
            if (y < 0 || y >= Height)
            {
                throw new ArgumentOutOfRangeException(nameof(y), "y coordinate is out of bounds.");
            }

            if (rowData.Length > Width)
            {
                throw new ArgumentException("Row data is too long.");
            }

            for (int x = 0; x < rowData.Length; x++)
            {
                NextFrame[x, y] = rowData[x];
            }
        }

        // Change a specific char at x & y coords to value. ie set char at  5x 10y to "-"
        public static void SetCharAt(int x, int y, char value)
        {
            if (y < 0 || y >= Height || x < 0 || x >= Width)
            {
                throw new ArgumentOutOfRangeException("Coordinates are out of bounds.");
            }

            NextFrame[x, y] = value;
        }

        // Place a string at a point on the screen, these can be multi line strings
        public static void SetStringAt(int startX, int startY, string value)
        {
            if (startY < 0 || startY >= Height || startX < 0 || startX >= Width)
            {
                throw new ArgumentOutOfRangeException("Start coordinates are out of bounds.");
            }
            string[] lines = value.Split('\n');
            int currentX = startX;
            for (int i = 0; i < lines.Length; i++)
            {
                if (currentX >= Width) break;
                string line = lines[i];
                char[] chars = line.ToCharArray();
                int currentY = startY;
                for (int j = 0; j < chars.Length; j++)
                {
                    if (currentY >= Height) break;
                    NextFrame[currentX, currentY] = chars[j];
                    currentY++;
                }
                currentX++;
            }
        }

        // Clear a specified area on the screen
        public static void ClearArea(int x1, int y1, int x2, int y2)
        {
            char fill = ' ';
            for (int j = x1; j < x2; j++)
            {
                for (int i = y1; i < y2; i++)
                {
                    NextFrame[j, i] = fill;
                }
            }
        }


        // Compare what is currently on the screen to what we would like to render on the screen and print the difference, this Greatly reduces flicker 
        public static void Render()
        {
            Console.CursorVisible = false;

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (NextFrame[x, y] != CurrentFrame[x, y])
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(NextFrame[x, y]);
                        CurrentFrame[x, y] = NextFrame[x, y];
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
            Height = Console.WindowHeight;
            Width = Console.WindowWidth;
            NextFrame = new char[Width, Height]; // Main Matrix used to print to the screen
            CurrentFrame = new char[Width, Height];
            Console.Clear();
            while (run)
            {
                if (color)
                {
                    Console.BackgroundColor = colors[rand.Next(colors.Length)];
                    Console.ForegroundColor = colors[rand.Next(colors.Length)];
                }
                SetCharAt(rand.Next(Height), rand.Next(Width), chars[rand.Next(chars.Length)]);
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
