using Quests.Interfaces;
using Quests.Magics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quests.Bodies
{
    public abstract class Bot : Mover, IAccoplishTakt
    {
        public static int HitRange;
        public static int AttackDamage;
        public decimal DamageDealt { get; set; }

        public Bot(int X, int Y) : base(X, Y)
        {
        }

        public TimeSpan HitCooldown { get; set; }        
        public DateTime LastHit { get; set; }


        public abstract void Hit(Body target);

        public override void AccomplishTakt(List<Body> bodies)
        {
            // получаем все тела персонажей
            // выбрать все уэлементы, у которых (тип Персонаж)
            var charactersBodies = bodies.Where(b => b is Character)  // b - элемент коллекции, как если бы ты написал foraech(var b in bodies)
                                         .ToList();

            var charactersBodiesInRadius = Geometry.InRadius(this, charactersBodies, HitRange);

            if (charactersBodiesInRadius.Count > 0) // если рядом кто-то есть, то бьем его
            {
                Character target = charactersBodiesInRadius.First() as Character;

                Hit(target);
            }
            else if (charactersBodies.Count > 0) // идем в нему 
            {
                Character target = charactersBodies.First() as Character;

                Move(this, target);
            }
        }
    }
}
