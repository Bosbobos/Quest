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
            var rock = new Rock(2, 3);
            var totem = new Totem(1, 1);
            var tree = new Tree(2, 2);
            var bush = new Bush(1, 1);

            var bodies = new List<Body> { character, bot, rock, totem, tree, bush };

            Console.WriteLine("Бьёт персонаж");
            
            Console.WriteLine("");
            foreach (var lists in bodies)
                Console.WriteLine($"{lists.GetType().Name}: {lists.Hp}.");
            
            Console.WriteLine("");
            Console.WriteLine("Мана" + character.Mana);

            character.CoordHit(character, bodies, character.X - 1, character.Y);
            character.CoordHit(character, bodies, character.X + 1, character.Y);
            character.CoordHit(character, bodies, character.X + 1, character.Y + 1);
            character.CoordHit(character, bodies, character.X - 1, character.Y - 1);

            Console.WriteLine("");
            foreach (var lists in bodies)
                Console.WriteLine($"{lists.GetType().Name}: {lists.Hp}.");

            Console.WriteLine("");
            Console.WriteLine("Мана" + character.Mana);

            Console.WriteLine("");
            Console.WriteLine("Бьёт бот");
            
            bot.CoordHit(bot, bodies, bot.X - 1, bot.Y);
            bot.CoordHit(bot, bodies, bot.X + 1, bot.Y);
            bot.CoordHit(bot, bodies, bot.X + 1, bot.Y + 1);
            bot.CoordHit(bot, bodies, bot.X - 1, bot.Y - 1);

            Console.WriteLine("");
            foreach (var lists in bodies)
                Console.WriteLine($"{lists.GetType().Name}: {lists.Hp}.");

            Console.WriteLine("");
            Console.WriteLine("Последняя часть");

            Console.WriteLine("");
            Console.WriteLine("Bot:" + bot.Hp);
            Console.WriteLine("Character:" + character.Hp);

            bot.Hit(bot, character);
            character.Hit(character, bot);

            Console.WriteLine("");
            Console.WriteLine("Bot:" + bot.Hp);
            Console.WriteLine("Character:" + character.Hp);

            while (true)
            {
                Tact.ManaRegen(character, totem);
                Tact.MoveToTarget(bot, character);
                character.RangedHit(character, bot);
                Thread.Sleep(5000);
            }
        }
    }
}
