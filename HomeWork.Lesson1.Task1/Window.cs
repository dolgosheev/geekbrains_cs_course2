using System;
using System.Windows.Forms;

namespace HomeWork.Lesson1.Task1
{
    public partial class Window : Form
    {
        internal static Window Instance => LazyInstance.Value;
        private static readonly Lazy<Window> LazyInstance = new Lazy<Window>(() => new Window());

        private Window()
        {
            InitializeComponent();
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
