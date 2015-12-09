using System;
using System.Configuration;

namespace ProbabilityTest.Models
{
    public class Bowman : Player
    {
        public Bowman()
        {
            Level = 1;
            Health = 50;
            Power = 10;
            Precise = 70;
            Name = "Bowman";
            Bottles = Convert.ToInt32(ConfigurationManager.AppSettings["BottlesCount"]);
        }

        public override void GetNewLevel()
        {
            Health += 5;
            Power += 3;
            Precise += 8;
            Bottles += 2;
            base.GetNewLevel();
        }
    }
}
