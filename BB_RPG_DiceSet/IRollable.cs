namespace BB_RPG_DiceSet
{
    /// <summary>
    /// Define a dice-like Object that can be Rolled
    /// </summary>
    public interface IRollable
    {
        /// <summary>
        /// Roll the dice-like object
        /// </summary>
        /// <returns>An <see cref="int"/> containing the total result of the roll</returns>
        public int Roll();

        /// <summary>
        /// Roll the dice-like object
        /// </summary>
        /// <returns>A <see cref="DiceResult"/> struct containing the base result and the bonus result</returns>
        public DiceResult RollSeparate();

        /// <summary>
        /// Gets the label of the dice-like object
        /// </summary>
        /// <returns>A <see cref="string"/> containg the label of the dice-like object. Can be used to identify the kind of dice-like object used, for what purpose or the damage type for caertain RPG systems</returns>
        public string GetLabel();

        /// <summary>
        /// Sets the label of the dice-like object
        /// </summary>
        /// <param name="label">The new label to be set for the dice-like object</param>
        public void SetLabel(string label);
    }
}
