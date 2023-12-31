﻿using System.Text.RegularExpressions;

namespace BB_RPG_DiceSet
{
    /// <summary>
    /// Class <c>DiceSet</c> models a set of uniform dice plus a bonus as defined in several RPG Games with a string description like "2d4+2" or "8d6"
    /// </summary>
    public class DiceSet : IRollable
    {
        private const string REG_EX_PATTERN = @"(\d*)(d\d*)\+?(\d*)";
        private readonly Regex _regex = new(REG_EX_PATTERN);
        private readonly Match _match;
        private readonly string _description;
        private DiceResult _diceResult = new() { Base = 0, Bonus = 0 };
        private string _label;

        /// <summary>
        /// Create a set of uniform dice plus a bonus
        /// </summary>
        /// <param name="description">Must be a string in the classic form like NdT+B where N: Number of dice, T: Type of dice, B: bonus</param>
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

        public string GetLabel()
        {
            return _label;
        }

        public void SetLabel(string label)
        {
            _label = label;
        }
    }
}
