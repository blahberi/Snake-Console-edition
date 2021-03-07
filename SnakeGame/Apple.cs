using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Apple : ICollidable
    {
        public Point Position;

        public Apple(int x, int y)
        {
            this.Position = new Point();
            this.Position.X = x;
            this.Position.Y = y;
        }

        public bool IsCollided(Point p)
        {
            if (p.X == this.Position.X && p.Y == this.Position.Y)
            {
                return true;
            }
            return false;
        }
    }
}
