using Day4Solver.Passport;
using FluentAssertions;
using Xunit;

namespace Day4SolverTests.Passport
{
    public class IssueYearTests
    {
        [Fact]
        public void IsValidForBonus_WhenIssueYearHasLessThan4Digits_ThenFalse()
        {
            var subject = new IssueYear("123");

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidForBonus_WhenIssueYearHasGreaterThan4Digits_ThenFalse()
        {
            var subject = new IssueYear("12345");

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidForBonus_WhenIssueYearHas4DigitsAndYearLessThan2010_ThenFalse()
        {
            var subject = new IssueYear("2009");

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidForBonus_WhenIssueYearHas4DigitsAndYear2010_ThenTrue()
        {
            var subject = new IssueYear("2010");

            var result = subject.IsValidForBonus();

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValidForBonus_WhenIssueYearHas4DigitsAndYear2020_ThenTrue()
        {
            var subject = new IssueYear("2020");

            var result = subject.IsValidForBonus();

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValidForBonus_WhenIssueYearHas4DigitsAndYearGreaterThan2020_ThenFalse()
        {
            var subject = new IssueYear("2021");

            var result = subject.IsValidForBonus();

            result.Should().BeFalse();
        }
    }
}
