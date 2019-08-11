namespace SimpleSnake.Constants
{
    public static class GameConstants
    {
        public static class Snake
        {
            public static readonly string SnakeSymbol = "\u25CF";
            public static readonly int DefaultLenght = 6;
            public static readonly int DefaultCoordinateX = 8;
            public static readonly int DefaultCoordinateY = 7;
        }

        public static class Food
        {
            public static readonly string SymbolAsterisk = "*";
            public static readonly int AsteriskFood = 1;
            public static readonly string SymbolDollar = "$";
            public static readonly int DollarFood = 2;
            public static readonly string SymbolHash = "#";
            public static readonly int HashFood = 3;
        }

        public static class Board
        {
            public static readonly string BoardSymbol = "\u2588";
            public static readonly int DefaultBoardWidth = 120;
            public static readonly int DefaultBoardHeight = 60;
        }

        public static class Player
        {
            public static readonly string RestertAsk = "Would you like to continue?";
            public static readonly string RestertAnswer = "Y/N";
            public static readonly string GameScore = "GameScore: ";
            public static readonly int OffSetX = 12;
            public static readonly int OffSetY = 15;
        }
    }
}
