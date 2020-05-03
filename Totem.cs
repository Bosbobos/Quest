using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    /// <summary>
    /// Если находится рядом с персонажем, даёт ему +2 восстановления маны
    /// </summary>
    public class Totem : Body, IUnhittable
    {
        public string src = "./totem";

        public Totem(int X, int Y) // Конструктор, чтобы мы могли указывать координаты рядом в скобках
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
