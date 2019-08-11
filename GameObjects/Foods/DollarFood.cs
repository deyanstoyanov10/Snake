namespace SimpleSnake.GameObjects.Foods
{
    using SimpleSnake.Constants;

    public class DollarFood : Food
    {
        public DollarFood(Coordinate coordinates) 
            : base(GameConstants.Food.SymbolDollar, GameConstants.Food.DollarFood, coordinates)
        {
        }
    }
}
