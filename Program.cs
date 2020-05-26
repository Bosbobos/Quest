using Quests.Bodies;
using Quests.Magics;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Quests
{
    class Program
    {
        static void Main(string[] args)
        {
            var character = new Character(0, 0) { Hp = 100 };
            var botMelee = new BotMelee(3, 2);
            var totem = new Totem(1, 1);
            var botArcher = new BotArcher(5, 5);

            var magicArrow = new MagicArrow();
            var manaRegen = new ManaRegen();
            var energoShield = new EnergoShield();

            var IAccomplishers = new List<Body> {  /*botMelee, totem */character, botArcher };

            character.Magics.Add(magicArrow);
            character.Magics.Add(manaRegen);
            character.Magics.Add(energoShield);

            while (true)
            {
                foreach (var Accomplishers in IAccomplishers)
                {
                    if (Accomplishers.Hp == 0)
                    {
                        IAccomplishers.Remove(Accomplishers);
                    }
                    Accomplishers.AccomplishTakt(IAccomplishers);                    
                }
                Thread.Sleep(16);
            }
        }
    }
}
