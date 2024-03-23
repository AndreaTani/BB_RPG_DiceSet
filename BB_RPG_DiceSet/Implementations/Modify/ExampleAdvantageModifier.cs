namespace BB_RPG_DiceSet
{
    /// <summary>
    /// This is a simple example on how a modifier can be created.
    /// In some TTRPG the Advantage mechanics is tied to a specific kind of die (the D20 usually)
    /// So you can add some validation and control in your modifier if required
    /// </summary>
    public class ExampleAdvantageModifier : IModifier
    {
        public int Modify(IRollable rollableObject)
        {
            int result1 = rollableObject.Roll();
            int result2 = rollableObject.Roll();

            return Math.Max(result1, result2);
        }
    }
}
