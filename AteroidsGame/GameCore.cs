using AteroidsGame.Exceptions;
using AteroidsGame.Model.Objects;
using AteroidsGame.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace AteroidsGame
{
    internal static class GameCore
    {
        private static BaseObject[] _spaceObjects;
        private static Star[] _stars;
        private static Bullet _bullet;

        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer { get; private set; }

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

        public static void InitializeGameCore(this Form form)
        {
            Graphics graphic;
            _context = BufferedGraphicsManager.Current;
            graphic = form.CreateGraphics();

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            Buffer = _context.Allocate(graphic, new Rectangle(0, 0, Width, Height));

            Load();

            var timer = new Timer { Interval = 100 };
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
            using (Image image = new Bitmap(Resources.theEarth,new Size(150,150)))
            {
                Buffer.Graphics.Clear(Color.Black);

                Buffer.Graphics.DrawImage(image, (Width - 200) / 2, (Height - 200) / 2);

                foreach (var obj in _spaceObjects)
                    if (obj != null)
                        obj.Draw();


                Array.ForEach(_stars, star => star.Draw());

                if (_bullet != null)
                    _bullet.Draw();

                Buffer.Render();
            }
        }



        public static void Load()
        {
            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(54, 9));

            _spaceObjects = new BaseObject[10];

            _stars = new Star[5];

            for (var i = 0; i < _spaceObjects.Length; i++)
                _spaceObjects[i] = new Asteroid(new Point(100, i * i), new Point(-i + 10, -i + 5), new Size(100, 100));

            for (var i = 0; i < _stars.Length; i++)
                _stars[i] = new Star(new Point(500, i * i), new Point(-i-4, -i-1), new Size(50, 50));


        }

        public static void Update()
        {
            for (var i = 0; i < _spaceObjects.Length; i++)
            {
                if (_spaceObjects[i] == null)
                    continue;

                _spaceObjects[i].Update();


                if (_bullet != null && _spaceObjects[i].Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    Debug.WriteLine($"{i} -> X:{_spaceObjects[i].Rect.X} Y:{_spaceObjects[i].Rect.Y}");
                    _spaceObjects[i] = null;
                    _bullet = null;

                    
                }

                
            }

            Array.ForEach(_stars, star => star.Update());

            if (_bullet != null)
                _bullet.Update();
            else
                Res();
        }


        public static void Res()
        {
            _bullet = new Bullet(
                new Point(0,new Random().Next(0,Height)),
                new Point(Width,Height/2), 
                new Size(54,9));
        }

    }
}
