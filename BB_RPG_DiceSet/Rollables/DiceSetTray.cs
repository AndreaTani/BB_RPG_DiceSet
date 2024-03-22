namespace BB_RPG_DiceSet
{
    public class DiceSetTray : List<IRollable>
    {
        private List<IRollable> _tray;

        /// <summary>
        /// Create an empty <c>DiceSetTray</c>
        /// </summary>
        public DiceSetTray()
        {
            _tray = new List<IRollable>();
        }

        /// <summary>
        /// Create a <c>DiceSetTray</c> from a single <c>IRollable</c> item
        /// </summary>
        /// <param name="item">A single <c>IRollable</c> item</param>
        public DiceSetTray(IRollable item)
        {
            _tray = new List<IRollable>
            {
                item
            };
        }

        /// <summary>
        /// Create a <c>DiceSetTray</c> from a list of <c>IRollable</c> items
        /// </summary>
        /// <param name="list">A List of IRollable items</param>
        public DiceSetTray(List<IRollable> list)
        {
            _tray = list;
        }

        /// <summary>
        /// Add a <c>IRollable</c> item to the <c>DiceSetTray</c>
        /// </summary>
        /// <param name="rollable">A single IRollable item</param>
        public new void Add(IRollable rollable)
        {
            _tray.Add(rollable);
        }

        /// <summary>
        /// Add a list of <c>IRollable</c> items to the <c>DiceSetTray</c>
        /// </summary>
        /// <param name="rollable">A list of IRollable item</param>
        public void AddRange(List<IRollable> list)
        {
            _tray.AddRange(list);
        }

        /// <summary>
        /// Roll the <c>DiceSetTray</c>
        /// </summary>
        /// <returns>An <see cref="int"/> containing the total result of the roll</returns>
        public int Roll()
        {
            var result = RollSeparate();
            return result.Total;
        }

        /// <summary>
        /// Roll the <c>DiceSetTray</c>
        /// </summary>
        /// <returns>A <see cref="DiceResult"/> struct containing the base result and the bonus/penalty result</returns>
        public DiceResult RollSeparate()
        {
            int diceRoll = 0;
            int bonusRoll = 0;

            var result = RollTray();

            foreach (var item in result)
            {
                diceRoll += item.Base;
                bonusRoll += item.Bonus;
            }

            return new DiceResult() { Base = diceRoll, Bonus = bonusRoll };
        }

        /// <summary>
        /// Roll the <c>DiceSetTray</c>
        /// </summary>
        /// <returns>A <see cref="List{T}"/> containing each dice-like object in the tray with their base and bonus/penalty results</returns>
        /// <remarks><see cref="T"/> is <see cref="DiceResult"/></remarks>
        public List<DiceResult> RollTray()
        {
            var result = new List<DiceResult>();

            foreach (var item in _tray)
            {
                var resultItem = item.RollSeparate();
                result.Add(resultItem);
            }

            return result;
        }

        public int Min()
        {
            return _tray.Sum(t => t.Min());
        }

        public int Max()
        {
            return _tray.Sum(t => t.Max());
        }
    }
}
