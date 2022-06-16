using static System.Console;
// Contains a file class that allows .txt files to be read into the code
using System.IO;

namespace EscapeTheMaze
{
    class LevelManager
    {   
        // protected Game MyGame;

        // public LevelManager(Game game)
        // {
        //     MyGame = game;
        // }
        // Grid of strings that parses .txt file into an array
        public static string[,] ParseFileToArray(string filePath)
        {
            // Using the Sytem.IO to pass in a file and read the line to then create an array
            string[] lines = File.ReadAllLines(filePath);
            string firstLine = lines[0];
            // Measures the number of lines in the file
            int rows = lines.Length;
            // Measures the number of characters in the first line
            int cols = firstLine.Length;
            // Build a new grid based on the measured rows and columns from above
            string[,] grid = new string[rows, cols];
            // This for loop builds the grid for each line and character in the .txt file
            for (int y = 0; y < rows; y++)
            {
                string line = lines[y];
                for (int x = 0; x < cols; x++)
                {
                    char currentChar = line[x];
                    grid[y, x] = currentChar.ToString();
                }
            }
            // Returns the grid constructed above
            return grid;
        }
    }
}