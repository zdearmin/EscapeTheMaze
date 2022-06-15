using static System.Console;
namespace EscapeTheMaze
{
    class Player
    {
      // Propeties that creates a player and can move it around in the world
      public int X { get; set; }
      public int Y { get; set;}
      // Where the player gets drawn to
      private string PlayerMarker;
      private ConsoleColor PlayerColor;

      // Constructor that will create the player at an initial place on the map
      public Player(int initialX, int initialY)
      {
        X = initialX;
        Y = initialY;
        PlayerMarker = "☺";
        PlayerColor = ConsoleColor.Blue;
      }

      // Draw method for the player position on the map
      public void Draw()
      {
        ForegroundColor = PlayerColor;
        SetCursorPosition(X, Y);
        Write(PlayerMarker);
        ResetColor();
      }
    }
}