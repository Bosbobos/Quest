﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Quests.Tools
{
    public static class Statistics
    {
        public static int TotalMeleeHits { get; set; }
        public static int TotalRangedHits { get; set; }
        public static int TotalHits { get; set; } 
        public static decimal TotalDamage { get; set; }
    }
}
