
namespace ProbabilityTest.Models
{
    /// <summary>
    /// Goblin enemy
    /// </summary>
    public class Goblin : Enemy
    {
        /// <summary>
        /// Constructor of goblin
        /// </summary>
        public Goblin()
        {
            Health = 70;
            Power = 17;
            Precise = 20;
            Exp = 150;
            Name = "Goblin";
        }
    }
}
