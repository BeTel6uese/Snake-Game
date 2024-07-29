using System;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Snake Game");
            Console.WriteLine("Press any key to play");

            Console.ReadKey(true);

            while (true)
            {
                Game game = new Game();
                game.InitializeGame();
                game.Run();

                Console.WriteLine("Press 'R' to replay or any other key to exit.");
                if (Console.ReadKey(true).Key != ConsoleKey.R)
                {
                    break;
                }
                Console.Clear();
            }
        }
    }
}
