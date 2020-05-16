using Quests.Interfaces;
using Quests.Magics;
using Quests.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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

        public decimal EnergoShield;

        public TimeSpan ManaRegenCooldown { get; set; } = new TimeSpan(0, 0, 0, 2);
        public DateTime LastManaRegen { get; set; }

        public TimeSpan EnergoShieldCooldown { get; set; } = new TimeSpan(0, 0, 0, 10);
        public DateTime LastEnergoShield { get; set; }
        public TimeSpan EnergoShieldKastTime { get; set; } = new TimeSpan(0, 0, 0, 0, 900);

        public Character(int X, int Y) : base(X, Y)
        {
            Armour = 0.2m;
        }

        public List<Magic> Magics { get; set; } = new List<Magic>();

        public void AccomplishTakt(List<Body> bodies)
        {
            if (CycleManager.CanKast(LastManaRegen, ManaRegenCooldown))
            {
                this.Mana += 5;
                Console.WriteLine("");
                Console.WriteLine($"Мана персонажа { this } : { this.Mana }");

                LastManaRegen = DateTime.Now;
            }

            foreach (var body in bodies)
            {
                foreach (var i in Magics)
                {
                    if (CycleManager.CanKast(i.LastMagicKast, i.Cooldown))
                    {
                        if (i is IBattleMagic)
                        {
                            var BattleMagic = i as IBattleMagic;
                            BattleMagic.Hit(this, body);
                        }

                        i.LastMagicKast = DateTime.Now;
                    }
                    // Потом тут будет елс иф небоевая магия и то что она делает
                }
            }

            if (CycleManager.CanKast(LastEnergoShield, EnergoShieldCooldown) && EnergoShield < 50)
            {
                Thread.Sleep(EnergoShieldKastTime);

                EnergoShield = 50m;
                Console.WriteLine("");
                Console.WriteLine($"Персонаж {this} наложил на себя энергощит");

                LastEnergoShield = DateTime.Now;
            }
        }
    }
}
