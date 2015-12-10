using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilityTest.Helpers
{
    public class LevelExperience
    {
        private Dictionary<uint, uint> Experience { get; set; }

        public LevelExperience()
        {
            Experience = new Dictionary<uint, uint>()
            {
                {2, 200},
                {3, 500},
                {4, 900},
                {5, 1400},
                {6, 2000},
                {7, 2700},
                {8, 3500},
                {9, 4400},
                {10, 5400},
            };
        }

        public bool GotLevel(uint currentLevel, uint exp)
        {
            return Experience[currentLevel + 1] < exp;
        }
    }
}
