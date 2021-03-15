/*
 * Author : Alexander Dolgosheev
 * Github : https://github.com/dolgosheev
 * Mailto : alexanderdolgosheev@gmail.com
 * Task 2
 */

using System;
using System.Windows.Forms;

namespace AteroidsGame
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Window.Instance.InitializeGameCore();

            Application.Run(Window.Instance);
        }
    }
}
