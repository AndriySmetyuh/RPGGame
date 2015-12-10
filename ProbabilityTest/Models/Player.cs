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
        public uint Level { get; set; }
        /// <summary>
        /// bottles count
        /// </summary>
        public uint Bottles { get; set; }
        /// <summary>
        /// experience count
        /// </summary>
        public uint Exp { get; set; }

        /// <summary>
        /// constructor of player
        /// </summary>
        public Player()
        {
            Level = 1;
            Exp = 0;
            Bottles = Convert.ToUInt32(ConfigurationManager.AppSettings["BottlesCount"]);
        }

        /// <summary>
        /// Simulating of drinling bottle
        /// </summary>
        /// <param name="bottleHealth">Health of bottle</param>
        /// <returns>Player's health after drinking bottle</returns>
        public decimal DrinkBottle(uint bottleHealth)
        {
            Health += bottleHealth;
            Bottles--;
            MessageHelper.ShowMessage(string.Format("Your health now - {0}", Health));
            return Health;
        }

        /// <summary>
        /// User gets new level
        /// </summary>
        public virtual void GetNewLevel()
        {
            Level++;
            MessageHelper.ShowMessage(string.Format("You killed an enemy. You've got a level {0}", Level));
        }

        /// <summary>
        /// Simulate one hit to opponent
        /// </summary>
        /// <param name="opponent">your enemy</param>
        public override void Hit(Person opponent)
        {
            if (Bottles > 0)
            {
                MessageHelper.ShowMessage(string.Format("If you want to drink a bottle, press 1. You have {0} bottle{1}", Bottles, Bottles > 1 ? "s" : ""));
                if(Console.ReadLine() == "1")
                {
                    DrinkBottle(Convert.ToUInt32(ConfigurationManager.AppSettings["BottleHealth"]));
                    return;
                }
            }

            base.Hit(opponent);
        }
    }
}
