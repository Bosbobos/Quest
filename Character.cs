using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quests
{
    public class Character : Body, IAttacker, IAccoplishTakt
    {
        private int mana = 100;
        public int Mana
        {
            get
            {
                return mana;
            }
            set
            {
                if (value <= 100 && value >= 0)
                    mana = value;
                else if (value > 100)
                    mana = 100;
                else if (value < 0)
                    mana = 0;
            }
        }
        public static int HitRange = 1;
        public Character(int X, int Y) // Конструктор, чтобы мы могли указывать координаты рядом в скобках
        {
            this.X = X;
            this.Y = Y;
        }

        public void AccomplishTakt(List<Body> bodies)
        {
            Console.WriteLine($"");
            Console.WriteLine($"Такт выполняет персонаж {this}");

            this.Mana += 5;
            Console.WriteLine($"Мана персонажа { this } : { this.Mana }");

            foreach (var body in bodies)
            {
                if (mana >= 20)
                {
                    if (!(body is Character))
                    {
                        if (body is IUnhittable) // Проверяем воспринимает ли цель не физ урон
                        {
                            body.Hp -= 0; // Ничего не наносим
                            Console.WriteLine($"Персонаж бьёт { body }. Хп цели: {body.Hp}");

                            this.Mana -= 20; // Но ману снимаем
                            Console.WriteLine($"Мана персонажа: { this.Mana }.");
                        }
                        else
                        {
                            body.Hp -= 15; // Уже наносим дамаг
                            Console.WriteLine($"Персонаж бьёт { body }. Хп цели: {body.Hp}");

                            this.Mana -= 20; // Но всё ещё снимаем ману
                            Console.WriteLine($"Мана персонажа: { this.Mana }.");
                        }
                    }
                }
                else
                    Console.WriteLine($"Недостаточно маны для удара. Мана персонажа: {this.Mana}");
            }
        }
    }
}
