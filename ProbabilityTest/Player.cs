using System;
using System.Configuration;
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
        /// bottles count
        /// </summary>
        public decimal Bottles { get; set; }

        /// <summary>
        /// constructor of player
        /// </summary>
        public Player()
        {
            Level = 1;
            Health = 80;
            Power = 20;
            Precise = 35;
            Bottles = Convert.ToInt32(ConfigurationManager.AppSettings["BottlesCount"]);
        }

        public bool Fight(Enemy enemy)
        {
            bool push = false;
            var rand = new Random();

            int bottleHealth = Convert.ToInt32(ConfigurationManager.AppSettings["BottleHealth"]);

            do
            {
                push = !push;
                if (push && Bottles > 0)
                {
                    Console.WriteLine("Do you want to drink bottle(+ {0} health)? You have {1} bottles. Press 1 if yes.", bottleHealth, Bottles);
                    var desicion = Console.ReadLine();

                    if (desicion == "1")
                    {
                        Console.WriteLine("Your health now is {0}", DrinkBottle(bottleHealth));
                        Bottles--;
                        continue;
                    }
                }

                int res = rand.Next(1, 101);

                Console.WriteLine(push ? "You hit..." : "Enemy hits...");
                Thread.Sleep(1500);

                var prec = push ? Precise : enemy.Precise;
                var pow = push ? Power : enemy.Power;

                var damage = (int) (pow*(res + 1 - prec)/(101 - prec));

                if (!CalculatePrecise(prec, res))
                {
                    Console.WriteLine("Miss");
                }
                else
                {
                    if (push)
                    {
                        enemy.Health -= damage;
                        if (enemy.Health < 0) enemy.Health = 0;
                        Console.WriteLine("You made push for {0} damage - enemy's health now is {1}", Power,
                            enemy.Health);
                    }
                    else
                    {
                        Health -= damage;
                        if (Health < 0) Health = 0;
                        Console.WriteLine("You got push for {0} damage - your health now is {1}", enemy.Power, Health);
                    }
                }

            } while (Health > 0 && enemy.Health > 0);
            return Health > 0;
        }

        /// <summary>
        /// Calculate if event happenes
        /// </summary>
        /// <param name="precise">Probability of happening event</param>
        /// <param name="res">Result of random</param>
        /// <returns>If event occurs</returns>
        public bool CalculatePrecise(decimal precise, int res)
        {
            return precise <= res;
        }

        /// <summary>
        /// Simulating of drinling bottle
        /// </summary>
        /// <param name="bottleHealth">Health of bottle</param>
        /// <returns>Player's health after drinking bottle</returns>
        public decimal DrinkBottle(int bottleHealth)
        {
            Health += bottleHealth;
            return Health;
        }

        /// <summary>
        /// User gets new level
        /// </summary>
        public void GetNewLevel()
        {
            Level++;
            Health += 5;
            Precise += 8;
            Bottles += 2;
        }
    }
}
