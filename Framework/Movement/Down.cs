using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Framework.Movement
{
    public class Down : IMovement
    {
        int speed;
        Point boundary;
        int offset = 120;
        public Down(int speed, Point boundary)
        {
            this.speed = speed;
            this.boundary = boundary;
        }
        public Point move(Point location)
        {
            if (location.Y <boundary.Y )
            {

                location.Y += speed;
            }
            else
            {
                //Invoke function to delete bullet
            }

            return location;
        }
    }
}
