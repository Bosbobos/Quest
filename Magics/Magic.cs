using System;
using System.Collections.Generic;
using System.Text;

namespace Quests.Magics
{
    public abstract class Magic
    {
        public TimeSpan Cooldown { get; set; }
        public DateTime LastMagicKast { get; set; }

        public static bool CanKast(DateTime LastKast, TimeSpan Cooldown)
        {
            if (LastKast + Cooldown < DateTime.Now)
                return true;
            else
                return false;
        }

        public abstract void DoSomething(Character character, Body body);
    }
}
