using System.Drawing;

namespace HomeWork.Lesson1.Task1
{
    internal class Asteroid
    {
        protected Point Position;
        protected Point Direction;
        protected Size Size;

        public Asteroid(Point position, Point direction, Size size)
        {
            Position = position;
            Direction = direction;
            Size = size;
        }

        public virtual void Draw()
        {
            GameCore.Buffer.Graphics.DrawEllipse(Pens.White, Position.X, Position.Y, Size.Width, Size.Height);
        }

        public virtual void Update()
        {
            Position.X = Position.X + Direction.X;
            Position.Y = Position.Y + Direction.Y;

            if (Position.X < 0) Direction.X = -Direction.X;
            if (Position.X > GameCore.Width) Direction.X = -Direction.X;
            if (Position.Y < 0) Direction.Y = -Direction.Y;
            if (Position.Y > GameCore.Height) Direction.Y = -Direction.Y;
        }
    }
}
