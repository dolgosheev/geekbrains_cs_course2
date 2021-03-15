using AteroidsGame.Properties;
using System;
using System.Drawing;

namespace AteroidsGame.Model.Objects
{
    internal class Ship : BaseObject
    {
        private int energy = 100;
        public static event EventHandler DieEvent;

        public int Energy => energy;

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            GameCore.Buffer.Graphics.DrawImage(new Bitmap(Resources.ship, new Size(Size.Width, Size.Height)), Position.X, Position.Y);
        }

        public override void Update()
        {
            // ... smthg
        }

        public void EnergyLow(int n)
        {
            energy -= n;
        }

        public void Up()
        {
            if (Position.Y > 0) Position.Y = Position.Y - Direction.Y;
        }

        public void Down()
        {
            if (Position.Y < GameCore.Height) Position.Y = Position.Y + Direction.Y;
        }

        public void Die()
        {
            DieEvent?.Invoke(this, new EventArgs());
        }
    }
}
