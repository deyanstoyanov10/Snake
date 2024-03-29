﻿namespace SimpleSnake.Factories
{
    using SimpleSnake.GameObjects;
    using SimpleSnake.GameObjects.Foods;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class FoodFactory
    {
        private static Random random;

        static FoodFactory()
        {
            random = new Random();
        }

        public static Food GetRandomFood(int boardWidth, int boardHight)
        {
            List<Type> foodType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.BaseType == typeof(Food))
                .ToList();

            Type currenctFood = foodType[random.Next(0, foodType.Count)];

            int coordinateX = random.Next(1, boardWidth - 1);
            int coordinateY = random.Next(1, boardHight - 1);

            Coordinate foodCoordinate = new Coordinate(coordinateX, coordinateY);

            return Activator.CreateInstance(currenctFood, new object[] { foodCoordinate }) as Food;
        }
    }
}
