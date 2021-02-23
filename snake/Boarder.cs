using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    class Boarder : ICollidable
    {
        public List<Point> corners { get; }

        public Boarder()
        {
            this.corners = new List<Point>();

            //creating edges
            this.corners.Add(new Point(-1, -1));
            this.corners.Add(new Point(36, -1));
            this.corners.Add(new Point(36, 31));
            this.corners.Add(new Point(-1, 31));
        }

        public bool IsCollided(Point p)
        {
            Point? lastCorner = null;
            foreach (Point c in this.corners)
            {
                if (lastCorner != null)
                {
                    if (p.X >= Math.Min(c.X, lastCorner.Value.X) && p.X <= Math.Max(c.X, lastCorner.Value.X))
                    {
                        if (p.Y >= Math.Min(c.Y, lastCorner.Value.Y) && p.Y <= Math.Max(c.Y, lastCorner.Value.Y))
                        {
                            return true;
                        }
                    }
                }
                lastCorner = c;
            }
            Point corner = this.corners.First();
            lastCorner = this.corners.Last();

            if (p.X >= Math.Min(corner.X, lastCorner.Value.X) && p.X <= Math.Max(corner.X, lastCorner.Value.X))
            {
                if (p.Y >= Math.Min(corner.Y, lastCorner.Value.Y) && p.Y <= Math.Max(corner.Y, lastCorner.Value.Y))
                {
                    return true;
                }
            }
            return false;
        }
    }
    
}
