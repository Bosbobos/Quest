using Quests.Magics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quests.Interfaces
{
    public abstract class Mover : Body
    {

        public Mover(int X, int Y) : base(X, Y)
        {
        }

        public TimeSpan MoveCooldown { get; set; }
        public DateTime LastMove { get; set; }

        // void Move(Body mover, Body target);
        public void Move(Body mover, Body target)
        {
            if (target.Hp > 0 )
            {
                if (Magic.CanKast(LastMove, MoveCooldown))
                {
                    // меняем координаты this.X и Y в сторону перса
                    if (mover.X != target.X)
                    {
                        if (mover.X > target.X)
                        {
                            mover.X--;
                            Console.WriteLine("");
                            Console.WriteLine($"{mover}: X больше X цели. Идёт к цели. X : { mover.X }");
                        }
                        else if (mover.X < target.X)
                        {
                            mover.X++;
                            Console.WriteLine("");
                            Console.WriteLine($"{mover}: X меньше X цели. Идёт к цели. X : { mover.X }");
                        }
                    }

                    if (mover.Y != target.Y)
                    {
                        if (mover.Y > target.Y)
                        {
                            mover.Y--;
                            Console.WriteLine("");
                            Console.WriteLine($"{mover}: Y больше Y цели. Идёт к цели. Y : { mover.Y }");
                        }
                        else if (mover.Y < target.Y)
                        {
                            mover.Y++;
                            Console.WriteLine("");
                            Console.WriteLine($"{mover}: Y меньше Y цели. Идёт к цели. Y : { mover.Y }");
                        }
                    }

                    LastMove = DateTime.Now;
                }
            }
        }
    }
}
