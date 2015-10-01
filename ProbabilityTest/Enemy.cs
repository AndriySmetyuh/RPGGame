using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilityTest
{
    /// <summary>
    /// Class Enemy 
    /// </summary>
    public class Enemy
    {
        /// <summary>
        /// enemy's health
        /// </summary>
        public decimal Health { get; set; }
        /// <summary>
        /// enemy's power
        /// </summary>
        public decimal Power { get; set; }
        /// <summary>
        /// enemy's precise
        /// </summary>
        public decimal Precise { get; set; }

        /// <summary>
        /// Constructor of Enemy class
        /// </summary>
        public Enemy()
        {
            Health = 47;
            Power = 6;
            Precise = 49;
        }
    }
}
