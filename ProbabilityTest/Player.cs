using System;
using System.Threading;

namespace ProbabilityTest
{
    /// <summary>
    /// class of player
    /// </summary>
    public class Player
    {
        /// <summary>
        /// player's level
        /// </summary>
        public decimal Level { get; set; }
        /// <summary>
        /// player's health
        /// </summary>
        public decimal Health { get; set; }
        /// <summary>
        /// player's power
        /// </summary>
        public decimal Power { get; set; }
        /// <summary>
        /// player's precise
        /// </summary>
        public decimal Precise { get; set; }

        /// <summary>
        /// constructor of player
        /// </summary>
        public Player()
        {
            Level = 1;
            Health = 80;
            Power = 20;
            Precise = 35;
        }

        public bool Fight(Enemy enemy)
        {
            bool push = true;
            Random rand = new Random();

            do
            {
                int res = rand.Next(1, 101);

                Console.WriteLine(push ? "You hit..." : "Enemy hits...");
                Thread.Sleep(1500);

                var prec = push ? Precise : enemy.Precise;

                if (!CalculatePrecise(prec, res))
                {
                    Console.WriteLine("Miss");
                }
                else
                {
                    if (push)
                    {
                        enemy.Health -= Power;
                        if (enemy.Health < 0) enemy.Health = 0;
                        Console.WriteLine("You made push for {0} damage - enemy's health now is {1}", Power,
                            enemy.Health);
                    }
                    else
                    {
                        Health -= enemy.Power;
                        if (Health < 0) Health = 0;
                        Console.WriteLine("You got push for {0} damage - your health now is {1}", enemy.Power, Health);
                    }
                }
                push = ! push;

            } while (Health > 0 && enemy.Health > 0);
            return Health > 0;
        }

        public bool CalculatePrecise(decimal precise, int res)
        {
            return res <= precise;
        }
    }
}
