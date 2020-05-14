using Quests.Interfaces;
using Quests.Magics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quests
{
    public class Character : Body, IAccoplishTakt
    {
        private int mana = 100;
        public int Mana
        {
            get
            {
                return mana;
            }
            set
            {
                if (value <= 100 && value >= 0)
                    mana = value;
                else if (value > 100)
                    mana = 100;
                else if (value < 0)
                    mana = 0;
            }
        }
        public static int HitRange = 1;

        public Character(int X, int Y) : base(X, Y)
        {
        }

        public List<Magic> Magics { get; set; }

        public void AccomplishTakt(List<Body> bodies)
        {
            MagicArrow magicArrow = new MagicArrow();
            Console.WriteLine($"");
            Console.WriteLine($"Такт выполняет персонаж {this}");

            this.Mana += 5;
            Console.WriteLine($"Мана персонажа { this } : { this.Mana }");

            foreach (var body in bodies)
            {
                foreach (var i in Magics)
                {
                    if (i.CanKast())
                    {
                        if (i is IBattleMagic)
                        {
                            var BattleMagic = i as IBattleMagic;
                            BattleMagic.Hit(this, body);
                        }
                    }
                    // Потом тут будет елс иф небоевая магия и то что она делает
                }
            }
        }
    }
}
