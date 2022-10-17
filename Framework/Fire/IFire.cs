using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Framework.Main;
using Framework.Movement;
namespace Framework.Fire
{
    public interface IFire
    {
        GameObject fire(PictureBox player);
    }
}
