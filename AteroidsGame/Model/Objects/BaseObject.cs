using AteroidsGame.Model.Interfaces;
using System.Drawing;

namespace AteroidsGame.Model.Objects
{
    public abstract class BaseObject : ICollision
    {
        protected Point Position;
        protected Point Direction;
        protected Size Size;

        protected BaseObject(Point pos, Point dir, Size size)
        {
            Position = pos;
            Direction = dir;
            Size = size;
        }

        public Rectangle Rect => new Rectangle(Position, Size);

        public bool Collision(ICollision obj)
        {
            return obj.Rect.IntersectsWith(Rect);
        }

        public abstract void Draw();

        public abstract void Update();

    }
}
