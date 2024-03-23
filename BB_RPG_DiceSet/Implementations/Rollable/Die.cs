using System.Security.Cryptography;

namespace BB_RPG_DiceSet
{
    /// <summary>
    /// Models a generic game die, like a standard 6 sided die or a polyhedric die. Implements the <see cref="IRollable"/> interface
    /// </summary>
    public class Die : IRollable
    {
        private readonly int _sides;
        private DiceResult _diceResult;
        private string _label;

        /// <summary>
        /// Create a game die with a positive <see cref="int"/> number of sides
        /// </summary>
        /// <param name="sides">number of sides</param>
        public Die(int sides)
        {
            if (sides < 1)
                throw new ArgumentOutOfRangeException(nameof(sides));

            _sides = sides;
            _label = $"D{sides}";
        }

        public int Roll()
        {
            return RandomNumberGenerator.GetInt32(1, _sides + 1);
        }

        public DiceResult RollSeparate()
        {
            _diceResult.Base = Roll();
            _diceResult.Bonus = 0;

            return _diceResult;
        }

        public string GetLabel()
        {
            return _label;
        }

        public void SetLabel(string label)
        {
            _label = label;
        }

        public int Max()
        {
            return _sides;
        }

        public int Min()
        {
            return 1;
        }
    }
}