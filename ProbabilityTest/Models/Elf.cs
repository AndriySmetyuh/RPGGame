using System;
using System.Configuration;

namespace ProbabilityTest.Models
{
    public class Elf : Player
    {
        public Elf()
        {
            Health = 85;
            Power = 15;
            Precise = 45;
            Name = "Elf";
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
