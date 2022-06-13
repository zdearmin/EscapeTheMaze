namespace EscapeTheMaze
{
    class Player
    {
        public int X { get; set; }
              public int y { get; set;}
              private string PlayerMarker;
              private ConsoleColor PlayerColor;


        public Player(int initialX, int initialY)
            {
              X = initialX;
              y = initialY;
              PlayerMarker = "O";
              PlayerColor = Console.Red;

            }

            public void Draw()
            {
              ForegroundColor = PlayerColor;
              Console.SetCursorPosition(X , Y);
              Console.Write(PlayerMarker);
              Console.ResetColor();
            }
        
        
    }
}