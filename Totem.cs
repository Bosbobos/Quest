using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    class Totem : Body
    {
        public string src = "./totem";

        public Totem(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
