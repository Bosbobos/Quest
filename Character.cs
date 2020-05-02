using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    public class Character : Body, IAttacer
    {
        public int Mana = 100;
        public Character(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public void Hit(Character character, Body target) // body1 - кто бьёт, body2 - кого бьют
        {
            if (target is IUnhittable)
            {
                if (Geometry.AreNear(character.X, target.X, character.Y, target.Y))
                {
                    target.Hp -= 0;
                    character.Mana -= 20;
                }

            }
            else
            {
                if (Geometry.AreNear(character.X, target.X, character.Y, target.Y))
                {
                    target.Hp -= 40;
                    character.Mana -= 20;
                }
                
            }
        }
        public void CoordHit(Character character, List<Body> list, int X, int Y)
        {
            foreach (var targets in list)
            {
                if (X == targets.X && Y == targets.Y)
                {
                    if (targets is IUnhittable)
                    {
                        targets.Hp -= 0;
                        character.Mana -= 20;
                    }
                    else
                    {
                        targets.Hp -= 40;
                        character.Mana -= 20;
                    }
                }
            }
        }
    }
}
