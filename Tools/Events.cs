using System;
using System.Collections.Generic;
using System.Text;

namespace Quests.Tools
{
    public static class Events
    {
        public static void NewHit(decimal damage)
        {
            Statistics.TotalHits++;
            Statistics.TotalDamage += damage;

            Console.WriteLine("");
            Console.WriteLine($"Всего нанесено урона: {Statistics.TotalDamage}");
            Console.WriteLine($"Всего нанесено ударов: {Statistics.TotalHits}");
        }
    }
}
