using System;
using System.Configuration;
using ProbabilityTest.Helpers;

namespace ProbabilityTest.Models
{
    /// <summary>
    /// class of player
    /// </summary>
    public class Player : Person
    {
        /// <summary>
        /// player's level
        /// </summary>
        public decimal Level { get; set; }
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
            Name = "Player";
            Bottles = Convert.ToInt32(ConfigurationManager.AppSettings["BottlesCount"]);
        }

        /// <summary>
        /// Simulating of drinling bottle
        /// </summary>
        /// <param name="bottleHealth">Health of bottle</param>
        /// <returns>Player's health after drinking bottle</returns>
        public decimal DrinkBottle(int bottleHealth)
        {
            Health += bottleHealth;
            Bottles--;
            MessageHelper.ShowMessage(string.Format("Your health now - {0}", Health));
            return Health;
        }

        /// <summary>
        /// User gets new level
        /// </summary>
        public void GetNewLevel()
        {
            Level++;
            Health += 5;
            Power += 4;
            Precise += 8;
            Bottles += 2;
            MessageHelper.ShowMessage(string.Format("You killed an enemy. You've got a level {0}", Level));
        }

        public override void Hit(Person opponent)
        {
            if (Bottles > 0)
            {
                MessageHelper.ShowMessage(string.Format("If you want to drink a bottle, press 1. You have {0} bottles", Bottles));
                if(Console.ReadLine() == "1")
                {
                    DrinkBottle(Convert.ToInt32(ConfigurationManager.AppSettings["BottleHealth"]));
                    return;
                }
            }

            base.Hit(opponent);
        }
    }
}
