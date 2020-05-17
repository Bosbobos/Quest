using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Quests.Magics
{
    class EnergoShield : Magic
    {
        public EnergoShield()
        {
            Cooldown = new TimeSpan(0, 0, 0, 10);
        }

        public TimeSpan EnergoShieldKastTime { get; set; } = new TimeSpan(0, 0, 0, 0, 900);

        public override void DoSomething(Character character, Body body)
        { 
        if (CanKast(LastMagicKast, Cooldown) && character.EnergoShield < 50)
            {
                Thread.Sleep(EnergoShieldKastTime);

                character.EnergoShield = 50m;
                Console.WriteLine("");
                Console.WriteLine($"Персонаж {this} наложил на себя энергощит");

                LastMagicKast = DateTime.Now;
            }
        }
    }
}
