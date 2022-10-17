using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Main;
namespace Framework.Collision
{
    public interface ICollision
    {
        void action(IGame game,GameObject source1,GameObject source2);
    }
}
