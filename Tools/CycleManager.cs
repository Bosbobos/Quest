using System;
using System.Collections.Generic;
using System.Text;

namespace Quests.Tools
{
    public static class CycleManager    
    {
        public static bool CanKast(DateTime LastKast, TimeSpan Cooldown)
        {
            if (LastKast + Cooldown < DateTime.Now)
                return true;
            else
                return false;
        }
    }
}
