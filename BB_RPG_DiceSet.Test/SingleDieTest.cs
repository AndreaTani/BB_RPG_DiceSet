using Xunit;
using Xunit.Abstractions;

namespace BB_RPG_DiceSet.Test
{
    public class SingleDieTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public SingleDieTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(8)]
        [InlineData(10)]
        [InlineData(12)]
        [InlineData(20)]
        [InlineData(100)]
        public void GivenNewDie_WhenRoll_ThenResultBetwee_1andDieSides(int sides)
        {
            // Given
            var die = new Die(sides);

            // When
            var result = die.Roll();

            // Then
            Assert.InRange(result, 1, sides);
        }

        [Theory]
        [InlineData(4, 100000000, 0.25)]
        [InlineData(6, 100000000, 0.25)]
        [InlineData(8, 100000000, 0.25)]
        [InlineData(10, 100000000, 0.25)]
        [InlineData(12, 100000000, 0.25)]
        [InlineData(20, 100000000, 0.25)]
        [InlineData(100, 1000000000, 0.25)]
        public void GivenNewDie_WhenRollMultipleTimes_ThenResultDistributionUniform(int sides, int numberOfRolls, float tollerancePercentage)
        {
            // Given
            var die = new Die(sides);

            Dictionary<int, int> frequencies = new Dictionary<int, int>();

            for (int i = 1; i <= sides; i++)
            {
                frequencies[i] = 0;
            }

            // When
            for (int i = 0; i <= numberOfRolls; i++)
            {
                int result = die.Roll();
                frequencies[result]++;
            }

            float expectedFrequency = numberOfRolls / (float)sides;
            float tollerance = expectedFrequency * tollerancePercentage / 100;

            for (int i = 1; i <= sides; i++)
            {
                _testOutputHelper.WriteLine($"Result {i}, expected frequency: {expectedFrequency}, actual frequency: {frequencies[i]}, difference: {expectedFrequency - frequencies[i]}, tollerance: {tollerance}");
            }

            // Then
            foreach (var kvp in frequencies)
            {
                Assert.InRange(kvp.Value, expectedFrequency - tollerance, expectedFrequency + tollerance);
            }
        }
    }
}