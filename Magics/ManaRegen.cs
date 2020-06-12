using System;
using System.Collections.Generic;
using System.Text;

namespace Quests.Magics
{
    class ManaRegen : Magic
    {
        public ManaRegen()
        {
            Cooldown = new TimeSpan(0, 0, 0, 2);
        }

        public override void DoSomething(Character character, Body body)
        {
            if (CanKast(LastMagicKast, Cooldown) && character.Mana < 100)
            {
                character.Mana += 5;
                Console.WriteLine("");
                Console.WriteLine($"Мана персонажа { character } : { character.Mana }");

                LastMagicKast = DateTime.Now;
            }
        }
    }
}
