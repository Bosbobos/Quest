using Quests.Magics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quests
{
    /// <summary>
    /// Если находится рядом с персонажем, даёт ему +2 восстановления маны
    /// </summary>
    public class Totem : Body, IUnhittable, IAccoplishTakt
    {
        public string src = "./totem";

        public TimeSpan ManaRegenCooldown { get; set; } = new TimeSpan(0, 0, 0, 2);
        public DateTime LastManaRegen { get; set; }

        public Totem(int X, int Y) : base(X, Y)
        {
        }

        public override void AccomplishTakt(List<Body> bodies)
        {
            var charactersBodiesInRadius = Geometry.InRadius(this, bodies, 2);

            var characters = charactersBodiesInRadius.Where(b => b is Character)
                                                     .Select(o => o as Character);

            foreach (var i in characters)
            {
                if (Magic.CanKast(LastManaRegen, ManaRegenCooldown) && i.Mana < 100)
                {
                    i.Mana += 2;

                    Console.WriteLine("");
                    Console.WriteLine($"Тотем {this} восстановил ману персонажу {i}. " +
                        $"Его мана: {i.Mana}");

                    LastManaRegen = DateTime.Now;
                }
            }
        }
    }
}
