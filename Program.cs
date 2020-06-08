using Quests.Bodies;
using Quests.Magics;
using Quests.Tools;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Quests
{
    class Program
    {
        static void Main(string[] args)
        {
            var character = new Character(0, 0);
            var botMelee = new BotMelee(3, 2);
            var totem = new Totem(1, 1);
            var botArcher = new BotArcher(5, 5);

            var magicArrow = new MagicArrow();
            var manaRegen = new ManaRegen();
            var energoShield = new EnergoShield();           

            var IAccomplishers = new List<Body> {  botMelee, totem, character, botArcher };

            var cycleManager = new CycleManager(IAccomplishers);

            foreach (var Accomplisher in IAccomplishers)
            {
                Accomplisher.IGotDamageEvent += Events.NewHit;
                Accomplisher.IDiedEvent += cycleManager.DeathEventHandler;
            }

            character.Magics.Add(magicArrow);
            character.Magics.Add(manaRegen);
            character.Magics.Add(energoShield);

            cycleManager.AccomplishCycle();
        }
    }
}
