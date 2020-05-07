using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    public class Character : Body, IAttacker, IAccoplishTakt
    {
        public int Mana = 100;
        public static int HitRange = 1;
        public Character(int X, int Y) // Конструктор, чтобы мы могли указывать координаты рядом в скобках
        {
            this.X = X;
            this.Y = Y;
        }

        public void AccomplishTakt(Character character, Body body, Totem totem)
        {
            character.Mana += 5;
            if (Geometry.AreNear(character, totem, HitRange))
                character.Mana += 2;
            Console.WriteLine(character.Mana);

            if (body is IUnhittable) // Проверяем воспринимает ли цель не физ урон
            {
                body.Hp -= 0; // Ничего не наносим
                character.Mana -= 20; // Но ману снимаем
            }
            else
            {
                body.Hp -= 15; // Уже наносим дамаг
                character.Mana -= 20; // Но всё ещё снимаем ману
            }
        }
    }
}
