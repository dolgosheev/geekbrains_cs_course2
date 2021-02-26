using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace HomeWork.Lesson1.Task1
{
    internal static class GameCore
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer { get; private set; }
        private static Asteroid[] _asteroids;
        private static Asteroid[] _stars;

        public static int Width { get; set; }
        public static int Height { get; set; }

        public static void InitializeGameCore(this Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            var timer = new Timer
            {
                Interval = 100
            };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            using (Image image = new Bitmap(@"img/theEarth.png"))
            {
                Buffer.Graphics.Clear(Color.Black);
                Buffer.Graphics.DrawImage(image, (Width - 200) / 2, (Height - 200) / 2);

                Array.ForEach(_asteroids, asteroid => asteroid.Draw());
                Array.ForEach(_stars, star => star.Draw());

                Buffer.Render();
            }
        }

        public static void Update()
        {
            Array.ForEach(_asteroids, asteroid => asteroid.Update());
            Array.ForEach(_stars, star => star.Update());
        }

        public static void Load()
        {
            var random = new Random();

            _asteroids = new Asteroid[10];
            _stars = new Asteroid[10];

            for (var i = 0; i < _asteroids.Length; i++)
                _asteroids[i] = new Asteroid(new Point(100, i * i), new Point(-i + 10, -i + 5), new Size(100, 100));

            for (var i = 0; i < _stars.Length; i++)
                _stars[i] = new Star(new Point(500, i * i), new Point(-i-4, -i-1), new Size(50, 50));

        }

    }
}
