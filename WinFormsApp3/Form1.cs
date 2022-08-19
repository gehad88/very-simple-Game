using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int points = 0;
        int missing = 0;
        Random r = new Random();
        void coinsDown(PictureBox coin,int speed)
        {
            if(coin.Top<=this.Height)
            coin.Top += speed;
            else
            {
                coin.Location = new Point((r.Next(100, this.Width - 100)), coin.Width);
                missing++;
                label2.Text = "Missing = -" + missing.ToString();
            }
            if (coin.Bounds.IntersectsWith(player.Bounds))
            {
                coin.Location = new Point((r.Next(100, this.Width - 100)), 20);
                points++;
                label1.Text = "Score = " + points.ToString();
            }
        }
        void piptLoc(PictureBox coin)
        {
           
                coin.Location = new Point((r.Next(100, this.Width - 100)), 3);
                missing++;
                label2.Text = "Missing = -" + missing.ToString();
          
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Left)
            {
                player.Image = Properties.Resources.marioLeft;
                if(player.Left>=0)
                player.Left -= 10;
            }

            if (e.KeyCode == Keys.Right)
            {
                player.Image = Properties.Resources.marioRight;
                if (player.Left <= this.Width-player.Width)
                    player.Left += 5;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            coinsDown(pictureBox1, 10);
            coinsDown(pictureBox3, 8);
            coinsDown(pictureBox4, 9);


        }

    }
}
