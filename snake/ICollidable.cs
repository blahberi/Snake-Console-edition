using System.Drawing;

namespace snake
{
    interface ICollidable
    {
        bool IsCollided(Point p);
    }
}