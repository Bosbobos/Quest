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
        public static bool AreNear(Body body1, Body body2)
        {
            int X1 = body1.X;
            int X2 = body2.X;
            int Y1 = body1.Y;
            int Y2 = body2.Y;

            if (X1 - X2 <= HitRange && Y1 - Y2 <= HitRange
             && X2 - X1 <= HitRange && Y2 - Y1 <= HitRange)
                return true;
            else
                return false;
        }

        public static bool AreNearX(int X1, int X2)
        {
            if (X1 - X2 <= HitRange && X2 - X1 <= HitRange)
                return true;
            else
                return false;
        }

        public static bool AreNearY(int Y1, int Y2)
        {
            if (Y1 - Y2 <= HitRange && Y2 - Y1 <= HitRange)
                return true;
            else
                return false;
        }
    }
}
