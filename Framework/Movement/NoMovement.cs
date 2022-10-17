using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Framework.Movement
{
    public class NoMovement : IMovement
    {
        public Point move(Point location)
        {
            return location;
        }
    }
}
