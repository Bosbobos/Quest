using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    interface IAttacer
    {
        public void Hit(Body body1, Body body2) // body1 - кто бьёт, body2 - кого бьют
        {
            if (body2 is Rock)
            {
                if (Geometry.AreNear(body1.X, body2.X, body1.Y, body2.Y))
                    body2.Hp -= 0;
            }
            else
            {
                if (Geometry.AreNear(body1.X, body2.X, body1.Y, body2.Y))
                    body2.Hp -= 40;
            }
        }
    }
}
