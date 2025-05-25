using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.MouseDown += Form1_MouseDown;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox bullet = new PictureBox();
                bullet.Size = bullettemp.Size;
                bullet.BackColor = bullettemp.BackColor;
 
                bullet.Location = new Point(
                    pictureBox1.Left + pictureBox1.Width / 2 - bullet.Width / 2,
                    pictureBox1.Top - bullet.Height
                );

                this.Controls.Add(bullet); 
                bullet.BringToFront();

                Timer bulletTimer = new Timer();
                bulletTimer.Interval = 10;
                bulletTimer.Tick += (s, ev) =>
                {
                    bullet.Top -= 10;
                    if (bullet.Top < 0)
                    {
                        bulletTimer.Stop();
                        this.Controls.Remove(bullet);
                        bullet.Dispose();
                    }
                };
                bulletTimer.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            int y = (ClientSize.Height - pictureBox1.Height);
            int x = (ClientSize.Width - pictureBox1.Width) / 2;
            pictureBox1.Location = new Point(x, y);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int moveAmount = 10;
            int newX = pictureBox1.Left;

            if (e.KeyCode == Keys.Right)
            {
                newX += moveAmount;
                if (newX + pictureBox1.Width > ClientSize.Width)
                    newX = ClientSize.Width - pictureBox1.Width;
            }
            else if (e.KeyCode == Keys.Left)
            {
                newX -= moveAmount;
                if (newX < 0)
                    newX = 0;
            }

            pictureBox1.Location = new Point(newX, pictureBox1.Top);

        }//jPEBFouvisevbfpizevwb pfi
    }
}
