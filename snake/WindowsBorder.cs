using SnakeGame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace SnakeForWindows
{
    class WindowsBorder
    {
        private Graphics graphics;
        public void DrawBorder(Border border, Graphics graphics)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            this.DrawBorderLine(border.corners[0], Direction.Right, border.corners[1].X, graphics);
            this.DrawBorderLine(border.corners[1], Direction.Down, border.corners[2].Y, graphics);
            this.DrawBorderLine(border.corners[2], Direction.Left, border.corners[2].X, graphics);
            this.DrawBorderLine(border.corners[3], Direction.Up, border.corners[3].Y, graphics);
        }
        private void DrawBorderLine(Point start, Direction direction, int count, Graphics graphics)
        {
            Point end = new Point(start.X, start.Y);

            switch (direction)
            {
                case Direction.Left:
                    end.X -= count;
                    break;
                case Direction.Right:
                    end.X += count;
                    break;
                case Direction.Up:
                    end.Y -= count;
                    break;
                case Direction.Down:
                    end.Y += count;
                    break;
            }

            Rectangle r = new Rectangle(Math.Min(start.X, end.X),
               Math.Min(start.Y, end.Y),
               Math.Abs(start.X - end.X) + 1,
               Math.Abs(start.Y - end.Y) + 1);

            graphics.SmoothingMode = SmoothingMode.None;

            graphics.FillRectangle(Brushes.Gray, r);
        }
    }
}
