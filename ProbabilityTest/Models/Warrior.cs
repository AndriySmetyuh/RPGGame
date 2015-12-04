using System;
using System.Configuration;

namespace ProbabilityTest.Models
{
    public class Warrior : Player
    {
        public Warrior()
        {
            Level = 1;
            Health = 60;
            Power = 30;
            Precise = 30;
            Name = "Warrior";
            Bottles = Convert.ToInt32(ConfigurationManager.AppSettings["BottlesCount"]);
        }
    }
}
