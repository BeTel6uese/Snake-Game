using System;
using System.Collections.Generic;

namespace SnakeGame
{
    class Food
    {
        public Coordinate Position { get; private set; }
        private int gridWidth;
        private int gridHeight;
        private Random random;

        public Food(int gridWidth, int gridHeight)
        {
            this.gridWidth = gridWidth;
            this.gridHeight = gridHeight;
            random = new Random();
            GenerateNewPosition(new List<Coordinate>());
        }

        public void GenerateNewPosition(List<Coordinate> snakePosition)
        {
            Coordinate newPosition;
            do
            {
                newPosition = new Coordinate(random.Next(1, gridWidth), random.Next(1, gridHeight));
            } while (snakePosition.Contains(newPosition));

            Position = newPosition;
        }

        public void Render()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write("*");
        }
    }
}
