using System;

namespace Quests
{
    class Program
    {
        static void Main(string[] args)
        {
            var character = new Character(0, 0);
            var bot = new Bot(1, 1);
            var rock = new Rock(0, 1);

            Console.WriteLine("Хп персонажа " + character.Hp);
            Console.WriteLine("Хп бота " + bot.Hp);
            Console.WriteLine("Хп камня " + rock.Hp);

            character.Hit(character, bot);
            bot.Hit(bot, character);
            character.HitRock(character, rock);

            Console.WriteLine("Хп персонажа " + character.Hp);
            Console.WriteLine("Хп бота " + bot.Hp);
            Console.WriteLine("Хп камня " + rock.Hp);
        }
    }
}
