using System;
using System.Collections.Generic;
using System.Text;

namespace Quests
{
    /// <summary>
    /// Значит, что реализующий этот интрефейс делает что-либо каждый ход
    /// </summary>
    interface IAccoplishTakt
    {
        public void AccomplishTakt(List<Body> bodies);
    }
}
