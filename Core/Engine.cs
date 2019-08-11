namespace SimpleSnake.Core
{
    using SimpleSnake.Constants;
    using SimpleSnake.Enums;
    using SimpleSnake.Factories;
    using SimpleSnake.GameObjects;
    using SimpleSnake.GameObjects.Foods;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class Engine
    {
        private int score = 0;
        private readonly DrawManager drawManager;
        private readonly Snake snake;
        private Food food;
        private readonly Coordinate boardCoordinates;

        public Engine(DrawManager drawManager, Snake snake, Coordinate boardCoordinates)
        {
            this.drawManager = drawManager;
            this.snake = snake;
            this.boardCoordinates = boardCoordinates;
            this.InitializeFood();
            this.InitializeBoards();
            this.PlayerInfo();
        }

        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    this.SetCorrectDirection(Console.ReadKey());
                }

                this.PlayerInfo();

                this.drawManager.Draw(this.food.Symbol, new List<Coordinate>() { food.Coordinates });

                this.drawManager.Draw(GameConstants.Snake.SnakeSymbol, this.snake.SnakeBody);

                this.snake.Move();

                this.drawManager.UndoDraw();

                if (HasBorderCollision())
                {
                    this.ResterPlayer();
                }

                if (HasFoodCollision())
                {
                    this.score += this.food.Points;

                    this.snake.Eat(this.food);

                    this.InitializeFood();
                }

                if (this.snake.Direction == Direction.Up || this.snake.Direction == Direction.Down)
                {
                    Thread.Sleep(230);
                }
                else
                {
                    Thread.Sleep(200);
                }
            }
        }

        private void PlayerInfo()
        {
            Console.SetCursorPosition(this.boardCoordinates.CoordinateX + GameConstants.Player.OffSetX, GameConstants.Player.OffSetY);
            Console.Write(GameConstants.Player.GameScore + this.score);
        }

        private void ResterPlayer()
        {
            int x = 45;
            int y = 20;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(GameConstants.Player.RestertAsk);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(GameConstants.Player.RestertAnswer);

            var input = Console.ReadKey();

            if (input.Key == ConsoleKey.Y)
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private bool HasBorderCollision()
        {
            int snakeHeadCoordinateX = this.snake.Head.CoordinateX;
            int snakeHeadCoordinateY = this.snake.Head.CoordinateY;

            int boardCoordinateX = this.boardCoordinates.CoordinateX;
            int boardCoordinateY = this.boardCoordinates.CoordinateY;

            return snakeHeadCoordinateX == boardCoordinateX - 1
                || snakeHeadCoordinateX == 1
                || snakeHeadCoordinateY == boardCoordinateY
                || snakeHeadCoordinateY == 0;
        }

        private void InitializeBoards()
        {
            List<Coordinate> allCoordinates = new List<Coordinate>();

            this.InitializeHorizontalBoarder(0, allCoordinates);

            this.InitializeHorizontalBoarder(this.boardCoordinates.CoordinateY, allCoordinates);

            this.InitializeVerticalBoader(1, allCoordinates);

            this.InitializeVerticalBoader(this.boardCoordinates.CoordinateX - 1, allCoordinates);

            this.drawManager.Draw(GameConstants.Board.BoardSymbol, allCoordinates);
        }

        private void InitializeVerticalBoader(int coordinateX, List<Coordinate> allCoordinates)
        {
            for (int coordinateY = 1; coordinateY < this.boardCoordinates.CoordinateY; coordinateY++)
            {
                allCoordinates.Add(new Coordinate(coordinateX, coordinateY));
            }
        }

        private void InitializeHorizontalBoarder(int coordinateY, List<Coordinate> allCoordinates)
        {
            for (int coordinateX = 1; coordinateX < this.boardCoordinates.CoordinateX; coordinateX++)
            {
                allCoordinates.Add(new Coordinate(coordinateX, coordinateY));
            }
        }

        private void InitializeFood()
        {
            this.food = FoodFactory.GetRandomFood(this.boardCoordinates.CoordinateX, this.boardCoordinates.CoordinateY);
        }

        private bool HasFoodCollision()
        {
            int snakeHeadCoordinateX = this.snake.Head.CoordinateX;
            int snakeHeadCoordinateY = this.snake.Head.CoordinateY;

            int foodCoordinateX = this.food.Coordinates.CoordinateX;
            int foodCoordinateY = this.food.Coordinates.CoordinateY;

            return snakeHeadCoordinateX == foodCoordinateX
                && snakeHeadCoordinateY == foodCoordinateY;
        }

        private void SetCorrectDirection(ConsoleKeyInfo input)
        {
            Direction currentSnakeDirection = this.snake.Direction;

            switch (input.Key)
            {
                case ConsoleKey.RightArrow:
                    if (currentSnakeDirection != Direction.Left)
                    {
                        currentSnakeDirection = Direction.Right;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (currentSnakeDirection != Direction.Right)
                    {
                        currentSnakeDirection = Direction.Left;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (currentSnakeDirection != Direction.Up)
                    {
                        currentSnakeDirection = Direction.Down;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (currentSnakeDirection != Direction.Down)
                    {
                        currentSnakeDirection = Direction.Up;
                    }
                    break;
            }

            this.snake.Direction = currentSnakeDirection;
        }
    }
}
