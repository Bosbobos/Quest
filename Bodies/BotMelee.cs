using Quests.Magics;
using Quests.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Quests.Bodies
{
    public class BotMelee : Bot
    {
        public BotMelee(int X, int Y) : base(X, Y)
        {
            Armour = 0.15m;

            HitRange = 1;
            AttackDamage = 30;
            
            HitCooldown = new TimeSpan(0, 0, 0, 0, 500);
        }

        public override void Hit(Body target)
        {
            if (this.Id != target.Id && target.Hp > 0)
            {
                if (Magic.CanKast(LastHit, HitCooldown))
                {
                    DamageDealt = AttackDamage - (AttackDamage * target.Armour);

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
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"{this}: Бот ударил. Цель: { target }. Хп цели: { target.Hp - DamageDealt}");

                        target.Hp -= DamageDealt; ;
                    }

                    LastHit = DateTime.Now;
                }
            }
        }
    }
}
