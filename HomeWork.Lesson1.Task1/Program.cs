using System;
using System.Windows.Forms;

namespace HomeWork.Lesson1.Task1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Window.Instance.InitializeGameCore();

            Application.Run(Window.Instance);
        }
    }
}
