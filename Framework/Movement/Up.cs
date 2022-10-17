using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Framework.Movement
{
    public class Up:IMovement
    {
        int speed;
        public Up(int speed)
        {
            this.speed = speed;
        }
        public Point move(Point location)
        {
            if (location.Y > 0)
            {
                location.Y -= speed;
            }
            return location;
        }
    }
}
