using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    class Bush : Body, IUnhittable
    {
        public string src = "./bush";

        public Bush(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
