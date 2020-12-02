using Day2Solver;
using FluentAssertions;
using Xunit;

namespace Day2SolverTests
{
    public class PasswordEntryTests
    {
        [Fact]
        public void IsValid_WhenMandatoryCharNotInPassword_ThenFalse()
        {
            var subject = new PasswordEntry { MinOccurence = 2, MaxOccurence = 4, MandatoryChar = 'c', Password = "abdefg" };

            var result = subject.IsValid;

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenMandatoryCharIsPresentLessThanMinimumOccurence_ThenFalse()
        {
            var subject = new PasswordEntry { MinOccurence = 2, MaxOccurence = 4, MandatoryChar = 'c', Password = "acbdefg" };

            var result = subject.IsValid;

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenMandatoryCharIsPresentExactlyMinimumOccurence_ThenTrue()
        {
            var subject = new PasswordEntry { MinOccurence = 2, MaxOccurence = 4, MandatoryChar = 'c', Password = "acbdefcg" };

            var result = subject.IsValid;

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_WhenMandatoryCharIsPresentBewteenMinimumAndMaximumOccurence_ThenTrue()
        {
            var subject = new PasswordEntry { MinOccurence = 2, MaxOccurence = 4, MandatoryChar = 'c', Password = "acbdefcgc" };

            var result = subject.IsValid;

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_WhenMandatoryCharIsPresentExactlyMaximumOccurence_ThenTrue()
        {
            var subject = new PasswordEntry { MinOccurence = 2, MaxOccurence = 4, MandatoryChar = 'c', Password = "acbdcefcgc" };

            var result = subject.IsValid;

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_WhenMandatoryCharIsPresentMoreThanMaximumOccurence_ThenFalse()
        {
            var subject = new PasswordEntry { MinOccurence = 2, MaxOccurence = 4, MandatoryChar = 'c', Password = "cacbdcefcgc" };

            var result = subject.IsValid;

            result.Should().BeFalse();
        }
    }
}
