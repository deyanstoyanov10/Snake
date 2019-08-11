namespace SimpleSnake.Core
{
    using SimpleSnake.Constants;
    using SimpleSnake.GameObjects;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DrawManager
    {
        private readonly List<Coordinate> snakeBodyElements;

        public DrawManager()
        {
            this.snakeBodyElements = new List<Coordinate>();
        }

        public void Draw(string symbol, IReadOnlyCollection<Coordinate> coordinates)
        {
            foreach (var coordinate in coordinates)
            {
                if (symbol == GameConstants.Snake.SnakeSymbol)
                {
                    this.snakeBodyElements.Add(coordinate);
                }

                Console.SetCursorPosition(coordinate.CoordinateX, coordinate.CoordinateY);
                Console.Write(symbol);
            }
        }

        public void UndoDraw()
        {
            Coordinate lastElements = this.snakeBodyElements.First();

            Console.SetCursorPosition(lastElements.CoordinateX, lastElements.CoordinateY);
            Console.Write(" ");

            this.snakeBodyElements.Clear();
        }
    }
}
