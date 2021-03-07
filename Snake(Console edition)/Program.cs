using SnakeGame;
using System;
using System.Threading;


namespace Snake_Console_edition_
{
    class Program
    {
        static void Main()
        {
            ConsoleSnakeGame game = new ConsoleSnakeGame();
            ConsolePainter consolePainter = new ConsolePainter();
            Console.CursorVisible = false;
            game.Clear += Die;
            Console.SetWindowSize(40, 40);
            new ConsoleBorder().DrawBorder(game.border);



            Timer timer = new Timer(s =>
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(game.Score);
                game.Update();
                game.Draw(consolePainter);
            }, state: null, 0, 100);

            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(intercept: true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        game.UpdateDirection(Direction.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        game.UpdateDirection(Direction.Down);
                        break;
                    case ConsoleKey.RightArrow:
                        game.UpdateDirection(Direction.Right);
                        break;
                    case ConsoleKey.LeftArrow:
                        game.UpdateDirection(Direction.Left);
                        break;
                }
            }
            while (keyInfo.Key != ConsoleKey.Escape);
        }

        static void Die(Game game)
        {
            Console.Clear();
            new ConsoleBorder().DrawBorder(game.border);
        }
    }
}
