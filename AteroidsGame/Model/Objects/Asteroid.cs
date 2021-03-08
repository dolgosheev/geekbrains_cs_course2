using AteroidsGame.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace AteroidsGame.Model.Objects
{
    internal class Asteroid : BaseObject
    {
        private readonly int _index;
        private static readonly Random Rnd = new Random();

        private readonly List<Image> _asteroidList = new List<Image>()
        {
            Resources.asteroid_1,
            Resources.asteroid_2,
            Resources.asteroid_3
        };

        public Asteroid(Point position, Point direction, Size size) : base(position, direction, size)
        {
            _index = Rnd.Next(0, 3);
        }

        public override void Draw()
        {
            GameCore.Buffer.Graphics.DrawImage(
                    new Bitmap(_asteroidList[_index], 
                    new Size(Size.Width / 2, Size.Height / 2
                    )), Position.X, Position.Y);
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
