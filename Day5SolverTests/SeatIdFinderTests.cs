using Day5Solver;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Day5SolverTests
{
    public class SeatIdFinderTests
    {
        private readonly IRowFinder _rowFinder;
        private readonly IColumnFinder _columnFinder;

        private readonly SeatIdFinder _subject;

        public SeatIdFinderTests()
        {
            _rowFinder = Substitute.For<IRowFinder>();
            _columnFinder = Substitute.For<IColumnFinder>();

            _subject = new SeatIdFinder(_rowFinder, _columnFinder);
        }

        [Theory]
        [InlineData(44, 5, 357)]
        [InlineData(70, 7, 567)]
        [InlineData(14, 7, 119)]
        [InlineData(102, 4, 820)]
        public void FindSeatId_WhenUsingExamplesFromAoC_ThenGivesExpectedAnswer(int rowNumber, int columnNumber, int expectedSeatId)
        {
            const string seatNumber = "SEATNUMBER";

            _rowFinder.FindRowNumber(seatNumber).Returns(rowNumber);
            _columnFinder.FindColumnNumber(seatNumber).Returns(columnNumber);

            var result = _subject.FindSeatId(seatNumber);

            result.Should().Be(expectedSeatId, "it's the answer provided on AoC so we trust it");
        }
    }
}
