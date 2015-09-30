using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilityTest
{
    public class Enemy
    {
        public decimal Health { get; set; }
        public decimal Power { get; set; }
        public decimal Precise { get; set; }

        public Enemy()
        {
            Health = 47;
            Power = 6;
            Precise = 49;
        }
    }
}
