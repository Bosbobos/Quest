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
        /// <summary> выполнить такт </summary>
        /// <param name="bodies"></param>
        /// <exception cref="NullReferenceException"> нельзя чтобы bodies был null </exception>
        public void AccomplishTakt(List<Body> bodies);
    }
}
