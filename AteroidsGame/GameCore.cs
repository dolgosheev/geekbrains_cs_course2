using AteroidsGame.Exceptions;
using AteroidsGame.Model.Objects;
using AteroidsGame.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AteroidsGame
{
    internal static class GameCore
    {
        #region Explicit

        private static BaseObject[] _asteroids;
        private static BaseObject[] _stars;
        private static Bullet _bullet;

        private static readonly Ship Ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(45, 50));
        private static Timer _timer = new Timer();

        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer { get; private set; }

        public static event EventHandler<Tuple<int,int>> ScoreResult;
        public static int Ships { get; private set; }
        public static int Score { get; private set; } = 0;

        private static int _width;
        public static int Width
        {
            get => _width;
            set
            {
                if(value > 1000 || value < 0)
                    throw new ArgumentOutOfRangeException();
                _width = value;
            }
        }
        private static int _height;

        public static int Height
        {
            get => _height;
            set
            {
                if (value > 1000 || value < 0)
                    throw new InitializeException(Form.ActiveForm, "Just positive size & less than 1000");
                _height = value;
            }
        }

        #endregion

        #region Start logic

        public static void InitializeGameCore(this Form form)
        {
            var graphic = form.CreateGraphics();
            _context = BufferedGraphicsManager.Current;

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            Buffer = _context.Allocate(graphic, new Rectangle(0, 0, Width, Height));

            Load();

            _timer = new Timer { Interval = 100 };
            _timer.Start();
            _timer.Tick += Timer_Tick;

            form.KeyDown += Form_KeyDown;
            Ship.DieEvent += Finish;
            ScoreResult += GameCore_Score;
        }

        public static void Load()
        {
            // set objects count
            _asteroids = new BaseObject[15];
            _stars = new BaseObject[20];

            Ships = _asteroids.Length;

            for (var i = 0; i < _asteroids.Length; i++)
                _asteroids[i] = new Asteroid(new Point(100, i * i), new Point(-i + 10, -i + 5), new Size(100, 100));

            for (var i = 0; i < _stars.Length; i++)
                _stars[i] = new Star(new Point(500, i * i), new Point(-i - 4, -i - 1), new Size(3, 3));
        }

        #endregion

        #region Events

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
             
                _bullet = new Bullet(new Point(Ship.Rect.X + 10, Ship.Rect.Y + 23), new Point(5, 0), new Size(54, 9));
            }
            if (e.KeyCode == Keys.Up)
            {
                Ship.Up();
            }
            if (e.KeyCode == Keys.Down)
            {
                Ship.Down();
            }
        }

        private static void Finish(object sender, EventArgs e)
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }

        private static void GameCore_Score(object sender, Tuple<int,int> stats)
        {
            Buffer.Graphics.DrawString($"Score {stats.Item1}\nShips {stats.Item2}", new Font(FontFamily.GenericSansSerif, 10, FontStyle.Underline), Brushes.White, Width-90, 50);
            Buffer.Render();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        #endregion

        #region dynamic

        public static void Draw()
        {
            using (Image image = new Bitmap(Resources.theEarth, new Size(150, 150)))
            {
                Buffer.Graphics.Clear(Color.Black);

                // Draw planet
                Buffer.Graphics.DrawImage(image, (Width - 200) / 2, (Height - 200) / 2);

                // Draw asteroids
                foreach (var asteroid in _asteroids)
                    asteroid?.Draw();

                // Draw stars
                foreach (var star in _stars)
                    star?.Draw();

                // Draw bullet
                _bullet?.Draw();

                // Draw ship
                Ship?.Draw();

                // Descriptions
                if (Ship != null)
                    Buffer.Graphics.DrawString($"Energy: {Ship.Energy}", SystemFonts.DefaultFont, Brushes.White, 10, 10);

                Buffer.Render();
            }
        }

        public static void Update()
        {
            
            // Update asteroids
            for (var i = 0; i < _asteroids.Length; i++)
            {

                if (_asteroids[i] == null)
                    continue;

                _asteroids[i].Update();

                if (_bullet != null && _asteroids[i].Collision(_bullet))
                {
                    SystemSounds.Hand.Play();
                    ScoreResult?.Invoke(null, new Tuple<int, int>(Score++, Ships--));

                    Debug.WriteLine($"{i} -> X:{_asteroids[i].Rect.X} Y:{_asteroids[i].Rect.Y}");

                    _asteroids[i] = null;
                    _bullet = null;
                }
            }

            // Update stars
            foreach (var star in _stars)
                star?.Update();

            // Update bullet
            _bullet?.Update();

            ScoreResult?.Invoke(null, new Tuple<int, int>(Score, Ships));
        }

        #endregion
    }
}
