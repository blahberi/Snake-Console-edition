using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    public static class DirectionExtensions
    {
        public static bool IsOpposite(this Direction direction, Direction other)
        {
            switch (direction)
            {
                case Direction.Left:
                    return other == Direction.Right;
                case Direction.Right:
                    return other == Direction.Left;
                case Direction.Up:
                    return other == Direction.Down;
                case Direction.Down:
                    return other == Direction.Up;
                default:
                    throw new ArgumentException(nameof(direction));
            }
        }
    }
}
