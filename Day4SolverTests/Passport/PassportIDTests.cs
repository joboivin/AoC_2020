using Day4Solver.Passport;
using FluentAssertions;
using Xunit;

namespace Day4SolverTests.Passport
{
    public class PassportIDTests
    {
        [Fact]
        public void IsValidForBonus_When9Digits_ThenTrue()
        {
            var subject = new PassportID("012345678");

            var result = subject.IsValidForBonus();

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValidForBonus_When8Digits_ThenFalse()
        {
            var subject = new PassportID("01234567");

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidForBonus_When10Digits_ThenFalse()
        {
            var subject = new PassportID("0123456789");

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidForBonus_When9CharsButNotAllDigits_ThenFalse()
        {
            var subject = new PassportID("0123c5678");

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }
    }
}
