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
        public Ball ball1, ball2, ball3, ball4, ball5;
        



        private Timer timer;

        List<Ball> balls = new List<Ball>();
        

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;



            timer = new Timer();
            timer.Interval = 20;
            timer.Tick += timer1_Tick_1;
            timer.Start();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rSize = new Random();//random size
            var lowerBound1 = 0;
            var upperBound1 = 130;
            var rNum1 = rSize.Next(lowerBound1, upperBound1);

            var rSpeed = new Random();// random speed
            var lowerBound2 = 0;
            var upperBound2 = 40;
            var rNum2 = rSpeed.Next(lowerBound2, upperBound2);

            var rDirection = new Random();// random direction
            var lowerBound3 = 0;
            var upperBound3 = 360;
            var rNum3 = rDirection.Next(lowerBound3, upperBound3);

            var random4 = new Random(); // random color
            Color randomColor = Color.FromArgb(random4.Next(256), random4.Next(256), random4.Next(256));


            balls.Add(new Ball(rNum1, rNum2, rNum3, 10, 10, randomColor));


        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;

            var rDirec = new Random();
            var lowerBound = 0;
            var upperBound = 360;
            var rD = rDirec.Next(lowerBound, upperBound);


            for (int i = 0; i < balls.Count; i++)// ball is drawn and moves based on the number of elements in the list
            {

                balls[i].DrawBall(g);
                balls[i].Move(pictureBox1.Width, pictureBox1.Height);

                for(int j = i + 1; j < balls.Count; j++)//Start of collision
                {

                    if (balls[i].Bounds.IntersectsWith(balls[j].Bounds))
                    {
                        double distance = Math.Sqrt(Math.Pow(balls[i].Bounds.X - balls[j].Bounds.X, 2) + Math.Pow(balls[i].Bounds.Y - balls[j].Bounds.Y, 2));

                        if (distance <= balls[i].Bounds.Width / 2 + balls[j].Bounds.Width / 2)
                        {

                            //collision is ocurring
                            balls[i].direction = rD - balls[i].direction;
                            balls[j].direction = rD - balls[j].direction;
                        }


                    }


                }//End of collision
            }

            
        }

    }
}
