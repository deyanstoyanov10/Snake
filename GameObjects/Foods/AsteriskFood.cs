namespace SimpleSnake.GameObjects.Foods
{
    using SimpleSnake.Constants;

    public class AsteriskFood : Food
    {
        public AsteriskFood(Coordinate coordinates) 
            : base(GameConstants.Food.SymbolAsterisk, GameConstants.Food.AsteriskFood, coordinates)
        {
        }
    }
}
