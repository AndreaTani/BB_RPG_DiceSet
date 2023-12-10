using FluentAssertions;

namespace BB_RPG_DiceSet.Test
{
    public class DiceSetTest
    {
        [Theory]
        [InlineData("abrasferw")]
        [InlineData("10+5")]
        public void GivenDiceSet_WhenDefinitionNotMatch_ThenThrowArgumentExceptionInConstructor(string definition)
        {
            Action a = () => new DiceSet(definition);

            a.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("d20", 1, 20)]
        [InlineData("2d4+2", 4, 10)]
        [InlineData("8d6", 8, 48)]
        public void GivenDiceSet_WhenDefinitonIsValid_ThenReturnResultInRange(string definition, int min, int max)
        {
            // Given
            var diceSet = new DiceSet(definition);

            // When
            int result = diceSet.Roll();

            // Then
            result.Should().BeInRange(min, max);
        }
    }
}
