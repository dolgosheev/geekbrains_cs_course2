
using System.Windows.Forms;

namespace HomeWork.Lesson1.Task1
{
    partial class Window
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.MaximumSize = new System.Drawing.Size(800, 600);

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.StartPosition = FormStartPosition.CenterScreen;


            this.Text = "Asteroids";
        }

        #endregion
    }
}

