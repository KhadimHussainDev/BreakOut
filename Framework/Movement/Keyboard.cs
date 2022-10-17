using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Framework.Movement
{
    public class Keyboard : IMovement
    {
        int speed;
        string direction=null;
        Point boundaryLeftRight;
        Point boundaryUpDown;
        int offset = 120;
        public Keyboard(int speed,int offset, Point boundaryLeftRight,Point boundaryUpDown)
        {
            this.speed = speed;
            this.boundaryLeftRight = boundaryLeftRight;
            this.boundaryUpDown = boundaryUpDown;
            this.offset = offset;
        }
        public Point move(Point location)
        {
            if (direction == "up")
            {
                if(location.Y>boundaryUpDown.X)
                location.Y -= speed;
            }
            if (direction == "down")
            {
                if (location.Y+offset < boundaryUpDown.Y)
                    location.Y += speed;
            }
            if(direction =="left")
            {
                if(location.X>boundaryLeftRight.X)
                location.X -= speed;
            }
            if (direction == "right")
            {
                if (location.X +offset< boundaryLeftRight.Y)
                    location.X += speed;
            }
            direction = null;
            return location;
        }

        public void keyPressed(Keys key)
        {
            if(key == Keys.Up)
            {
                direction = "up";
            }
            else if(key == Keys.Down)
            {
                direction = "down";
            }
            else if (key == Keys.Left)
            {
                direction = "left";
            }
            else if( key == Keys.Right)
            {
                direction="right";
            }
        }
    }
}