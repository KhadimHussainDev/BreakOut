using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Main;

namespace Framework.Collision
{
    public class ballAndBrickCollision : ICollision
    {
        public void action(IGame game, GameObject source1, GameObject source2)
        {
            GameObject brick,ball;
            if (source1.Otype == ObjectType.bricks)
            {
                brick = source1 as GameObject;
                ball = source2 as GameObject;
            }
            else
            {
                brick = source2 as GameObject;
                ball=source1 as GameObject;
            }
            game.raisePlayerDieEvent(brick.Pb);
            game.raiseEventToReverseDirectionOfBall(ball);
            game.raiseEventToIncreaseScore();
        }
    }
}
