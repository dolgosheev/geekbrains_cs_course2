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
            using (Image image = new Bitmap(@"img/star.png"))
            {
                GameCore.Buffer.Graphics.DrawImage(image, Position.X, Position.Y);
            }
        }

        public override void Update()
        {
            Position.X = Position.X + Direction.X;
            Position.Y = Position.Y + Direction.Y;

            if (Position.X < 0) Direction.X = -Direction.X;
            if (Position.X > GameCore.Width-50) Direction.X = -Direction.X;
            if (Position.Y < 0) Direction.Y = -Direction.Y;
            if (Position.Y > GameCore.Height-50) Direction.Y = -Direction.Y;
        }
    }
}
