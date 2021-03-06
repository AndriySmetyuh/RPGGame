﻿using System;
using System.Collections.Generic;
using log4net;
using ProbabilityTest.Helpers;
using ProbabilityTest.Models;

namespace ProbabilityTest
{
    class Program
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static void Main(string[] args)
        {
            log.Debug("This is a debug message");
            log.Warn("This is a warn message");
            log.Error("This is a error message");
            log.Fatal("This is a fatal message");

            Player user = null;
            bool valid = false;

            LevelExperience exp = new LevelExperience();

            do
            {
                MessageHelper.ShowMessage("Choose your player: 1 - elf; 2 - warrior; 3 - bowman");
                string res = Console.ReadLine();

                switch (res)
                {
                    case "1":
                    {
                        user = new Elf();
                        valid = true;
                        break;
                    }
                    case "2":
                    {
                        user = new Warrior();
                        valid = true;
                        break;
                    }
                    case "3":
                    {
                        user = new Bowman();
                        valid = true;
                        break;
                    }
                }

            } while (!valid);

            Fight fight;

            List<Enemy> enemies = new List<Enemy>();

            for (int i = 0; i < 3; i++)
            {
                Enemy tr = new Troll();
                enemies.Add(tr);
            } 
            
            for (int i = 0; i < 3; i++)
            {
                Enemy tr = new Goblin();
                enemies.Add(tr);
            }

            foreach (var enemy in enemies)
            {
                fight = new Fight(user, enemy);
                MessageHelper.ShowMessage(string.Format("Oh, no! It's a {0}. You have to fight!", enemy.Name));
                var res = fight.MakeFight();

                if (res == user)
                {
                    user.Exp += enemy.Exp;

                    if (exp.GotLevel(user.Level, user.Exp))
                    {
                        user.GetNewLevel();
                    }
                }
                else
                {
                    MessageHelper.ShowMessage("You are dead. Game over.");
                    return;
                }
            }

            MessageHelper.ShowMessage("Congratulations!!! YOU WIN!!!");
        }
    }
}
