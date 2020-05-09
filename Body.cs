using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    public abstract class Body
    {
        public int X { get; set; }
        public int Y { get; set; }
        private decimal hp = 100m;
        public decimal Hp
        {
            get
            {
                return hp;
            }
            set
            {
                if (value >= 0)
                    hp = value;
                else
                    hp = 0;
            }
        } 
    }
}
