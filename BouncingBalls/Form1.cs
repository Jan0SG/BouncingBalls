using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncingBalls
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        private Ball ball1, ball2, ball3, ball4, ball5;
        private Timer timer;
        

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
           

            ball1 = new Ball(50, 20, 45, 10, 10, Color.CornflowerBlue);
            ball2 = new Ball(150, 10, 90, 10, 10, Color.DarkRed);
            ball3 = new Ball(15, 50, 38, 10, 10, Color.GreenYellow);
            ball4 = new Ball(78, 15, 15, 10, 10, Color.PaleGoldenrod);
            ball5 = new Ball(200, 5, 240, 10, 10, Color.MediumPurple);

            timer = new Timer();
            timer.Interval = 20;
            timer.Tick += timer1_Tick_1;
            timer.Start();

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;

        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {



                
                g.Clear(Color.White);
                ball1.Move(pictureBox1.Width, pictureBox1.Height);
                ball1.DrawBall(g);

                ball2.Move(pictureBox1.Width, pictureBox1.Height);
                ball2.DrawBall(g);

                ball3.Move(pictureBox1.Width, pictureBox1.Height);
                ball3.DrawBall(g);

                ball4.Move(pictureBox1.Width, pictureBox1.Height);
                ball4.DrawBall(g);

                ball5.Move(pictureBox1.Width, pictureBox1.Height);
                ball5.DrawBall(g);

                pictureBox1.Invalidate();
            
        }
    }
}
