using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    public class Rock : Body, IUnhittable
    {
        public new decimal Hp { get; set; } = 1000m;
        public string src = "./rock";

        public Rock (int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
