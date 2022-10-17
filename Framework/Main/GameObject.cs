using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Framework.Movement;
using Framework.Collision;
using Framework.Fire;
namespace Framework.Main
{
    public class GameObject
    {
        PictureBox pb;
        IMovement iMovement;
        ObjectType otype;
        IFire fire;
       

        public GameObject(Image img,ObjectType otype, int top, int left, IMovement iMovement,IFire fire)
        {
            this.otype = otype;
            this.fire = fire;
            pb = new PictureBox();
            pb.Image = img;
            pb.Top = top;
            pb.Left = left;
            pb.Height=img.Height;
            pb.Width=img.Width;
            pb.BackColor = Color.Transparent;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            this.IMovement = iMovement;
        }

        public GameObject(Image img, ObjectType otype, int top, int left, int height, int width, IMovement iMovement, IFire fire)
        {
            pb = new PictureBox();
            pb.Image = img;
      //      pb.BackgroundImage = img;
            this.otype = otype;
            pb.Top = top;
            pb.Left = left;
            pb.Height = height;
            pb.Width = width;
            pb.BackColor = Color.Transparent;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
          //  pb.BackgroundImageLayout = ImageLayout.Stretch;
            this.iMovement = iMovement;
            this.fire = fire;
        }

        public PictureBox Pb { get => pb; set => pb = value; }
        public IMovement IMovement { get => iMovement; set => iMovement = value; }
        public ObjectType Otype { get => otype; set => otype = value; }
        public IFire Fire { get => fire; set => fire = value; }

        public void gameObjectMove()
        {
            pb.Location = iMovement.move(pb.Location);
        }
        public GameObject CreateFire(PictureBox player)
        {
            GameObject g= fire.fire(player);
            return g;
        }
    }
}
