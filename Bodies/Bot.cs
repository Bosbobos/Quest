using Quests.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Quests
{
    public class Bot : Body, IAccoplishTakt
    {
        public static int HitRange = 1;

        public Bot(int X, int Y) : base(X, Y)
        {
        }

        public TimeSpan HitCooldown { get; set; } = new TimeSpan(0, 0, 0, 0, 500);
        public TimeSpan MoveCooldown { get; set; } = new TimeSpan(0, 0, 0, 1);
        public DateTime LastHit { get; set; }
        public DateTime LastMove { get; set; }

        public void AccomplishTakt(List<Body> bodies)
        {            
            // стукнуть ближайшего персонажа
            // если такого нет, то идем к ближайшему

            // получаем все тела персонажей
            // выбрать все уэлементы, у которых (тип Персонаж)
            var charactersBodies = bodies.Where(b => b is Character)  // b - элемент коллекции, как если бы ты написал foraech(var b in bodies)
                                         .ToList();

            var charactersBodiesInRadius = Geometry.InRadius(this, charactersBodies, HitRange);

            if (charactersBodiesInRadius.Count > 0) // если рядом кто-то есть, то бьем его
            {
                Character target = charactersBodiesInRadius.First() as Character;

                if (target.Hp > 0)
                {
                    if (CycleManager.CanKast(LastHit, HitCooldown))
                    {
                        target.Hp -= 30; // бьем цель
                        Console.WriteLine("");
                        Console.WriteLine($"Бот ударил. Цель: { target }. Хп цели: { target.Hp }");

                        LastHit = DateTime.Now;
                    }
                }
            }
            else // идем в нему
            {
                Character target = charactersBodies.First() as Character;

                if (target.Hp > 0)
                {
                    if (CycleManager.CanKast(LastMove, MoveCooldown))
                    {
                        // меняем координаты this.X и Y в сторону перса
                        if (this.X > target.X)
                        {
                            this.X--;
                            Console.WriteLine("");
                            Console.WriteLine($"Х бота больше Х цели. Бот идёт к цели. Х бота: { this.X }");
                        }
                        else if (this.X < target.X)
                        {
                            this.X++;
                            Console.WriteLine("");
                            Console.WriteLine($"Х бота меньше Х цели. Бот идёт к цели. Х бота: { this.X }");
                        }

                        if (this.Y > target.Y)
                        {
                            this.Y--;
                            Console.WriteLine("");
                            Console.WriteLine($"Y бота больше Y цели. Бот идёт к цели. Y бота: { this.Y }");
                        }
                        else if (this.X < target.X)
                        {
                            this.Y++;
                            Console.WriteLine("");
                            Console.WriteLine($"Y бота меньше Y цели. Бот идёт к цели. Y бота { this.Y }");
                        }

                        LastMove = DateTime.Now;
                    }
                }
            }            
        }
    }
}
