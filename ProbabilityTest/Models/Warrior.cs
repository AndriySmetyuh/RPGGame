using System;
using System.Configuration;

namespace ProbabilityTest.Models
{
    public class Warrior : Player
    {
        public Warrior()
        {
            Health = 60;
            Power = 30;
            Precise = 30;
            Name = "Warrior";
        }

        public override void GetNewLevel()
        {
            Health += 3;
            Power += 6;
            Precise += 5;
            Bottles += 2;
            base.GetNewLevel();
        }
    }
}
