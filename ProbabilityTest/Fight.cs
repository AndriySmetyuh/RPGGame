using ProbabilityTest.Models;

namespace ProbabilityTest
{
    public class Fight
    {
        private readonly Person firstFighter;
        private readonly Person secondFighter;

        public Fight(Person first, Person second)
        {
            firstFighter = first;
            secondFighter = second;
        }

        public Person MakeFight()
        {
            bool firstHit = true;
            do
            {
                if(firstHit)
                {
                    firstFighter.Hit(secondFighter);
                }
                else
                {
                    secondFighter.Hit(firstFighter);
                }

                firstHit = !firstHit;

            } while (firstFighter.Health > 0 && secondFighter.Health > 0);

            return firstFighter.Health > 0 ? firstFighter : secondFighter;
        }
    }
}
