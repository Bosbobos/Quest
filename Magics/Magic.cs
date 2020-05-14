﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Quests.Magics
{
    public class Magic
    {
        public TimeSpan Cooldown { get; set; }
        public DateTime LastMagicKast { get; set; }
        public bool CanKast()
        {
            if (LastMagicKast + Cooldown < DateTime.Now)
                return true;
            else
                return false;
        }
    }
}
