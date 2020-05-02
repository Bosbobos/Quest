using System;
using System.Collections.Generic;

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

            foreach (var lists in bodies)
                Console.WriteLine(lists.Hp);

            Console.WriteLine(character.Mana);

            character.CoordHit(character, bodies, character.X - 1, character.Y);
            character.CoordHit(character, bodies, character.X + 1, character.Y);
            character.CoordHit(character, bodies, character.X + 1, character.Y + 1);
            character.CoordHit(character, bodies, character.X - 1, character.Y - 1);

            foreach (var lists in bodies)
                Console.WriteLine(lists.Hp);

            Console.WriteLine(character.Mana);
            /*
            Console.WriteLine("Хп персонажа " + character.Hp);
            Console.WriteLine("Хп бота " + bot.Hp);
            Console.WriteLine("Хп камня " + rock.Hp);

            character.Hit(character, bot);
            bot.Hit(bot, character);
            character.Hit(character, rock);

            Console.WriteLine("Хп персонажа " + character.Hp);
            Console.WriteLine("Хп бота " + bot.Hp);
            Console.WriteLine("Хп камня " + rock.Hp);
            */
        }

        static void AccomplishTact(Character character, Totem totem)
        {
            character.Mana += 5;
            if (Geometry.AreNear(character.X, totem.X, character.Y, totem.Y))
                character.Mana += 2;
        }
    }
}
