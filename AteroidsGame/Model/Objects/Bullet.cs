using AteroidsGame.Properties;
using System.Drawing;

namespace AteroidsGame.Model.Objects
{
    internal class Bullet : BaseObject
    {

        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size) { }

        public override void Draw()
        {
            GameCore.Buffer.Graphics.DrawImage(new Bitmap(Resources.laserRed011, new Size(Size.Width, Size.Height)), Position.X, Position.Y);
        }

        public override void Update()
        {
            Position.X = Position.X + 15;
        }
    }
}
