using System;
using System.Collections.Generic;
using System.Linq;

namespace ProbabilityTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Player user = new Player();
            Enemy tr = new Troll();
            bool res = user.Fight(tr);

            Console.WriteLine("{0}", res ? "Congratulations!!! YOU WIN!!" : "You are dead");

            /*List<State> states = new List<State>();
            State first = new State
            {
                Probability = 30,
                Type = StateType.State1
            };
            State second = new State
            {
                Probability = 45,
                Type = StateType.State2
            };
            State third = new State
            {
                Probability = 10,
                Type = StateType.State3
            };
            State fourth = new State
            {
                Probability = 11,
                Type = StateType.State4
            };
            State fifth = new State
            {
                Probability = 4,
                Type = StateType.State5
            };
            states.Add(first);
            states.Add(second);
            states.Add(third);
            states.Add(fourth);
            states.Add(fifth);

            Random rand = new Random();
            for (int i = 0; i < 200; i++)
            {
                int result = rand.Next(1, 101);

                State st = GetState(states, result);

                Console.WriteLine("Number - {0}, state - {1}", result, st);
            }*/
        }

        static State GetState(List<State> allStates, int result)
        {
            if (allStates.Any(s => s.Probability < 0))
                throw new ArgumentException("Probability less 0");

            if (allStates.Sum(s => s.Probability) != 100)
                throw new ArgumentException("Probability sum does't equal 100%");

            if (result <= 0 || result > 100)
                throw new ArgumentException("Random problem");

            int fullProbability = 0;

            foreach (var allState in allStates)
            {
                if (result <= fullProbability + allState.Probability)
                {
                    return allState;
                }
                fullProbability += allState.Probability;
            }

            return null;
        }
    }
}
