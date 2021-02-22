using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace snake
{
    class Snake : ICollidable
    {
        public Direction Direction
        {
            get => this.Corners.First().Direction;
        }

        public Point Position => this.Head.Position;

        public Point[] SnakeCorners => this.Corners.Select(c => c.Position).ToArray();

        private Corner Head => this.Corners.Last();

        private Corner Tail => this.Corners.First();

        private List<Corner> Corners { get; }

        public Snake(Point initialPosition)
        {
            this.Corners = new List<Corner>();
            this.Corners.Add(new Corner(initialPosition, Direction.Right));
            this.Corners.Add(new Corner(initialPosition + new Size(3, 0), Direction.Right));
        }

        public void Update(bool moveTail=true)
        {
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
            if (p.X == this.Position.X && p.Y == this.Position.Y)
            {
                return true;
            }
            return false;
        }
    }
}
