using SnakeGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Snake_Console_edition_
{
    class ConsoleBorder
    {
        public void DrawBorder(Border border)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            this.DrawBorderLine(border.corners[0], Direction.Right, border.corners[1].X);
            this.DrawBorderLine(border.corners[1], Direction.Down, border.corners[2].Y);
            this.DrawBorderLine(border.corners[2], Direction.Left, border.corners[2].X);
            this.DrawBorderLine(border.corners[3], Direction.Up, border.corners[3].Y);
        }
        private void DrawBorderLine(Point start, Direction direction, int count)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
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

            for (int i = 0; i <= count; i++)
            {
                if (x >= 0 && y >= 0)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("*");
                    x += xd;
                    y += yd;
                }
            }
        }
    }
}
