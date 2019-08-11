namespace SimpleSnake.GameObjects
{
    using SimpleSnake.Constants;
    using SimpleSnake.Enums;
    using SimpleSnake.GameObjects.Foods;
    using System.Collections.Generic;
    using System.Linq;

    public class Snake
    {
        private readonly List<Coordinate> snakeBody;
        

        public Snake()
        {
            this.snakeBody = new List<Coordinate>();
            this.InitializeSnake();
            this.Direction = Direction.Right;
        }

        public IReadOnlyCollection<Coordinate> SnakeBody => this.snakeBody.AsReadOnly();

        public Direction Direction { get; set; }

        public Coordinate Head => this.snakeBody.Last();

        public void Move()
        {
            Coordinate snakeHead = this.SnakeBody.Last();
            Coordinate newHead = this.GetNewHeadCoordinates();
            this.snakeBody.Add(newHead);
            this.snakeBody.RemoveAt(0);
        }

        public void Eat(Food food)
        {
            for (int i = 0; i < food.Points; i++)
            {
                Coordinate newHeadCoordinate = this.GetNewHeadCoordinates();
                this.snakeBody.Add(newHeadCoordinate);
            }
        }

        private Coordinate GetNewHeadCoordinates()
        {
            Coordinate newHeadCoordinate = new Coordinate(this.Head.CoordinateX, this.Head.CoordinateY);

            switch (this.Direction)
            {
                case Direction.Right:
                    newHeadCoordinate.CoordinateX++;
                    break;
                case Direction.Left:
                    newHeadCoordinate.CoordinateX--;
                    break;
                case Direction.Down:
                    newHeadCoordinate.CoordinateY++;
                    break;
                case Direction.Up:
                    newHeadCoordinate.CoordinateY--;
                    break;
            }

            return newHeadCoordinate;
        }

        private void InitializeSnake()
        {
            int coordinateX = GameConstants.Snake.DefaultCoordinateX;
            int coordinateY = GameConstants.Snake.DefaultCoordinateY;

            for (int i = 0; i <= GameConstants.Snake.DefaultLenght; i++)
            {
                this.snakeBody.Add(new Coordinate(coordinateX, coordinateY));

                coordinateX++;
            }
        }
    }
}
