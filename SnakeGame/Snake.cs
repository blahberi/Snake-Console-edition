using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Snake : ICollidable
    {
        public Direction Direction
        {
            get => this.Corners.First().Direction;
        }

        public Point Position => this.Head.Position;

        public IEnumerable<Corner> SnakeCorners => this.Corners;

        private Corner Head => this.Corners.Last();

        public Corner Tail => this.Corners.First();

        private List<Corner> Corners { get; }

        public Snake(Point initialPosition)
        {
            this.Corners = new List<Corner>();
            this.Corners.Add(new Corner(initialPosition, Direction.Right));
            this.Corners.Add(new Corner(initialPosition + new Size(3, 0), Direction.Right));
        }

        public void Update(bool moveTail=true)
        {
            System.Diagnostics.Debug.WriteLine($"{this.Head.Position.X}, {this.Head.Position.Y}");
            this.Head.MoveInDirection();
            if (moveTail)
            {
                this.Tail.MoveInDirection();
            }

            if (this.Tail.Position == this.Corners[1].Position)
            {
                this.Corners.Remove(this.Tail);
            }
        }

        public void ChangeDirection(Direction direction)
        {
            System.Diagnostics.Debug.WriteLine($"ChangeDirection: {direction}");
            if(this.Head.Direction != direction && !this.Head.Direction.IsOpposite(direction))
            {
                System.Diagnostics.Debug.WriteLine($"Adding corner");
                this.Head.Direction = direction;
                this.Corners.Add(new Corner(this.Head.Position, direction));
            }
        }

        public bool IsCollided(Point p)
        {
            Corner lastCorner = null;
            foreach (Corner c in this.SnakeCorners)
            {
                Point cp = c.Position;

                if (lastCorner != null && cp != this.Head.Position)
                {
                    if (p.X >= Math.Min(cp.X, lastCorner.Position.X) && 
                        p.X <= Math.Max(cp.X, lastCorner.Position.X))
                    {
                        if (p.Y >= Math.Min(cp.Y, lastCorner.Position.Y) &&
                            p.Y <= Math.Max(cp.Y, lastCorner.Position.Y))
                        {
                            return true;
                        }
                    }
                }
                lastCorner = c;
            }
            return false;
        }
    }
}
