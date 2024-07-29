using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
    class Snake
    {
        public List<Coordinate> Position { get; private set; }
        public Direction CurrentDirection { get; set; }
        private int gridWidth;
        private int gridHeight;

        public Snake(int gridWidth, int gridHeight)
        {
            this.gridWidth = gridWidth;
            this.gridHeight = gridHeight;
            Position = new List<Coordinate> { new Coordinate(gridWidth / 2, gridHeight / 2) };
            CurrentDirection = Direction.Right;
        }

        public void Move()
        {
            Coordinate head = Position.First();
            Coordinate newHead = head;

            switch (CurrentDirection)
            {
                case Direction.Up:
                    newHead = new Coordinate(head.X, head.Y - 1);
                    break;
                case Direction.Down:
                    newHead = new Coordinate(head.X, head.Y + 1);
                    break;
                case Direction.Left:
                    newHead = new Coordinate(head.X - 1, head.Y);
                    break;
                case Direction.Right:
                    newHead = new Coordinate(head.X + 1, head.Y);
                    break;
            }

            Position.Insert(0, newHead);
            Position.RemoveAt(Position.Count - 1);
        }

        public void Grow()
        {
            Coordinate tail = Position.Last();
            Position.Add(tail); // Add a new segment at the tail
        }

        public void Render()
        {
            foreach (var segment in Position)
            {
                Console.SetCursorPosition(segment.X, segment.Y);
                Console.Write("O");
            }
        }
    }
}
