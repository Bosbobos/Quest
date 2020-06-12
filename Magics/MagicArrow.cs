using System;
using System.Collections.Generic;
using System.Text;

namespace Quests.Magics
{
    public class MagicArrow : Magic
    {
        public MagicArrow()
        {
            Cooldown = new TimeSpan(0, 0, 0, 0, 900);
        }

        public override void DoSomething(Character attacker, Body target)
        {
            if (CanKast(LastMagicKast, Cooldown))
            {
                if (attacker.Mana >= 20)
                {
                    if (attacker.Id != target.Id)
                    {
                        if (target is IUnhittable) // Проверяем воспринимает ли цель не физ урон
                        {
                            target.Hp -= 0; // Ничего не наносим
                            Console.WriteLine($"Персонаж бьёт { target }. Хп цели: {target.Hp}");

                            attacker.Mana -= 20; // Но ману снимаем
                            Console.WriteLine($"Мана персонажа: { attacker.Mana }.");
                        }
                        else
                        {
                            target.Hp -= 15; // Уже наносим дамаг
                            Console.WriteLine($"Персонаж бьёт { target }. Хп цели: {target.Hp}");

                            attacker.Mana -= 20; // Но всё ещё снимаем ману
                            Console.WriteLine($"Мана персонажа: { attacker.Mana }.");
                        }

                        LastMagicKast = DateTime.Now;
                    }
                }
                else
                    Console.WriteLine($"Недостаточно маны для удара. Мана персонажа: {attacker.Mana}");
            }
        }
    }
}
