using Day4Solver.Passport;
using FluentAssertions;
using Xunit;

namespace Day4SolverTests.Passport
{
    public class HeightTests
    {
        [Fact]
        public void IsValidForBonus_WhenCmAndNotInt_ThenFalse()
        {
            var subject = new Height("ecm");

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidForBonus_WhenCmAndIntAndLessThan150_ThenFalse()
        {
            var subject = new Height("149cm");

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidForBonus_WhenCmAndIntAnd150_ThenTrue()
        {
            var subject = new Height("150cm");

            var result = subject.IsValidForBonus();

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValidForBonus_WhenCmAndIntAnd193_ThenTrue()
        {
            var subject = new Height("193cm");

            var result = subject.IsValidForBonus();

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValidForBonus_WhenCmAndIntAndGreaterThan193_ThenFalse()
        {
            var subject = new Height("194cm");

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidForBonus_WhenInAndNotInt_ThenFalse()
        {
            var subject = new Height("ein");

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidForBonus_WhenInAndIntAndLessThan59_ThenFalse()
        {
            var subject = new Height("58in");

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidForBonus_WhenInAndIntAnd59_ThenTrue()
        {
            var subject = new Height("59in");

            var result = subject.IsValidForBonus();

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValidForBonus_WhenInAndIntAnd76_ThenTrue()
        {
            var subject = new Height("76in");

            var result = subject.IsValidForBonus();

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValidForBonus_WhenInAndIntAndGreaterThan76_ThenFalse()
        {
            var subject = new Height("77in");

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("160c")]
        [InlineData("160m")]
        [InlineData("65i")]
        [InlineData("65n")]
        [InlineData("149")]
        public void IsValidForBonus_WhenNeitherInNorCm_ThenFalse(string invalidInput)
        {
            var subject = new Height(invalidInput);

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }
    }
}
