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
            if (target.Hp > 0 && this.Id != target.Id)
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
                            _target.Hp -= DamageDealt; ;

                            Console.WriteLine("");
                            Console.WriteLine($"{this}: Бот ударил по персонажу { _target }. Хп цели: { _target.Hp }");
                        }
                    }
                    else
                    {
                        target.Hp -= DamageDealt; ;

                        Console.WriteLine("");
                        Console.WriteLine($"{this}: Бот ударил. Цель: { target }. Хп цели: { target.Hp }");
                    }

                    Statistics.TotalMeleeHits++;
                    Statistics.TotalHits++;
                    Statistics.TotalDamage += DamageDealt;

                    Console.WriteLine($"Всего нанесено ближних ударов: {Statistics.TotalMeleeHits}");
                    Console.WriteLine($"Всего нанесено ударов: {Statistics.TotalHits}");
                    Console.WriteLine($"Всего нанесено урона: {Statistics.TotalDamage}");

                    LastHit = DateTime.Now;
                }
            }
        }
    }
}
