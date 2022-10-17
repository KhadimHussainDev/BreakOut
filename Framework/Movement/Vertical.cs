using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Framework.Movement
{
    public class Vertical : IMovement
    {
        int speed;
        string direction;
        Point boundary;
        int offset = 120;

        public Vertical(int speed, Point boundary, string direction)
        {
            this.speed = speed;
            this.boundary = boundary;
            this.direction = direction;
        }
        public Point move(Point location)
        {
            if (location.Y <= 0)
            {
                direction = "down";
            }
            else if (location.Y +offset>= boundary.Y)
            {
                direction = "up";
            }
            if (direction == "up")
            {
                location.Y -= speed;
            }
            else if (direction == "down")
            {
                location.Y += speed;
            }
            return location;
        }
    }
}
