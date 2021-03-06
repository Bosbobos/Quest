﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    public static class Geometry
    {
        /// <summary>
        /// Проверка рядом ли объекты
        /// </summary>
        public static bool AreNear(Body body1, Body body2, int HitRange)
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

        public static decimal GetSegmentLength(int X1, int Y1, int X2, int Y2)
        {
            return (decimal)Math.Sqrt(Math.Pow((X2 - X1), 2) + Math.Pow((Y2 - Y1), 2));
        }

        public static List<Body> InRadius(Body target ,List<Body> bodies, int length)
        {
            var result = new List<Body>();
            // для каждого из bodies считаем длинну отрезка до target и возвращаем всех кто прошел
            foreach(var body in bodies)
            {
                var SegmentLength = GetSegmentLength(body.X, body.Y, target.X, target.Y);
                if (SegmentLength <= length)
                {
                    result.Add(body);
                }
            }
            return result;
        }

        public static bool SmbInBetween()
        {
            return false;
        }

        public static void FlyAway(Body attacker, Body target)
        {
            if (attacker.X > target.X)
                target.X -= 1;
            else if (attacker.X < target.X)
                target.X += 1;
            else if (attacker.Y > target.Y)
                target.Y -= 1;
            else if (attacker.Y < target.Y)
                target.Y += 1;

            Console.WriteLine("");
            Console.WriteLine($"{target} отлетел. Его Х: {target.X}. Его У: {target.Y}");
        }
    }
}
