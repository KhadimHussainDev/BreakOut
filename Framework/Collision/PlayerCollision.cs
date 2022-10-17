using Framework.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Collision
{
    public class PlayerCollision : ICollision
    {
        public void action(IGame game, GameObject source1, GameObject source2)
        {
            GameObject player;
            if (source1.Otype == ObjectType.player)
            {
                player = source1 as GameObject;
            }
            else
            {
                player = source2 as GameObject;
            }
            game.raisePlayerDieEvent(player.Pb);
        }
    }
}
