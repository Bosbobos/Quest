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
            var bot = new Bot(3, 2);
            var totem = new Totem(1, 1);
            var magic = new Magic();
            var magicArrow = new MagicArrow();

            var IAccomplishers = new List<IAccoplishTakt> { character, bot, totem };
            var targets = new List<Body> { character, bot, totem };

            while (true)
            {
                foreach (var Accomplishers in IAccomplishers)
                {
                    Accomplishers.AccomplishTakt(targets);
                    Thread.Sleep(16);
                }
            }
        }
    }
}
