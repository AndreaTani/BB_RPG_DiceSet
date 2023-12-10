using System.Text.RegularExpressions;

namespace BB_RPG_DiceSet
{
    public class DiceSet
    {
        private const string REG_EX_PATTERN = @"(\d*)(d\d*)\+?(\d*)";
        private readonly string _description;
        private DiceResult _diceResult = new() { Base = 0, Bonus = 0 };
        private readonly Regex _regex = new(REG_EX_PATTERN);
        private readonly Match _match;

        public DiceSet(string description)
        {
            if (!_regex.IsMatch(description))
            {
                throw new ArgumentException();
            }

            _description = description;
            _match = _regex.Match(_description);
        }

        public int Roll()
        {
            var result = RollSeparate();
            return result.Total;
        }

        public DiceResult RollSeparate()
        {
            string numberOfDiceDefinition = _match.Groups[1].Value;
            string numberOfSidesDefinition = _match.Groups[2].Value;
            string bonusDefinition = _match.Groups[3].Value;

            int numberOfDice = numberOfDiceDefinition == string.Empty ? 1 : int.Parse(numberOfDiceDefinition);
            int numberOfSides = int.Parse(numberOfSidesDefinition[1..]);
            int bonus = bonusDefinition == string.Empty ? 0 : int.Parse(bonusDefinition);

            Die die = new(numberOfSides);

            for (int i = 0; i < numberOfDice; i++)
            {
                _diceResult.Base += die.Roll();
            }

            _diceResult.Bonus = bonus;

            return _diceResult;
        }
    }
}
