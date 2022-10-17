using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Collision
{
    public class CollisionClass
    {
        ObjectType g1;
        ObjectType g2;
        ICollision action;
        public CollisionClass(ObjectType g1,ObjectType g2,ICollision action)
        {
            this.G1 = g1;
            this.G2 = g2;
            this.Action = action;
        }

        public ObjectType G1 { get => g1; set => g1 = value; }
        public ObjectType G2 { get => g2; set => g2 = value; }
        public ICollision Action { get => action; set => action = value; }
    }
}
