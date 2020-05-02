using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    class Bush : Body
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string src = "./bush";

        public Bush(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
