using System.Collections.Generic;
// The static system console class allows us to enter console commands (e.g. WriteLine();) 
// Without typing the full path (e.g. System.Console.WriteLine();)
using static System.Console;

namespace EscapeTheMaze
{
    class Game 
    {
        // References the Map class and creates a new field called CurrentMap
        private Map CurrentMap;
        // References the Player class and creates a new field called CurrentPlayer
        private Player CurrentPlayer;
        // private LevelManager CurrentLevel;
        // Start of the game, rendering the world and the player, then running the game loop
        public void Start()
        {
            // Changes title from file location to the text we specify
            Title = "Welcome to Escape The Maze!";
            // Hide flashing cursor from console
            CursorVisible = false;
            // Runs the RunMainMenu Method
            RunMainMenu();
        }

        // Responible for housing items for our main menu
        private void RunMainMenu()
        {
            // The @ symbol allows for multi line text
            string prompt = @"Welcome to Escape The Maze!

Use the arrow keys and press 'Enter' to make your selection.";
            // The string array holding our menu options
            string[] options = {"Play", "Select Level", "About", "Exit" };
            // Creating a new variable menu constructor and its two parameter (prompt and options)
            Menu mainMenu = new Menu(prompt, options);
            // Calling in our run method from the menu class and storing it in an int
            int selectedIndex = mainMenu.Run();
            // This switch will output a prompt and execute one of the methods,
            // based on which option is selected
            switch (selectedIndex)
            {
                case 0:
                    PlayGame();
                    break;
                case 1:
                    LevelSelctor();
                    break;
                case 2:
                    DisplayAboutInfo();
                    break;
                case 3:
                    ExitGame();
                    break;
            }
        }

        // The play game method calls in the game loop method
        private void PlayGame()
        {
            // Begins the game loop
            RunGameLoop();
        }

        private void LevelSelctor()
        {
            Clear();
            string prompt = "Select which level you would like to play.";
            string[] options = {"Level 1", "Level 2", "Level 3", "Level 4", "Level 5", "Return To Main Menu" };
            // Creating a new variable menu constructor and its two parameter (prompt and options)
            Menu mainMenu = new Menu(prompt, options);
            // Calling in our run method from the menu class and storing it in an int
            int selectedIndex = mainMenu.Run();
            // This switch will output a prompt and execute one of the methods,
            // based on which option is selected
            switch (selectedIndex)
            {
                case 0:
                    DisplayIntro();
                    string[,] grid1 = LevelManager.ParseFileToArray("Level1.txt");
                    CurrentMap = new Map(grid1);
                    CurrentPlayer = new Player(2, 1);
                    while (true)
                    {
                    DrawMap();
                    HandlePlayerInput();
                    string elementAtPlayerPos = CurrentMap.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                    if (elementAtPlayerPos == "X")
                    {
                        break;
                    }
                    System.Threading.Thread.Sleep(20);
                    }
                    DisplayOutro();
                    break;
                case 1:
                    DisplayIntro();
                    string[,] grid2 = LevelManager.ParseFileToArray("Level2.txt");
                    CurrentMap = new Map(grid2);
                    CurrentPlayer = new Player(2, 1);
                    while (true)
                    {
                    DrawMap();
                    HandlePlayerInput();
                    string elementAtPlayerPos = CurrentMap.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                    if (elementAtPlayerPos == "X")
                    {
                        break;
                    }
                    System.Threading.Thread.Sleep(20);
                    }
                    DisplayOutro();
                    break;
                case 2:
                    DisplayIntro();
                    string[,] grid3 = LevelManager.ParseFileToArray("Level3.txt");
                    CurrentMap = new Map(grid3);
                    CurrentPlayer = new Player(1, 29);
                    while (true)
                    {
                    DrawMap();
                    HandlePlayerInput();
                    string elementAtPlayerPos = CurrentMap.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                    if (elementAtPlayerPos == "X")
                    {
                        break;
                    }
                    System.Threading.Thread.Sleep(20);
                    }
                    DisplayOutro();
                    break;
                case 3:
                    DisplayIntro();
                    string[,] grid4 = LevelManager.ParseFileToArray("Level4.txt");
                    CurrentMap = new Map(grid4);
                    CurrentPlayer = new Player(2, 1);
                    while (true)
                    {
                    DrawMap();
                    HandlePlayerInput();
                    string elementAtPlayerPos = CurrentMap.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                    if (elementAtPlayerPos == "X")
                    {
                        break;
                    }
                    System.Threading.Thread.Sleep(20);
                    }
                    DisplayOutro();
                    break;
                case 4:
                    DisplayIntro();
                    string[,] grid5 = LevelManager.ParseFileToArray("Level5.txt");
                    CurrentMap = new Map(grid5);
                    CurrentPlayer = new Player(30, 1);
                    while (true)
                    {
                    DrawMap();
                    HandlePlayerInput();
                    string elementAtPlayerPos = CurrentMap.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                    if (elementAtPlayerPos == "X")
                    {
                        break;
                    }
                    System.Threading.Thread.Sleep(20);
                    }
                    DisplayOutro();
                    break;
                case 5:
                    RunMainMenu();
                    break;
            }
        }

        private void DisplayAboutInfo()
        {  
            Clear();
            WriteLine("Designed by Zach Dearmin and Sebastian Cooper, 2022.");
            WriteLine("\nPress any key to return to the main menu.");
            ReadKey(true);
            RunMainMenu();
        }

        // The ExitGame method to clear the console and exit the game
        private void ExitGame()
        {
            Clear();
            WriteLine("Press any key to exit");
            // ReadKey(true) will allow any key to be pressed so the command can be executed
            ReadKey(true);
            Environment.Exit(0);
        }


        // Text that is displayed at the beginning of the game
        private void DisplayIntro()
        {
            // Clears the console once the game starts
            Clear();
            WriteLine("Welcome to Escape The Maze!");
            WriteLine("\nRules:");
            WriteLine(" - Use the arrow keys to move through the maze.");
            WriteLine(" - You are unable to move through walls.");
            Write(" - Move to the exit of the Maze: ");
            // Changes the color printed to the console
            ForegroundColor = ConsoleColor.Green;
            WriteLine("X");
            // Resets the console color back to default so not everything afterwards is green
            ResetColor();
            WriteLine("\nPress 'Escape' at any time to exit the maze.");
            WriteLine("\n*Press any key to start*");
            ReadKey(true);
        }

        // Text that is displayed at the end of the game
        private void DisplayOutro()
        {
            // Clears the console once the game is completed
            Clear();
            // Prints the prompt and options to the console, same as the main menu process
            string prompt = "CONGRATULATIONS! You escaped the maze!";
            string[] options = {"Select Level", "Play Again", "Main Menu", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    LevelSelctor();
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
                case ConsoleKey.Escape:
                    Clear();
                    ExitGame();
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
            
            while(true)
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