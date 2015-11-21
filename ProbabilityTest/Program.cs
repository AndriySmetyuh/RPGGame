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

            Fight fight;
            Player user = new Player();

            List<Enemy> enemies = new List<Enemy>();

            for (int i = 0; i < 3; i++)
            {
                Enemy tr = new Troll();
                enemies.Add(tr);
            }

            foreach (var enemy in enemies)
            {
                fight = new Fight(user, enemy);
                MessageHelper.ShowMessage(string.Format("Oh, no! It's a {0}. You have to fight!", enemy.Name));
                var res = fight.MakeFight();

                if (res == user)
                {
                    user.GetNewLevel();
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
