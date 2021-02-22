using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Apple : ICollidable
    {
        public Point point;

        public Apple(int x, int y)
        {
            this.point = new Point();
            this.point.X = x;
            this.point.Y = y;
        }

        public bool IsCollided(Point p)
        {

        }
    }
}
