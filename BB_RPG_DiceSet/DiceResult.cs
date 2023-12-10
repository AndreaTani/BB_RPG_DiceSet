namespace BB_RPG_DiceSet
{
    public struct DiceResult
    {
        public int Base;
        public int Bonus;

        public int Total
        {
            get { return Base + Bonus; }
        }
    }
}
