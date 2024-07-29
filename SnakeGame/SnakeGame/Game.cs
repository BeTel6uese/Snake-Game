using System;
using System.Linq;
using System.Threading;

namespace SnakeGame
{
    class Game
    {
        private Snake snake;
        private Food food;
        private bool isGameOver;
        private int score;
        private const int GridWidth = 40;
        private const int GridHeight = 20;

        public void InitializeGame()
        {
            Console.CursorVisible = false;
            snake = new Snake(GridWidth, GridHeight);  // Initializing the snake
            food = new Food(GridWidth, GridHeight);    // Initializing the food
            isGameOver = false;
            score = 0;
        }

        public void Run()
        {
            while (!isGameOver)
            {
                HandleInput();
                Update();
                Render();
                Thread.Sleep(100); 
            }

            Console.Clear();
            Console.WriteLine("Game Over!");
            Console.WriteLine("Score: " + score);
        }

        private void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (snake.CurrentDirection != Direction.Down)
                            snake.CurrentDirection = Direction.Up;
                        break;
                    case ConsoleKey.DownArrow:
                        if (snake.CurrentDirection != Direction.Up)
                            snake.CurrentDirection = Direction.Down;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (snake.CurrentDirection != Direction.Right)
                            snake.CurrentDirection = Direction.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        if (snake.CurrentDirection != Direction.Left)
                            snake.CurrentDirection = Direction.Right;
                        break;
                }
            }
        }

        private void Update()
        {
            snake.Move();  
            CheckCollisions();
            CheckFood();
        }

        private void Render()
        {
            Console.Clear();
            DrawBorders();
            snake.Render();  
            food.Render();  
            DisplayScore();
        }

        private void DrawBorders()
        {
            for (int x = 0; x <= GridWidth + 1; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write("#");
                Console.SetCursorPosition(x, GridHeight + 1);
                Console.Write("#");
            }

            for (int y = 0; y <= GridHeight + 1; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("#");
                Console.SetCursorPosition(GridWidth + 1, y);
                Console.Write("#");
            }
        }

        private void DisplayScore()
        {
            Console.SetCursorPosition(GridWidth + 3, 1);
            Console.Write("Score: " + score);
        }

        private void CheckCollisions()
        {
            Coordinate head = snake.Position.First();
            if (head.X <= 0 || head.Y <= 0 || head.X >= GridWidth + 1 || head.Y >= GridHeight + 1)
            {
                isGameOver = true;
            }

            // check if the snake collides with itself
            for (int i = 1; i < snake.Position.Count; i++)
            {
                if (head.X == snake.Position[i].X && head.Y == snake.Position[i].Y)
                {
                    isGameOver = true;
                }
            }
        }

        private void CheckFood()
        {
            Coordinate head = snake.Position.First();
            if (head.X == food.Position.X && head.Y == food.Position.Y)
            {
                snake.Grow();
                score++;
                food.GenerateNewPosition(snake.Position);
            }
        }
    }
}
