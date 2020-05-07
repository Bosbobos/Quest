using System.Collections.Generic;
using System.Linq;

namespace Quests
{
    public class Bot : Body, IAttacker, IAccoplishTakt
    {
        public static int HitRange = 1;
        public Bot(int X, int Y) // Конструктор, чтобы мы могли указывать координаты рядом в скобках
        {
            this.X = X;
            this.Y = Y;
        }
        /// <summary>
        /// Когда знаем кого бить
        /// </summary>
        /// <param name="body1">Кто бьёт</param>
        /// <param name="body2">Кого бьют</param>
        public void Hit(Body body1, Body body2) 
        {
            if (Geometry.AreNear(body1, body2, HitRange)) // Проверяем рядом ли они
                body2.Hp -= 30;
        }

        /// <summary>
        /// Когда не знаем кого бить, но знаем куда
        /// </summary>
        /// <param name="bot">Кто бьёт</param>
        /// <param name="list">Список врагов(кого в теории мы можем ударить)</param>
        /// <param name="X">Х куда ударить</param>
        /// <param name="Y">Y куда ударить</param>
        public void CoordHit(List<Body> list, int X, int Y)
        {
            foreach (var targets in list)
            {
                if (X == targets.X && Y == targets.Y)
                        targets.Hp -= 30;
            }
        }

        public void AccomplishTakt(List<Body> bodies)
        {
            // стукнуть ближайшего персонажа
            // если такого нет, то идем к ближайшему

            // получаем все тела персонажей
            // выбрать все уэлементы, у которых (тип Персонаж)
            var charactersBodyes = bodies.Where(b => b is Character)  // b - элемент коллекции, как если бы ты написал foraech(var b in bodies)
                                         .ToList();

            var телаПерсонажейВрадиусеУдара = Geometry.TheNearest(this, charactersBodyes, HitRange);

            if (телаПерсонажейВрадиусеУдара.Count > 0) // если рядом кто-то есть, то бьем его
            {
                Character target = телаПерсонажейВрадиусеУдара.First() as Character;
                target.Hp -= 30; // бьем цель
            }
            else // идем в нему
            {
                Character target = charactersBodyes.First() as Character;
                
                // меняем координаты this.X и Y в сторону перса
                if (!Geometry.AreNearX(this.X, target.X, HitRange))
                {
                    this.X--;
                }
                else if (!Geometry.AreNearY(this.Y, target.Y, HitRange))
                {
                    this.Y--;
                }
                
            }            
        }
    }
}
