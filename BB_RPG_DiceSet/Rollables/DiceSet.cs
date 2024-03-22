using System.Text.RegularExpressions;

namespace BB_RPG_DiceSet
{
    /// <summary>
    /// Class <c>DiceSet</c> models a set of uniform dice plus a bonus/penalty as defined in several RPG Games with a string description like "2d4+2" or "8d6"
    /// </summary>
    public class DiceSet : IRollable
    {
        private const string REG_EX_PATTERN = @"(\d*)(d\d*)(\+?\-?\d*)?";
        private readonly Regex _regex = new(REG_EX_PATTERN);
        private readonly Match _match;
        private readonly string _description;
        private DiceResult _diceResult = new() { Base = 0, Bonus = 0 };
        private string _label;

        private readonly string _numberOfDiceDefinition;
        private readonly string _numberOfSidesDefinition;
        private readonly string _bonusDefinition;
        private readonly int _numberOfDice;
        private readonly int _numberOfSides;
        private readonly int _bonus;

        private readonly int _min;
        private readonly int _max;

        /// <summary>
        /// Create a set of uniform dice plus a bonus/penalty
        /// </summary>
        /// <param name="description">Must be a string in the classic form like NdT+B where N: Number of dice, T: Type of dice, B: bonus/penalty</param>
        /// <exception cref="ArgumentException"></exception>
        public DiceSet(string description)
        {
            if (!_regex.IsMatch(description))
            {
                throw new ArgumentException();
            }

            _description = description;
            _match = _regex.Match(_description);
            _label = description;

            _numberOfDiceDefinition = _match.Groups[1].Value;
            _numberOfSidesDefinition = _match.Groups[2].Value;
            _bonusDefinition = _match.Groups[3].Value;

            _numberOfDice = _numberOfDiceDefinition == string.Empty ? 1 : int.Parse(_numberOfDiceDefinition);
            _numberOfSides = int.Parse(_numberOfSidesDefinition[1..]);
            _bonus = _bonusDefinition == string.Empty ? 0 : int.Parse(_bonusDefinition);

            _min = _numberOfDice + _bonus;
            _max = (_numberOfDice * _numberOfSides) + _bonus;
        }

        public int Roll()
        {
            var result = RollSeparate();
            return result.Total;
        }

        public DiceResult RollSeparate()
        {

            Die die = new(_numberOfSides);

            for (int i = 0; i < _numberOfDice; i++)
            {
                _diceResult.Base += die.Roll();
            }

            _diceResult.Bonus = _bonus;

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
            return _max;
        }

        public int Min()
        {
            return _min;
        }
    }
}
