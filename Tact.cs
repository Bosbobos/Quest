using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    public static class Tact
    {
        /// <summary>
        /// Такт - по сути ход, сюда мы записываем всё что должно происходить каждый ход
        /// </summary>
        public static void AccomplishTact(Character character, Totem totem)
        {
            character.Mana += 5;
            if (Geometry.AreNear(character.X, totem.X, character.Y, totem.Y))
                character.Mana += 2;
            Console.WriteLine(character.Mana);
        }
    }
}
