﻿namespace ProbabilityTest.Models
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
            Exp = 200;
            Name = "Troll";
        }
    }
}
