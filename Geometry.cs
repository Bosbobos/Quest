using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    public static class Geometry
    {
        public static int HitRange = 1;
        /// <summary>
        /// Проверка рядом ли объекты
        /// </summary>
        public static bool AreNear(int X1, int X2, int Y1, int Y2)
        { 
            if (X1 - X2 <= HitRange && Y1 - Y2 <= HitRange
             && X2 - X1 <= HitRange && Y2 - Y1 <= HitRange)
                return true;
            else
                return false;
        }
    }
}
