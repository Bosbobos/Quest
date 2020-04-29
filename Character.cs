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
        int HitRange = 1;

        public Character(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public void Hit(Character character, Bot bot)
        {
            if (bot.X - character.X <= HitRange && bot.Y - character.Y <= HitRange
                && character.X - bot.X <= HitRange && character.Y - bot.Y <= HitRange)
                bot.Hp -= 40;
        }

        public void HitRock(Character character, Rock rock)
        {
            if (rock.X - character.X <= HitRange && rock.Y - character.Y <= HitRange
                && character.X - rock.X <= HitRange && character.Y - rock.Y <= HitRange)
                rock.Hp -= 0;
        }
    }
}
