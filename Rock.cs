using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    public class Rock : Body
    {
        public new decimal Hp { get; set; } = 1000m;

        public Rock (int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
