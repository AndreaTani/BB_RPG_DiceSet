namespace BB_RPG_DiceSet
{
    /// <summary>
    /// Struct <c>DiceResult</c> models the result from a dice set
    /// <para>Base</para> models the dice roll part from the dice set description
    /// <para>Bonus</para> models the bonus/penalty part from the dice set desctiption
    /// </summary>
    public struct DiceResult
    {
        public int Base;
        public int Bonus;

        /// <summary>
        /// Returns the sum of the dice roll part and the bonus/penalty part from the dice set
        /// </summary>
        public readonly int Total => Base + Bonus;
    }
}
