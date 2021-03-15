using AteroidsGame.Properties;
using System.Drawing;

namespace AteroidsGame.Model.Objects
{
    internal class Star : Asteroid
    {
        public Star(Point position, Point direction, Size size) : base(position, direction, size)
        {
        }
        public override void Draw()
        {
            using (Image image = new Bitmap(Resources.star,new Size(10,10)))
            {
                GameCore.Buffer.Graphics.DrawImage(image, Position.X, Position.Y);
            }
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
