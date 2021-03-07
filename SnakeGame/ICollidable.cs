using System.Drawing;

namespace SnakeGame
{
    public interface ICollidable
    {
        bool IsCollided(Point p);
    }
}