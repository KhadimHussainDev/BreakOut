using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Framework.Movement;
namespace Framework.Movement
{
    public class movementOfBall : IMovement
    {
        int speed;
        bool isGoingUp;
        bool isGoingRight;
        Point boundaryLeftRight;
        Point boundaryUPDown;

        public movementOfBall(int speed, bool isGoingUp, bool isGoingRight, Point boundaryLeftRight, Point boundaryUPDown)
        {
            this.speed = speed;
            this.IsGoingUp = isGoingUp;
            this.IsGoingRight = isGoingRight;
            this.boundaryLeftRight = boundaryLeftRight;
            this.boundaryUPDown = boundaryUPDown;
        }

        public bool IsGoingUp { get => isGoingUp; set => isGoingUp = value; }
        public bool IsGoingRight { get => isGoingRight; set => isGoingRight = value; }

        public Point move(Point location)
        {
            if (IsGoingRight)
            {
                if (location.X + speed <= boundaryLeftRight.Y)
                {

                location.X += speed;
                }
                else
                {
                    IsGoingRight = false;
                }
            }
            else
            {
                if (location.X + speed >= boundaryLeftRight.X)
                {

                location.X -= speed;
                }
                else
                {
                    IsGoingRight = true;
                }
            }
            if (IsGoingUp)
            {
                if (location.Y + speed >= boundaryUPDown.X)
                {

                location.Y -= speed;
                }
                else
                {
                    IsGoingUp = false;
                }
            }
            else
            {
                if (location.Y + speed <= boundaryUPDown.Y)
                {

                location.Y += speed;
                }
                else
                {
                    IsGoingUp = true;
                }
            }
            return location;
        }
    }
}
