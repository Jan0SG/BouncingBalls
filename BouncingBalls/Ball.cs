using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncingBalls
{
    public class Ball
    {
        public int size;
        public int speed;
        public int direction;
        private int x;
        private int y;
        private Color color;
        
       
        public Ball(int size, int speed, int direction, int x, int y, Color color)//constructor of each ball in the list
        {
            this.size = size;
            this.speed = speed;
            this.direction = direction;
            this.x = x;
            this.y = y;
            this.color = color;
            
           
        }

        public void Move(int width, int height)//ball movement
        {
            double radians = direction * Math.PI / 180;
            int deltaX = (int)(speed * Math.Cos(radians));
            int deltaY = (int)(speed * Math.Sin(radians));
            int newX = x + deltaX;
            int newY = y + deltaY;

            if (newX < 0 || newX > width - size)
            {
                //If the ball hits a horizontal wall, reverse its x direction.
                direction = 180 - direction;
                newX = x - deltaX;
            }

            if (newY < 0 || newY > height - size)
            {
                //If the ball hits a vertical wall, reverse its y direction.
                direction = -direction;
                newY = y - deltaY;
            }

            x = newX;
            y = newY;
        }

        public void DrawBall(Graphics g)//Draws the ball
        {
            Brush brush = new SolidBrush(color);
            g.FillEllipse(brush, x, y, size, size);
            
        }

        public Rectangle Bounds//bounds for collision
        {
            get { return new Rectangle(x, y, size, size); }
        }

        public bool CheckCollision(Ball other)//checks for collision
        {
            Rectangle rect1 = new Rectangle(x, y, size, size);
            Rectangle rect2 = new Rectangle(other.x, other.y, other.size/2, other.size/2);
            return rect1.IntersectsWith(rect2);
        }

        private double Distance(int x1, int y1, int x2, int y2)
        {
            int xDistance = x2 - x1;
            int yDistance = y2 - y1;
            return Math.Sqrt(xDistance * xDistance + yDistance * yDistance);
        }
        public bool CollidesWith(Ball otherBall)
        {
            double distance = Distance(x + size / 2, y + size / 2, otherBall.x + otherBall.size / 2, otherBall.y + otherBall.size / 2);
            return distance < size / 2 + otherBall.size / 2;
        }

        //float distanceBetweenCirclesSquared = (circle2.X - circle1.X) * (circle2.X - circle1.X) + (circle2.Y - circle1.Y) * (circle2.Y - circle1.Y);
    }
}
