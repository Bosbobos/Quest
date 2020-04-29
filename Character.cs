using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    public class Character
    {
        public int X { get; set; }
        public int Y { get; set; }
        public decimal Hp { get; set; } = 100m;

        public Character(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
