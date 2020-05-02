using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    public class Character
    {
        public int X { get; set; }
        public int Y { get; set; }
        public decimal Hp { get; set; } = 100m;
        public decimal Mana { get; set; } = 100m;

        public Character(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public void MentalHit(Character character, Bot bot)
        {
            if (Geometry.AreNear(bot.X, character.X, bot.Y, character.Y))
            {
                bot.Hp -= 40;
                character.Mana -= 20;
            }
        }

        public void MentalHitRock(Character character, Rock rock)
        {
            if (Geometry.AreNear(character.X, rock.X, character.Y, rock.Y))
                rock.Hp -= 0;
        }
    }
}
