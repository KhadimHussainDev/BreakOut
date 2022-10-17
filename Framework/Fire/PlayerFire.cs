using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Framework.Main;
using Framework.Movement;
using Framework.Collision;

namespace Framework.Fire
{
    public class PlayerFire:IFire
    {
        Image img;
        ObjectType objectType;
        IMovement movement;

        public PlayerFire(Image img,IMovement movement,ObjectType objectType)
        {
            this.img = img;
            this.objectType=objectType;
            this.movement = movement;
        }
        public GameObject fire(PictureBox player)
        {
            int top=player.Top-img.Height;
            int left=player.Left+player.Width/2-img.Width/2;
            GameObject fire = new GameObject(img, objectType, top, left,movement, new NoFire());
            return fire;
        }
    }
}
