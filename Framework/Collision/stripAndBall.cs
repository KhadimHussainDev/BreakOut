using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Collision;
using Framework.Main;

namespace Framework.Collision
{
    public class stripAndBall : ICollision
    {
        public void action(IGame game, GameObject source1, GameObject source2)
        {
            GameObject g;
            if (source1.Otype == ObjectType.ball)
            {
                g=source1;
            }
            else
            {
                g=source2;
            }
            game.raiseEventToReverseDirectionOfBall(g);
            game.raiseEventToUpdateTries();
        }
    }
}
