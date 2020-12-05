using Day5Solver;
using FluentAssertions;
using Xunit;

namespace Day5SolverTests
{
    public class ColumnFinderTests
    {
        private readonly ColumnFinder _subject = new ColumnFinder();

        [Theory]
        [InlineData("FBFBBFFRLR", 5)]
        [InlineData("BFFFBBFRRR", 7)]
        [InlineData("FFFBBBFRRR", 7)]
        [InlineData("BBFFBBFRLL", 4)]
        public void FindColumnNumber_WhenUsingExamplesFromAoC_ThenGivesExpectedAnswer(string seatNumber, int expectedColumnNumber)
        {
            var result = _subject.FindColumnNumber(seatNumber);

            result.Should().Be(expectedColumnNumber, "it's the answer provided on AoC so we trust it");
        }
    }
}
