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
            if (target is Rock)
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
    }
}
