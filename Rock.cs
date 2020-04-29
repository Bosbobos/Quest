using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    public class Rock
    {
        public int X { get; set; }
        public int Y { get; set; }
        public decimal Hp { get; set; } = 1000m;

        public Rock (int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
