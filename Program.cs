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
            var bot = new Bot(1, 1);

            var IAccomplishers = new List<IAccoplishTakt> { character, bot };
           
            while (true)
            {
                character.RangedHit(character, bot);
                Thread.Sleep(5000);
            }
        }
    }
}
