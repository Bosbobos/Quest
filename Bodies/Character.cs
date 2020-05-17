using Quests.Magics;
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

        public Character(int X, int Y) : base(X, Y)
        {
            Armour = 0.2m;
        }

        public List<Magic> Magics { get; set; } = new List<Magic>();

        public void AccomplishTakt(List<Body> bodies)
        {
            foreach (var body in bodies)
            {
                foreach (var i in Magics)
                {
                    i.DoSomething(this, body);
                }
            }
        }
    }
}

