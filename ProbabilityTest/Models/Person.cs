using System;
using System.Threading;
using ProbabilityTest.Helpers;

namespace ProbabilityTest.Models
{
    public class Person
    {
        public decimal Health { get; set; }
        public uint Power { get; set; }
        public string Name { get; set; }

        public uint Precise
        {
            get { return _mPrecise; }
            set { _mPrecise = value > 100 ? 100 : value; }
        }

        private uint _mPrecise;

        /// <summary>
        /// Simulate one hit to opponent
        /// </summary>
        /// <param name="opponent">your enemy</param>
        public virtual void Hit(Person opponent)
        {
            var rand = new Random();
            int res = rand.Next(1, 101);

            var damage = (decimal)Math.Ceiling((double)(Power - Power * (res - 1) / (Precise + 1)));

            MessageHelper.ShowMessage(string.Format("{0} hits...", Name));
            Thread.Sleep(1500);
            if (!CalculatePrecise(Precise, res))
            {
                MessageHelper.ShowMessage("Miss");
            }
            else
            {
                opponent.Health -= damage;
                if (opponent.Health < 0)
                {
                    damage += opponent.Health;
                    opponent.Health = 0;
                }
                MessageHelper.ShowMessage(string.Format("{0} makes push for {1} damage - {2}'s health now is {3}", Name, damage, opponent.Name, opponent.Health));
            }
            Thread.Sleep(1500);
        }

        /// <summary>
        /// Calculate if event happenes
        /// </summary>
        /// <param name="precise">Probability of happening event</param>
        /// <param name="res">Result of random</param>
        /// <returns>If event occurs</returns>
        public bool CalculatePrecise(uint precise, int res)
        {
            return res <= precise;
        }
    }
}
