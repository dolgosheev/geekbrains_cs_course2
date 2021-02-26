using System.Drawing;

namespace HomeWork.Lesson1.Task1
{
    internal class Star : Asteroid
    {
        public Star(Point position, Point direction, Size size) : base(position, direction, size)
        {
        }
        public override void Draw()
        {
            GameCore.Buffer.Graphics.DrawLine(Pens.White, Position.X, Position.Y, Position.X + Size.Width, Position.Y + Size.Height);
            GameCore.Buffer.Graphics.DrawLine(Pens.White, Position.X + Size.Width, Position.Y, Position.X, Position.Y + Size.Height);
        }

        public override void Update()
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
