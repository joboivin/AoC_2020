using Day4Solver.Passport;
using FluentAssertions;
using Xunit;

namespace Day4SolverTests.Passport
{
    public class HairColorTests
    {
        [Fact]
        public void IsValidForBonus_WhenValidInput_ThenTrue()
        {
            var subject = new HairColor("#123abc");

            var result = subject.IsValidForBonus();

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("#123abz")]
        [InlineData("123abc")]
        [InlineData(" 123abc")]
        [InlineData("#123ab")]
        [InlineData("#123abcd")]
        public void IsValidForBonus_WhenInvalidInput_ThenFalse(string hairColor)
        {
            var subject = new HairColor(hairColor);

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }
    }
}
