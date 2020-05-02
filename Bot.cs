using System.Collections.Generic;

namespace Quests
{
    public class Bot : Body, IAttacer
    {
        public Bot(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public void Hit(Body body1, Body body2) // body1 - кто бьёт, body2 - кого бьют
        {
            if (body2 is IUnhittable)
            {
                if (Geometry.AreNear(body1.X, body2.X, body1.Y, body2.Y))
                    body2.Hp -= 0;
            }
            else
            {
                if (Geometry.AreNear(body1.X, body2.X, body1.Y, body2.Y))
                    body2.Hp -= 30;
            }
        }

        public void CoordHit(Bot bot, List<Body> list, int X, int Y)
        {
            foreach (var targets in list)
            {
                if (X == targets.X && Y == targets.Y)
                    if (targets is IUnhittable)
                        targets.Hp -= 0;
                    else
                        targets.Hp -= 30;
            }
        }
    }
}
