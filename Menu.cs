using static System.Console;

namespace EscapeTheMaze
{
    class Menu
    {
        // Properties for the menu
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;

        // The menu constructor
        public Menu(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }

        // How the menu looks when it is displayed to the user
        private void DisplayOptions()
        {
            WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;
                string suffix;
                if (i == SelectedIndex)
                {
                    // If selecedIndex (or option) is selected, do this
                    prefix = "** ";
                    suffix = " **";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    // Else, do this
                    prefix = " ";
                    suffix = " ";
                    ForegroundColor = ConsoleColor.DarkGray;
                    BackgroundColor = ConsoleColor.Black;
                }
                // Interpolating the strings above
                WriteLine($"{prefix} {currentOption} {suffix}");
            }
            // Resets colors printed to console
            ResetColor();
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                // Update selectedIndex based on arrow keys.
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    // This if statement keeps cursor from going off top and bottom of menu when arrow keys are pressed
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            }
            while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }    
    }
}