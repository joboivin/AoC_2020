using Day5Solver;
using FluentAssertions;
using Xunit;

namespace Day5SolverTests
{
    public class RowFinderTests
    {
        private readonly RowFinder _subject = new RowFinder();

        [Theory]
        [InlineData("FBFBBFFRLR", 44)]
        [InlineData("BFFFBBFRRR", 70)]
        [InlineData("FFFBBBFRRR", 14)]
        [InlineData("BBFFBBFRLL", 102)]
        public void FindRowNumber_WhenUsingExamplesFromAoC_ThenGivesExpectedAnswer(string seatNumber, int expectedRowNumber)
        {
            var result = _subject.FindRowNumber(seatNumber);

            result.Should().Be(expectedRowNumber, "it's the answer provided on AoC so we trust it");
        }
    }
}
