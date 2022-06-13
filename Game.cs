// The static system console class allows us to enter console commands (e.g. WriteLine();) 
// Without typing the full path (e.g. System.Console.WriteLine();)
using static System.Console;
namespace EscapeTheMaze
{
    class Game 
    {
        private Map MyWorld;
        private Player CurrentPlayer;

        // Start of the game, rendering the world and the player, then running the game loop
        public void Start()
        {
            // Changes title from file location to the text we specify
            Title = "Welcome to Escape the Maze!";
            // Hide flashing cursor from console
            CursorVisible = false;
            
            // A 5x5 array of strings called grid
            string[,] grid = {
                { "_", "_", "_", "_", "_", "_", "_" },
                { "|", " ", "|", " ", " ", " ", "X" },
                { " ", " ", "|", " ", "|", " ", "|" },
                { "|", " ", "|", " ", "|", " ", "|" },
                { "|", " ", " ", " ", "|", " ", "|" },
                { "_", "_", "_", "_", "_", "_", "_" },
            };

            // Renders the world to the console
            MyWorld = new Map(grid);
            // Renders the player to the console at the position specified
            CurrentPlayer = new Player(0, 2);
            // Begins the game loop
            RunGameLoop();
        }

        // Text that is displayed at the beginning of the game
        private void DisplayIntro()
        {
            WriteLine("Welcome to Escape The Maze!");
            WriteLine("\nRules:");
            WriteLine(" - Use the arrow keys to move");
            WriteLine(" - You are unable to move through walls");
            WriteLine(" - Make your way to the exit of the maze: ");
            ForegroundColor = ConsoleColor.Green;
            WriteLine("X");
            ResetColor();
            WriteLine(" - Reach the end of the maze in the number of moves specified");
            WriteLine("\n*Press any key to start*");
            ReadKey(true);
        }

        // Text that is displayed at the end of the game
        private void DisplayOutro()
        {
            Clear();
            WriteLine("CONGRATULATIONS! You escaped the maze!");
            WriteLine("Press any key to exit...");
            ReadKey(true);
        }

        // Will draw an individual frame, clear the screen, then render the world and player
        private void DrawFrame()
        {
            Clear();
            // Draw the world first then the player so that the player does not get covered by the world
            MyWorld.Draw();
            CurrentPlayer.Draw();
        }

        // This method will change the players position based on their input
        private void HandlePlayerInput()
        {
            // Reading the user input based on their key input
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                // For each case, it reads the key input (if up arrow)
                // Then moves the player that direction if the position is "walkable" based on our restrictions
                // Y - 1 will move the player - 1 on the y axis (row) if possible, vice versa for Y + 1
                // X - 1 will move the player + 1 on the x axis (column) if possible, vice versa for X + 1
                case ConsoleKey.UpArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                if (MyWorld.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                {
                    CurrentPlayer.X += 1;
                }
                    break;
                default:
                    break;
            }
        }

        // The loop that runs the game until the player reaches the exits
        private void RunGameLoop()
        {
            DisplayIntro();
            while (true)
            {
                // Draw the world
                DrawFrame();
                // Check player input fromt the keyboard to move the player
                HandlePlayerInput();
                // Check if the player reached the exit, and if so, end the game
                string elementAtPlayerPos = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementAtPlayerPos == "X")
                {
                    break;
                }
                // If the player position is not at the "X", the game will loop back through
                // Gives the console a chance to render.
                System.Threading.Thread.Sleep(20);
            }
            DisplayOutro();
        }
    }
}