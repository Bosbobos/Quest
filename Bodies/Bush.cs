using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    public class Bush : Body, IUnhittable
    {
        public string src = "./bush";

        public Bush(int X, int Y) // Конструктор, чтобы мы могли указывать координаты рядом в скобках
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
