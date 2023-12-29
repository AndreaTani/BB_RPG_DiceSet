using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB_RPG_DiceSet
{
    public class Bonus : IRollable
    {
        private readonly int _bonusValue;
        private DiceResult _diceResult;
        private string _label;

        /// <summary>
        /// Create a bonus with a positive <see cref="int"/> or Zero value
        /// </summary>
        /// <param name="bonusValue"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Bonus(int bonusValue)
        {
            if (bonusValue < 0)
                throw new ArgumentOutOfRangeException(nameof(bonusValue));

            _bonusValue = bonusValue;
            _label = string.Empty;
    }

        public int Roll()
        {
            return _bonusValue;
        }

        public DiceResult RollSeparate()
        {
            _diceResult.Base = 0;
            _diceResult.Bonus = Roll();

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
