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
            bool push = false;
            Random rand = new Random();

            int bottleHealth = Convert.ToInt32(ConfigurationManager.AppSettings["BottleHealth"]);
            int bottlesCount = Convert.ToInt32(ConfigurationManager.AppSettings["BottlesCount"]);

            do
            {
                push = !push;
                if (push && bottlesCount > 0)
                {
                    Console.WriteLine("Do you want to drink bottle(+ {0} health)? You have {1} bottles. Press 1 if yes.", bottleHealth, bottlesCount);
                    var desicion = Console.ReadLine();

                    if (desicion == "1")
                    {
                        Console.WriteLine("Your health now is {0}", DrinkBottle(bottleHealth));
                        bottlesCount--;
                        continue;
                    }
                }

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

            } while (Health > 0 && enemy.Health > 0);
            return Health > 0;
        }

        public bool CalculatePrecise(decimal precise, int res)
        {
            return res <= precise;
        }

        public decimal DrinkBottle(int bottleHealth)
        {
            Health += bottleHealth;
            return Health;
        }
    }
}
