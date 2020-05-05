using System.Collections.Generic;

namespace Quests
{
    public class Bot : Body, IAttacker, IAccoplishTakt
    {
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
            if (Geometry.AreNear(body1, body2)) // Проверяем рядом ли они
                body2.Hp -= 30;
        }

        /// <summary>
        /// Когда не знаем кого бить, но знаем куда
        /// </summary>
        /// <param name="bot">Кто бьёт</param>
        /// <param name="list">Список врагов(кого в теории мы можем ударить)</param>
        /// <param name="X">Х куда ударить</param>
        /// <param name="Y">Y куда ударить</param>
        public void CoordHit(Bot bot, List<Body> list, int X, int Y)
        {
            foreach (var targets in list)
            {
                if (X == targets.X && Y == targets.Y)
                        targets.Hp -= 30;
            }
        }

        public void AccomplishTakt(List<IAccoplishTakt> list)
        {
            Character character = new Character(0, 0);
            Bot bot = new Bot(0, 0);

            foreach(var lists in list)
            {
                if (lists is Bot)
                    bot = lists as Bot;

                else if (lists is Character)
                    character = lists as Character;
            }
            
            if (!Geometry.AreNear(bot, character))
            {
                if (!Geometry.AreNearX(bot.X, character.X))
                {
                    bot.X--;
                }
                else if (!Geometry.AreNearY(bot.Y, character.Y))
                {
                    bot.Y--;
                }
            }
            else
                    character.Hp -= 30;
        }
    }
}
