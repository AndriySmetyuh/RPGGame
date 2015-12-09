using System;
using System.Configuration;

namespace ProbabilityTest.Models
{
    public class Elf : Player
    {
        public Elf()
        {
            Level = 1;
            Health = 85;
            Power = 15;
            Precise = 45;
            Name = "Elf";
            Bottles = Convert.ToInt32(ConfigurationManager.AppSettings["BottlesCount"]);
        }

        public override void GetNewLevel()
        {
            Health += 7;
            Power += 2;
            Precise += 4;
            Bottles += 2;
            base.GetNewLevel();
        }
    }
}
