using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Main;
namespace Framework.Collision
{
    public class PowerUpCollision : ICollision
    {
        public void action(IGame game, GameObject source1, GameObject source2)
        {
            GameObject PowerUp;
            if (source1.Otype == ObjectType.strip)
            {
                PowerUp = source2 as GameObject;
            }
            else
            {
                PowerUp = source1 as GameObject;
            }
            game.raisePowerUpDieEvent(PowerUp);
        }
    }
}
