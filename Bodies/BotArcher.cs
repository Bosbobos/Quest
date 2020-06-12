using Quests.Magics;
using Quests.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quests.Bodies
{
    class BotArcher : Bot
    {
        public BotArcher(int X, int Y) : base(X, Y)
        {
            HitRange = 3;
            AttackDamage = 25;

            HitCooldown = new TimeSpan(0, 0, 0, 1, 500);
            MoveCooldown = new TimeSpan(0, 0, 1);
        }

        public override void Hit(Body target)
        {
            if (this.Id != target.Id)
            {
                if (Magic.CanKast(LastHit, HitCooldown))
                {
                    DamageDealt = AttackDamage - (AttackDamage * target.Armour);

                    if (!Geometry.SmbInBetween())
                    {
                        if (target is Character)
                        {
                            var _target = target as Character;

                            if (_target.EnergoShield > 0)
                            {
                                _target.EnergoShield -= DamageDealt;

                                Console.WriteLine("");
                                Console.WriteLine($"{this}: Бот ударил по энергощиту персонажа { _target }. Хп щита: { _target.EnergoShield }");
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine($"{this}: Бот ударил по персонажу { _target }. Хп цели: { _target.Hp - DamageDealt}");

                                _target.Hp -= DamageDealt;
                            }
                            Geometry.FlyAway(this, _target);
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine($"{this}: Бот ударил. Цель: { target }. Хп цели: { target.Hp - DamageDealt}");

                            target.Hp -= DamageDealt;
                            Geometry.FlyAway(this, target);
                        }
                    }

                    LastHit = DateTime.Now;
                }               
            }
        }
    }
}
