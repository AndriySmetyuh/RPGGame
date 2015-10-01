using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilityTest
{
    /// <summary>
    /// Troll enemy
    /// </summary>
    public class Troll : Enemy
    {
        /// <summary>
        /// Constructor of troll
        /// </summary>
        public Troll()
        {
            Health = 50;
            Power = 14;
            Precise = 28;
        }
    }
}
