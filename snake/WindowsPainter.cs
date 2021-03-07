using SnakeGame;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace snake
{
    class WindowsPainter : IPainter
    {
        private readonly Graphics graphics;

        public WindowsPainter(Graphics graphics)
        {
            this.graphics = graphics;
        }

        public void DrawApple(Apple apple)
        {
            this.graphics.SmoothingMode = SmoothingMode.None;
            this.graphics.FillRectangle(Brushes.Red, apple.Position.X, apple.Position.Y, 1, 1);
        }

        public void DrawStripe(Point start, Direction direction, int count)
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

            this.graphics.SmoothingMode = SmoothingMode.None;

            this.graphics.FillRectangle(Brushes.White, r);
        }
    }
}
