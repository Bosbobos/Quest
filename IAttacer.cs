using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    interface IAttacer
    {
        public void Hit(Body body, Body target) // body1 - кто бьёт, body2 - кого бьют
        {
            if (target is Rock)
            {
                if (Geometry.AreNear(body.X, target.X, body.Y, target.Y))
                    target.Hp -= 0;
            }
            else
            {
                if (Geometry.AreNear(body.X, target.X, body.Y, target.Y))
                    target.Hp -= 40;
            }
        }
        // TODO
        /*
     public void CoordHit(Character character, List<Body> list, int X, int Y)
     {
         foreach (var targets in list)
         {
             if (X == list.X && Y == list[].Y)
                 bot.Hp -= 20;
         }

     }
     */
    }
}
