namespace LegallyDistinctDino
{
    // Samuel's Matrix system used to render the Game animations without reprinting the entire console screen each time
    // This reduces the flickering effect and optimizes the 'rendering' process
    internal class GameScreen
    {
        public static int Width = 120; // Width of the screen we are rendering or the X coordinate
        public static int Height = 30; // Height of the screen we are rendering or the Y coordinate
        public static char[,] NextFrame = new char[Width, Height]; // Main Matrix used to print to the screen - What we are going to write to the screen the next time Render() is called

        // These variables should not be used outside of the class as they are only intended for internal use
        private static char[,] BlankFrame = CreateBlankFrame(); // Blank frame used to clear the screen
        private static bool[,] ChangedFrame = new bool[Width,Height]; // Cache of what has changed 

        private static char[,] CreateBlankFrame(char fill=' ')
        {
            char[,] frame = new char[Width, Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    frame[x, y] = fill;
                }
            }
            return frame;
        }

        public static void SetScreenDimensions(int width, int height)
        {
            Width = width;
            Height = height;
            NextFrame = new char[width, height]; // Main Matrix used to print to the screen
            ChangedFrame = new bool[width, height];
            BlankFrame = CreateBlankFrame();
        }

        // Clear the screen for the next render, optionally specify a filler char
        public static void Clear(char fill = ' ')
        {
            if (fill == ' ')
            {
                Array.Copy(BlankFrame, NextFrame, BlankFrame.Length);
            } else
            {
                Array.Copy(CreateBlankFrame(fill), NextFrame, Width * Height);
            }
            ChangedFrame = new bool[Width, Height];
            Render(true);
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
                if (NextFrame[x, y] == '\0' || NextFrame[x, y] == ' ')
                {
                    NextFrame[x, y] = rowData[x];
                    ChangedFrame[x, y] = true;
                }
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
            ChangedFrame[x, y] = true;
        }

        // Place a string at a point on the screen, these can be multi line strings
        public static void SetStringAt(int startX, int startY, string value)
        {
            if (startY < 0 || startY >= Height || startX < 0 || startX >= Width)
            {
                throw new ArgumentOutOfRangeException("Start coordinates are out of bounds.");
            }
            // Split value up into an array were each part of the array ends in a \n or line break
            string[] lines = value.Split('\n');
            // set our current y value to the y we want to start at
            int currentY = startY;
            foreach (string line in lines)
            {
                // if our current y is more than the height of our screen we don't do anything
                if (currentY >= Height) break;
                // break each line up into the chars that it contains
                char[] chars = line.ToCharArray();
                // set our current x value to where we want the line to start, this needs to be reset for each line
                int currentX = startX;
                foreach (char c in chars)
                {
                    // if our current x value is more than the width of our screen we don't do anything
                    if (currentX >= Width) break;
                    // add the char to the next frame at the current x and y level
                    NextFrame[currentX, currentY] = c;
                    ChangedFrame[currentX, currentY] = true;
                    // increment the x value before adding the next char in the line
                    currentX++;
                }
                // increment the y value before adding the next line
                currentY++;
            }
        }

        public static void ClearStringAt(int startX, int startY, string value)
        {
            char fill = ' ';
            string[] lines = value.Split('\n');
            int currentY = startY;

            //int clearWidth = 8;

            foreach (string line in lines)
            {
                if (currentY >= Height) break;

                char[] chars = line.ToCharArray();

                int currentX = startX;
                foreach (char c in chars)
                {
                    if (currentX >= Width) break;
                    NextFrame[currentX, currentY] = fill;
                    ChangedFrame[currentX, currentY] = true;
                    currentX++;
                }

                currentY++;
            }
        }

        // Clear a specified area on the screen
        public static void ClearArea(int x1, int y1, int x2, int y2)
        {
            char fill = '*';
            if (x1 >= Width) x1 = Width;
            if (x2 >= Width) x2 = Width;
            if (y1 >= Height) y1 = Height;
            if (y2 >= Height) y2 = Height;

            if (x1 < 0) x1 = 0;
            if (x2 < 0) x2 = 0;
            if (y1 < 0) y1 = 0;
            if (y2 < 0) y2 = 0;

            for (int x = x1; x < x2; x++)
            {
                // in the Console y:0 is the top left corner. To get around this we decrease the y instead of increasing it
                for (int y = y1; y > y2; y--)
                {
                    NextFrame[x, y] = fill;
                    ChangedFrame[x, y] = true;
                }
            }
        }


        // Compare what is currently on the screen to what we would like to render on the screen and print the difference, this Greatly reduces flicker 
        public static void Render(bool force=false)
        {
            Console.CursorVisible = false;

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (!ChangedFrame[x, y] && !force) continue;

                    Console.SetCursorPosition(x, y);
                    Console.Write(NextFrame[x, y]);
                    ChangedFrame[x, y] = false;
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
            SetScreenDimensions(Console.WindowWidth, Console.WindowHeight);
            Console.Clear();
            while (run)
            {
                if (color)
                {
                    Console.BackgroundColor = colors[rand.Next(colors.Length)];
                    Console.ForegroundColor = colors[rand.Next(colors.Length)];
                }
                SetCharAt(rand.Next(Width), rand.Next(Height), chars[rand.Next(chars.Length)]);
                if (rand.Next(11) == 0)
                {
                    GameScreen.Clear();
                }
                Render();
                
                if (Console.KeyAvailable && Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                {
                    run = false;
                }
            }
            Clear();
            Console.ResetColor();
            Console.Clear();
        }
    }
}
