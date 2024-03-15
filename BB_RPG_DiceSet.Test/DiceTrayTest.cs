namespace BB_RPG_DiceSet.Test
{
    public class DiceTrayTest
    {
        [Theory]
        [InlineData(typeof(Die), 4, typeof(Bonus), 2, 3, 6)]  // Expected Min and Max are the last two arguments
        [InlineData(typeof(DiceSet), "2d6", typeof(Bonus), -3, -1, 9)]  // Expected Min and Max are the last two arguments
        [InlineData(typeof(Die), 4, typeof(DiceSet), "2d6", typeof(Bonus), -3, 0, 13)]  // Expected Min and Max are the last two arguments
        public void Test_GetMinRoll_AndGetMaxRoll_ForRollableCollection(params object[] rollableData)
        {
            // Arrange
            List<IRollable> rollables = CreateRollableCollectionFromInlineData(rollableData);

            // Get expected values directly from the last two arguments (assuming they are int)
            int expectedMin = (int)rollableData[rollableData.Length - 2];
            int expectedMax = (int)rollableData[rollableData.Length - 1];

            // Act
            int minRoll = rollables.Sum(r => r.Min());
            int maxRoll = rollables.Sum(r => r.Max());

            // Assert
            Assert.Equal(expectedMin, minRoll);
            Assert.Equal(expectedMax, maxRoll);
        }

        private List<IRollable> CreateRollableCollectionFromInlineData(object[] rollableData)
        {
            List<IRollable> rollables = new List<IRollable>();
            foreach (object data in rollableData)
            {
                if (data is Type type)
                {
                    if (type == typeof(Die))
                    {
                        int sides = (int)rollableData[Array.IndexOf(rollableData, type) + 1];
                        rollables.Add(new Die(sides));
                    }
                    else if (type == typeof(DiceSet))
                    {
                        string description = (string)rollableData[Array.IndexOf(rollableData, type) + 1];
                        rollables.Add(new DiceSet(description));
                    }
                    else if (type == typeof(Bonus))
                    {
                        int bonusValue = (int)rollableData[Array.IndexOf(rollableData, type) + 1];
                        rollables.Add(new Bonus(bonusValue));
                    }
                }
            }
            return rollables;
        }
    }
}