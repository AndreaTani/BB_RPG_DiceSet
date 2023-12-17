using System.Security.Cryptography;

namespace BB_RPG_DiceSet
{
    /// <summary>
    /// Class <c>Die</c> models a generic game die, like a standard 6 sided die or a polyhedric die
    /// </summary>
    public class Die
    {
        private readonly int _sides;

        /// <summary>
        /// Constructor to create a game die with a positive it number of sides
        /// </summary>
        /// <param name="sides">number of sides</param>
        public Die(int sides)
        {
            if(sides < 1)
                throw new ArgumentOutOfRangeException(nameof(sides));

            _sides = sides;
        }

        /// <summary>
        /// Rolls the die
        /// </summary>
        /// <returns>an integer number between 1 and the number of sides of the die</returns>
        public int Roll()
        {
            return RandomNumberGenerator.GetInt32(1, _sides + 1);
        }
    }
}