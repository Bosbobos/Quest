using System;
using System.Collections.Generic;
using System.Text;

namespace Quests.Interfaces
{
    interface IBattleMagic
    {
        public void Hit(Character attacker, Body target);
    }
}
