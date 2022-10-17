using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Main;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Collision
{
    public class PlayerBulletCollision : ICollision
    {
        public void action(IGame game, GameObject source1, GameObject source2)
        {
            GameObject bullet,enemy;
            if (source1.Otype == ObjectType.playerBullets)
            {
                bullet = source1 as GameObject;
                enemy = source2 as GameObject;
            }
            else
            {
                bullet = source2 as GameObject;
                enemy = source1 as GameObject;
            }
            game.raiseEnemyDieEvent(bullet.Pb,enemy.Pb);
        }
    }
}
