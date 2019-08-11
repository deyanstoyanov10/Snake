namespace SimpleSnake
{
    using SimpleSnake.Constants;
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            var drawManager = new DrawManager();
            var snake = new Snake();
            var boardCoordinates = new Coordinate(GameConstants.Board.DefaultBoardWidth, GameConstants.Board.DefaultBoardHeight);

            Engine engine = new Engine(drawManager, snake, boardCoordinates);

            engine.Run();
        }
    }
}
