namespace BB_RPG_DiceSet
{
    /// <summary>
    /// Implement this interface if you want to create ways to modify a Roll and specific game mechanics like:
    /// AdvantageModifier
    /// DisadvantageModifier
    /// etc...
    /// </summary>
    public interface IModifier
    {
        int Modify(IRollable rollableObject);
    }
}
