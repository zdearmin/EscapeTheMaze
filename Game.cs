// The static system console class allows us to enter console commands (e.g. WriteLine();) 
// Without typing the full path (e.g. System.Console.WriteLine();)
using static System.Console;

namespace EscapeTheMaze
{
    class Game
    {
        private Map CurrentMap;
        private Player CurrentPlayer;
        // Start of the game, rendering the world and the player, then running the game loop
        public void Start()
        {
            // Changes title from file location to the text we specify
            Title = "Welcome to Escape The Maze!";
            // Hide flashing cursor from console
            CursorVisible = false;

            RunMainMenu();
        }

        private void RunMainMenu()
        {
            string prompt = @"Welcome to Escape The Maze!
Use the arrow keys and press 'Enter' to make your selection.";
            string[] options = {"Play", "About", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    PlayGame();
                    break;
                case 1:
                    DisplayAboutInfo();
                    break;
                case 2:
                    ExitGame();
                    break;
            }
        }

        private void ExitGame()
        {
            WriteLine("Press any key to exit");
            ReadKey(true);
            Clear();
            Environment.Exit(0);
        }

        private void DisplayAboutInfo()
        {  
            Clear();
            WriteLine("Designed by Zach Dearmin and Sebastian Cooper.");
            WriteLine("Press any key to return to the main menu.");
            ReadKey(true);
            RunMainMenu();
        }

        private void PlayGame()
        {
            // Begins the game loop
            RunGameLoop();
        }

        // Text that is displayed at the beginning of the game
        private void DisplayIntro()
        {
            Clear();
            WriteLine("Welcome to Escape The Maze!");
            WriteLine("\nRules:");
            WriteLine(" - Use the arrow keys to move");
            WriteLine(" - You are unable to move through walls");
            Write(" - Move to the exit of the Maze: ");
            ForegroundColor = ConsoleColor.Green;
            WriteLine("X");
            ResetColor();
            // WriteLine(" - Reach the end of the maze in the number of moves specified");
            WriteLine("\n*Press any key to start*");
            ReadKey(true);
        }

        // Text that is displayed at the end of the game
        private void DisplayOutro()
        {
            Clear();
            string prompt = "CONGRATULATIONS! You escaped the maze!";
            string[] options = {"Next Level", "Play Again", "Main Menu", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    // Move to next level
                    break;
                case 1:
                    PlayGame();
                    break;
                case 2:
                    RunMainMenu();
                    break;
                case 3:
                    ExitGame();
                    break;
            }
        }

        // Will draw an individual frame, clear the screen, then render the world and player
        private void DrawMap()
        {
            Clear();
            // Draw the world first then the player so that the player does not get covered by the world
            CurrentMap.Draw();
            CurrentPlayer.Draw();
        }

        // This method will change the players position based on their input
        private void HandlePlayerInput()
        {
            // Reading the user input based on their key input
            // Get only the most recent key input
            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                key = keyInfo.Key;
            } 
            while (KeyAvailable);
            
            switch (key)
            {
                // For each case, it reads the key input (if up arrow)
                // Then moves the player that direction if the position is "walkable" based on our restrictions
                // Y - 1 will move the player - 1 on the y axis (row) if possible, vice versa for Y + 1
                // X - 1 will move the player + 1 on the x axis (column) if possible, vice versa for X + 1
                case ConsoleKey.UpArrow:
                    if (CurrentMap.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (CurrentMap.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (CurrentMap.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (CurrentMap.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
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
            // Loads the DisplayIntro() method
            DisplayIntro();

            string[,] grid = LevelManager.ParseFileToArray("Level1.txt");
            // Renders the world to the console
            CurrentMap = new Map(grid);
            // Renders the player to the console at the position specified
            CurrentPlayer = new Player(2, 1);

            while (true)
            {
                // Draw the world
                DrawMap();
                // Check player input fromt the keyboard to move the player
                HandlePlayerInput();
                // Check if the player reached the exit, and if so, end the game
                string elementAtPlayerPos = CurrentMap.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementAtPlayerPos == "X")
                {
                    break;
                }
                // If the player position is not at the "X", the game will loop back through
                // Gives the console a chance to render.
                System.Threading.Thread.Sleep(20);
            }

            // Loads the DisplayOutro() method
            DisplayOutro();
        }
    }
}