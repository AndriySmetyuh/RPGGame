﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilityTest
{
    public class Player
    {
        public decimal Level { get; set; }
        public decimal Health { get; set; }
        public decimal Power { get; set; }
        public decimal Precise { get; set; }

        public Player()
        {
            Level = 1;
            Health = 80;
            Power = 20;
            Precise = 35;
        }

        public bool Fight(Enemy enemy)
        {
            bool push = true;
            Random rand = new Random();

            do
            {
                int res = rand.Next(1, 101);
                if (push)
                {
                    if (CalculatePrecise(enemy.Precise, res))
                    {
                        enemy.Health -= Power;
                        if (enemy.Health < 0) enemy.Health = 0;
                        Console.WriteLine("You made push for {0} damage - enemy's health now is {1}", Power,
                            enemy.Health);
                    }
                    else
                    {
                        Console.WriteLine("You made push for {0} damage - miss", Power);
                    }
                }
                else
                {
                    if (CalculatePrecise(Precise, res))
                    {
                        Health -= enemy.Power;
                        if (Health < 0) Health = 0;
                        Console.WriteLine("You got push for {0} damage - your health now is {1}", enemy.Power, Health);
                    }
                    else
                    {
                        Console.WriteLine("You got push for {0} damage - miss", Power);
                    }
                }
                push = ! push;

            } while (Health > 0 && enemy.Health > 0);
            return Health > 0;
        }

        public bool CalculatePrecise(decimal precise, int res)
        {
            return res <= precise;
        }
    }
}
