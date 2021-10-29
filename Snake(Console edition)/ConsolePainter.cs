using SnakeGame;
using System;
using System.Drawing;

namespace Snake_Console_edition_
{
    class ConsolePainter : IPainter
    {
        public void DrawApple(Apple apple, int pixelSize=0) // i have to do pixelSize=0 because its in the interface
        {

            Console.SetCursorPosition(apple.Position.X, apple.Position.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("@");
        }

        public void DrawStripe(Point start, Direction direction, int count, int pixelSize=0) // i have to do pixelSize=0 because its in the interface
        {
            int xd = 0;
            int yd = 0;

            int x = start.X;
            int y = start.Y;

            switch (direction)
            {
                case Direction.Down:
                    yd = 1;
                    break;
                case Direction.Up:
                    yd = -1;
                    break;
                case Direction.Left:
                    xd = -1;
                    break;
                case Direction.Right:
                    xd = 1;
                    break;
            }

            for (int i=0;i<=count;i++)
            {
                if (x >= 0 && y >= 0) 
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("#");
                    x += xd;
                    y += yd;
                }
            }
        }
    }
}
