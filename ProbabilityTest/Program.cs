using System;
using System.Collections.Generic;
using log4net;

namespace ProbabilityTest
{
    class Program
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static void Main(string[] args)
        {
            /*log.Debug("This is a debug message");
            log.Warn("This is a warn message");
            log.Error("This is a error message");
            log.Fatal("This is a fatal message");*/

            Player user = new Player();

            List<Enemy> enemies = new List<Enemy>();

            for (int i = 0; i < 3; i++)
            {
                Enemy tr = new Troll();
                enemies.Add(tr);

            }

            foreach (var enemy in enemies)
            {
                bool res = user.Fight(enemy);

                if (res)
                {
                    user.GetNewLevel();
                }
                else
                {
                    Console.WriteLine("You are dead. Game over.");
                    return;
                }
            }

            Console.WriteLine("Congratulations!!! YOU WIN!!");
        }
    }
}
