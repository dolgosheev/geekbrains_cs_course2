using System;
using System.Drawing;
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
            Buffer.Graphics.Clear(Color.Black);

            Buffer.Graphics.FillEllipse(Brushes.Red, new Rectangle(100, 100, 200, 200));

            foreach (var asteroid in _asteroids)
                asteroid.Draw();

            foreach (var star in _stars)
                star.Draw(); // override Draw

            Buffer.Render();
        }

        public static void Update()
        {
            foreach (var asteroid in _asteroids)
                asteroid.Update();

            foreach (var star in _stars)
                star.Update(); // override Update
        }

        public static void Load()
        {
            var random = new Random();
            _asteroids = new Asteroid[15];
            for (var i = 0; i < _asteroids.Length; i++)
            {
                var size = random.Next(5, 40);
                _asteroids[i] = new Asteroid(new Point(500, i * 20), new Point(-i+10, -i+10), new Size(size, size));
            }
            _stars = new Asteroid[20];
            for (var i = 0; i < _stars.Length; i++)
            {
                var size = random.Next(3, 5);
                _stars[i] = new Star(new Point(600, i * 40), new Point(-i, -i), new Size(size, size));
            }

        }

    }
}
