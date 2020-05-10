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

        public Totem(int X, int Y) // Конструктор, чтобы мы могли указывать координаты рядом в скобках
        {
            this.X = X;
            this.Y = Y;
        }

        public void AccomplishTakt(List<Body> bodies)
        {
            Console.WriteLine($"");
            Console.WriteLine($"Такт выполняет тотем {this}");

            var charactersBodiesInRadius = Geometry.InRadius(this, bodies, 2);

            var characters = charactersBodiesInRadius.Where(b => b is Character)
                                                     .Select(o => o as Character);

            foreach (var i in characters)
            {
                i.Mana += 2;
                Console.WriteLine($"Тотем {this} восстановил ману персонажу {i}. " +
                    $"Его мана: {i.Mana}");
            }
        }
    }
}
