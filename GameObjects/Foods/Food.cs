namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food
    {
        protected Food(string symbol, int points, Coordinate coordinates)
        {
            this.Symbol = symbol;
            this.Points = points;
            this.Coordinates = coordinates;
        }

        public string Symbol { get; set; }

        public int Points { get; set; }

        public Coordinate Coordinates { get; set; }
    }
}
