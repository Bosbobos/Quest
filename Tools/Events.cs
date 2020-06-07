using System;
using System.Collections.Generic;
using System.Text;

namespace Quests.Tools
{
    public static class Events
    {
        public static void NewHit()
        {
            Statistics.TotalHits++;
            Console.WriteLine($"Всего нанесено ударов: {Statistics.TotalHits}");
        }

        public static void DealtDamage(decimal damage)
        {
            Statistics.TotalDamage += damage;
            Console.WriteLine($"Всего нанесено урона: {Statistics.TotalDamage}");
        }

        public static void Death()
        {

        }
    }
}
