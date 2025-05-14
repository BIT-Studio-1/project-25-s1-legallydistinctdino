namespace LegallyDistinctDino
{
    internal class GameScreen
    {
        static int Rows = 30;
        static int Columns = 120;
        static char[,] Screen = new char[Columns, Rows]; // Main Matrix used to print to the screen
        static char[,] PrevScreen = new char[Columns, Rows];


        static void Clear(char fill = ' ')
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    Screen[col, row] = fill;
                }
            }
            Console.Clear();
        }

        // set an entire row to an array of chars
        static void SetRow(char[] rowData, int rowIndex)
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
        static void SetCharAt(int row, int col, char value)
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Columns)
            {
                throw new ArgumentOutOfRangeException("Coordinates are out of bounds.");
            }

            Screen[col, row] = value;
        }

        // Print the Gamescreen to the console, but only print the changes and not the whole screen, this Greatly reduces flicker 
        static void Render()
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
        static void ClearThenRender()
        {
            Clear();
            Render();

        }
    }
}
