using System.Security.Cryptography;

namespace BB_RPG_DiceSet
{
    public class Die
    {
        private readonly int _sides;

        public Die(int sides)
        {
            _sides = sides;
        }

        public int Roll()
        {
            return RandomNumberGenerator.GetInt32(1, _sides + 1);
        }
    }
}