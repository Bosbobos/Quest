using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    public class Character : Body, IAttacker
    {
        public int Mana = 100;
        public Character(int X, int Y) // Конструктор, чтобы мы могли указывать координаты рядом в скобках
        {
            this.X = X;
            this.Y = Y;
        }

        /// <summary>
        /// Когда знаем кого бить
        /// </summary>
        /// <param name="character">Кто бьёт</param>
        /// <param name="target">Кого бьют</param>
        public void Hit(Character character, Body target) 
        {
            if (target is IUnhittable) // Проверяем воспринимает ли цель не физ урон
            {
                if (Geometry.AreNear(character.X, target.X, character.Y, target.Y)) // Если не воспринмает
                {
                    target.Hp -= 0; // Ничего не наносим
                    character.Mana -= 20; // Но ману снимаем
                }
            }
            else
            {
                if (Geometry.AreNear(character.X, target.X, character.Y, target.Y)) // ЕСли воспринимает
                {
                    target.Hp -= 40; // Уже наносим дамаг
                    character.Mana -= 20; // Но всё ещё снимаем ману
                }               
            }
        }

        /// <summary>
        /// Когда не знаем кого бить, но знаем куда
        /// </summary>
        /// <param name="character">Кто бьёт</param>
        /// <param name="list">Список врагов(кого в теории мы можем ударить)</param>
        /// <param name="X">Х куда ударить</param>
        /// <param name="Y">Y куда ударить</param>
        public void CoordHit(Character character, List<Body> list, int X, int Y)
        {
            foreach (var targets in list)
            {
                if (X == targets.X && Y == targets.Y)
                {
                    if (targets is IUnhittable)
                    {
                        targets.Hp -= 0;
                        character.Mana -= 20;
                    }
                    else
                    {
                        targets.Hp -= 40;
                        character.Mana -= 20;
                    }
                }
            }
        }

        public void RangedHit(Character character, Body target)
        {
            if (target is IUnhittable) // Проверяем воспринимает ли цель не физ урон
            {
                target.Hp -= 0; // Ничего не наносим
                character.Mana -= 20; // Но ману снимаем
            }
            else
            {
                target.Hp -= 15; // Уже наносим дамаг
                character.Mana -= 20; // Но всё ещё снимаем ману
            }
        }

    }
}
