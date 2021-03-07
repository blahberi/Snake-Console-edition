using System;
using System.Drawing;

namespace SnakeGame
{
    public interface IPainter
    {
        void DrawApple(Apple apple);
        void DrawStripe(Point start, Direction direction, int count);
    }
}
