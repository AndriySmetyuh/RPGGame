using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilityTest
{
    public class State
    {
        public StateType Type { get; set; }
        public int Probability { get; set; }

		//testcomment
        public override string ToString()
        {
            return Type.ToString();
        }
    }
}
