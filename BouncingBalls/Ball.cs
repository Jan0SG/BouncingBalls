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
        private int size;
        private int speed;
        public int direction;
        private int x;
        private int y;
        private Color color;

        public Ball(int size, int speed, int direction, int x, int y, Color color)
        {
            this.size = size;
            this.speed = speed;
            this.direction = direction;
            this.x = x;
            this.y = y;
            this.color = color;
           
        }

        public void Move(int width, int height)
        {
            double radians = direction * Math.PI / 180;
            int deltaX = (int)(speed * Math.Cos(radians));
            int deltaY = (int)(speed * Math.Sin(radians));
            int newX = x + deltaX;
            int newY = y + deltaY;

            if (newX < 0 || newX > width - size)
            {
                // If the ball hits a horizontal wall, reverse its x direction.
                direction = 180 - direction;
                newX = x - deltaX;
            }

            if (newY < 0 || newY > height - size)
            {
                // If the ball hits a vertical wall, reverse its y direction.
                direction = -direction;
                newY = y - deltaY;
            }

            x = newX;
            y = newY;
        }

        public void DrawBall(Graphics g)
        {
            Brush brush = new SolidBrush(color);
            g.FillEllipse(brush, x, y, size, size);
            
        }

        public Rectangle Bounds
        {
            get { return new Rectangle(x, y, size, size); }
        }
    }
}
