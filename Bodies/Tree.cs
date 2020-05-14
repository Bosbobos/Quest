using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    public class Tree : Body, IUnhittable
    {
        public string src = "./tree";

        public Tree(int X, int Y) // Конструктор, чтобы мы могли указывать координаты рядом в скобках
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
