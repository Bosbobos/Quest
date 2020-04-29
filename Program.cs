using System;

namespace Quests
{
    class Program
    {
        static void Main(string[] args)
        {
            var character = new Character(0, 0);
            var bot = new Bot(2, 2);           
            Console.WriteLine(character.Hp);

            bot.Hit(bot, character);
            Console.WriteLine(character.Hp);
        }
    }
}
