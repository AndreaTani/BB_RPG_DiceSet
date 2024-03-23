namespace BB_RPG_DiceSet
{
    /// <summary>
    /// Implement this interface if you want to create ways to modify a Roll and specific game mechanics like:
    /// AdvantageModifier
    /// DisadvantageModifier
    /// CharacterTraitModifier
    /// etc...
    /// </summary>
    public interface IModifier
    {
        /// <summary>
        /// Modify the result of the <see cref="IRollable"/> object
        /// depends on your implementation
        /// </summary>
        /// <param name="rollableObject">The <see cref="IRollable"/> object whose <see cref="IRollable.Roll"/> has to be modified</param>
        /// <returns>An <see cref="int"/> that is the modified <see cref="IRollable.Roll"/> of the <see cref="IRollable"/> object</returns>
        int Modify(IRollable rollableObject);
    }
}
