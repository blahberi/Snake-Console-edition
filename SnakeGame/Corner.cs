using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Corner
    {
        private Point position;

        public Corner(Point position, Direction direction)
        {
            this.position = position;
            this.Direction = direction;
        }

        public Point Position => this.position;
        public Direction Direction { get; set; }

        public void MoveInDirection()
        {
            switch (this.Direction)
            {
                case Direction.Down:
                    this.position.Y++;
                    break;
                case Direction.Up:
                    this.position.Y--;
                    break;
                case Direction.Left:
                    this.position.X--;
                    break;
                case Direction.Right:
                    this.position.X++;
                    break;
            }
        }
    }
    
}
