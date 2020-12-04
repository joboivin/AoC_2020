using Day4Solver.Passport;
using FluentAssertions;
using Xunit;

namespace Day4SolverTests.Passport
{
    public class BirthYearTests
    {
        [Fact]
        public void IsValidForBonus_WhenBirthYearHasLessThan4Digits_ThenFalse()
        {
            var subject = new BirthYear("123");

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidForBonus_WhenBirthYearHasGreaterThan4Digits_ThenFalse()
        {
            var subject = new BirthYear("12345");

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidForBonus_WhenBirthYearHas4DigitsAndYearLessThan1920_ThenFalse()
        {
            var subject = new BirthYear("1919");

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidForBonus_WhenBirthYearHas4DigitsAndYear1920_ThenTrue()
        {
            var subject = new BirthYear("1920");

            var result = subject.IsValidForBonus();

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValidForBonus_WhenBirthYearHas4DigitsAndYear2002_ThenTrue()
        {
            var subject = new BirthYear("2002");

            var result = subject.IsValidForBonus();

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValidForBonus_WhenBirthYearHas4DigitsAndYearGreaterThan2002_ThenFalse()
        {
            var subject = new BirthYear("2003");

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }
    }
}
