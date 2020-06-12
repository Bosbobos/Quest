using Quests.Bodies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Quests
{
    public class CycleManager
    {
        string mes { get; set; }

        List<Body> Bodies { get; set; }
        public CycleManager(List<Body> bodies)
        {
            Bodies = bodies;
        }
        
        public void AccomplishCycle()
        {
            while (true)
            {
                for (var i = 0; i < Bodies.Count; i++)
                {
                    var Accomplisher = Bodies[i];
                    Accomplisher.AccomplishTakt(Bodies);
                }

                Thread.Sleep(16);
            }
        }

        public void DeathEventHandler(Body body)
        {
            Bodies.Remove(body);

            if (body is Character)
                mes = "Персонаж";
            else if (body is Bot)
                mes = "Бот";
            else
                mes = "Тело";

            Console.WriteLine("");

            if (mes != "Тело")
                Console.WriteLine($"{mes} {body} Умер");
            else
                Console.WriteLine($"{mes} {body} Умерло");
        }
    }
}
