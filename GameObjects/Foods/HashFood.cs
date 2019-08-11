namespace SimpleSnake.GameObjects.Foods
{
    using SimpleSnake.Constants;

    public class HashFood : Food
    {
        public HashFood(Coordinate coordinates) 
            : base(GameConstants.Food.SymbolHash, GameConstants.Food.HashFood, coordinates)
        {
        }
    }
}
