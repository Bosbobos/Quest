using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    /// <summary>
    /// Такт - по сути ход, сюда мы записываем всё что должно происходить каждый ход
    /// </summary>
    public static class Tact
    {
        public static void ManaRegen(Character character, Totem totem)
        {
            character.Mana += 5;
            if (Geometry.AreNear(character.X, totem.X, character.Y, totem.Y))
                character.Mana += 2;
            Console.WriteLine(character.Mana);
        }

        public static void MoveToTarget(Body attacker, Body target)
        { 
            if (!Geometry.AreNear(attacker.X, attacker.Y, target.X, target.Y))
            {
                attacker.X--;
                attacker.Y--;            
            }
        }
    }
}
