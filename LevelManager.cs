using static System.Console;
// Contains a file class that allows .txt files to be read into the code
using System.IO;

namespace EscapeTheMaze
{
    class LevelManager
    {
        protected Game MyGame;

        public LevelManager(Game game)
        {
            MyGame = game;
        }
        public static string[,] ParseFileToArray(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            string firstLine = lines[0];
            int rows = lines.Length;
            int cols = firstLine.Length;
            string[,] grid = new string[rows, cols];
            for (int y = 0; y < rows; y++)
            {
                string line = lines[y];
                for (int x = 0; x < cols; x++)
                {
                    char currentChar = line[x];
                    grid[y, x] = currentChar.ToString();
                }
            }
            return grid;
        }
    }
}