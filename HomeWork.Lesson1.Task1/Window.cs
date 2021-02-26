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
    }
}
