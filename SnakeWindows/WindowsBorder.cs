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
        public void DrawBorder(Border border, int pixelSize, Graphics graphics)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            this.DrawBorderLine(border.corners[0], Direction.Right, border.corners[1].X, pixelSize, graphics);
            this.DrawBorderLine(border.corners[1], Direction.Down, border.corners[2].Y, pixelSize, graphics);
            this.DrawBorderLine(border.corners[2], Direction.Left, border.corners[2].X, pixelSize, graphics);
            this.DrawBorderLine(border.corners[3], Direction.Up, border.corners[3].Y, pixelSize, graphics);
        }
        private void DrawBorderLine(Point start, Direction direction, int count, int pixelSize, Graphics graphics)
        {
            start.X *= pixelSize;
            start.Y *= pixelSize;
            count *= pixelSize;
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
               Math.Abs(start.X - end.X) + pixelSize,
               Math.Abs(start.Y - end.Y) + pixelSize);

            graphics.SmoothingMode = SmoothingMode.None;

            graphics.FillRectangle(Brushes.Gray, r);
        }
    }
}
