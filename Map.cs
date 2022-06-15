using static System.Console;
namespace EscapeTheMaze
{
    class Map
    {
        // Stores the grid, and the rows and columns of the grid
        private string[,] Grid;
        private int Rows;
        private int Cols;

        public Map(string[,] grid)
        {
            // Calculates the number of rows and columns of the grid
            Grid = grid;
            Rows = Grid.GetLength(0);
            Cols = Grid.GetLength(1);
        }
        
        public void Draw()
        {
            // Looping over the rows and columns in our grid
            // This class replaces local variables in the game class
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    string element = Grid[y, x];
                    SetCursorPosition(x, y);
                    if (element == "X")
                    {
                        ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.White;
                    }
                    Write(element);
                }
            }
        }
    
        public string GetElementAt(int x, int y)
        {
            return Grid[y, x];
        }

        // Determines if the space a player is trying to move to does not have an element there
        public bool IsPositionWalkable(int x, int y)
        {
            //Bounds
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
            {
                return false;
            }
            // Is walkable tile
            return Grid [y,x] == " " || Grid[y, x] == "X";
        }
    }
}
