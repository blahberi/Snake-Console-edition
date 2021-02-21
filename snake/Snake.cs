using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace snake
{
    class Snake
    {
        public Direction Direction
        {
            get => this.Corners.First().Direction;
        }

        private Corner Head => this.Corners.Last();

        private Corner Tail => this.Corners.First();

        private List<Corner> Corners { get; }

        public Snake(Point initialPosition)
        {
            this.Corners = new List<Corner>();
            this.Corners.Add(new Corner(initialPosition + new Size(3, 0), Direction.Left));
            this.Corners.Add(new Corner(initialPosition, Direction.Left)); 
        }

        public void Update()
        {
            this.Head.MoveInDirection();
            this.Tail.MoveInDirection();

            if (this.Tail.Position == this.Corners[1].Position)
            {
                this.Corners.Remove(this.Tail);
            }
        }

        public void ChangeDirection(Direction direction)
        {
            this.Corners.Add(new Corner(this.Head.Position, direction));
        }
    }
}
