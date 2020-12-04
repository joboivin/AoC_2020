using Day4Solver.Passport;
using FluentAssertions;
using Xunit;

namespace Day4SolverTests.Passport
{
    public class ExpirationYearTests
    {
        [Fact]
        public void IsValidForBonus_WhenExpirationYearHasLessThan4Digits_ThenFalse()
        {
            var subject = new ExpirationYear("123");

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidForBonus_WhenExpirationYearHasGreaterThan4Digits_ThenFalse()
        {
            var subject = new ExpirationYear("12345");

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidForBonus_WhenExpirationYearHas4DigitsAndYearLessThan2020_ThenFalse()
        {
            var subject = new ExpirationYear("2019");

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidForBonus_WhenExpirationYearHas4DigitsAndYear2020_ThenTrue()
        {
            var subject = new ExpirationYear("2020");

            var result = subject.IsValidForBonus();

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValidForBonus_WhenExpirationYearHas4DigitsAndYear2030_ThenTrue()
        {
            var subject = new ExpirationYear("2030");

            var result = subject.IsValidForBonus();

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValidForBonus_WhenExpirationYearHas4DigitsAndYearGreaterThan2030_ThenFalse()
        {
            var subject = new ExpirationYear("2031");

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }
    }
}
