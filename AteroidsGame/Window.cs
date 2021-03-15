using AteroidsGame.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AteroidsGame
{
    public partial class Window : Form
    {
        internal static Window Instance => LazyInstance.Value;
        private static readonly Lazy<Window> LazyInstance = new Lazy<Window>(() => new Window());

        private Window()
        {
            MinimumSize = new Size(800, 600);
            MaximumSize = new Size(800, 600);
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = Resources.Window_Window_Asteroids;
            InitializeComponent();
        }

        public sealed override Size MaximumSize
        {
            get => base.MaximumSize;
            set => base.MaximumSize = value;
        }

        public sealed override Size MinimumSize
        {
            get => base.MinimumSize;
            set => base.MinimumSize = value;
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Copyright by Alexander Dolgosheev 2021", @"About");
        }
    }
}
