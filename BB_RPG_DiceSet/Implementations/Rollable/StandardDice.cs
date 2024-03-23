namespace BB_RPG_DiceSet
{
    /// <summary>
    /// Standard four sided die
    /// </summary>
    public class D4 : Die
    {
        public D4() : base(4) { }
    }

    /// <summary>
    /// Standard six sided die
    /// </summary>
    public class D6 : Die
    {
        public D6() : base(6) { }
    }

    /// <summary>
    /// Standard eight sided die
    /// </summary>
    public class D8 : Die
    {
        public D8() : base(8) { }
    }

    /// <summary>
    /// Standard ten sided die
    /// </summary>
    public class D10 : Die
    {
        public D10() : base(10) { }
    }

    /// <summary>
    /// Standard twelve sided die
    /// </summary>
    public class D12 : Die
    {
        public D12() : base(12) { }
    }

    /// <summary>
    /// Standard twentysided die
    /// </summary>
    public class D20 : Die
    {
        public D20() : base(20) { }
    }

    /// <summary>
    /// Standard one hundred sided (aka percentile) die
    /// </summary>
    public class D100 : Die
    {
        public D100() : base(100) { }
    }
}
