using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    public abstract class Body
    {
        public int X { get; set; }
        public int Y { get; set; }
        public decimal Hp { get; set; } = 100m;
    }
}
