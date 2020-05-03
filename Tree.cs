using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    class Tree : Body, IUnhittable
    {
        public string src = "./tree";

        public Tree(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
