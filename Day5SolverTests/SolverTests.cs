using Day5Solver;
using FluentAssertions;
using NSubstitute;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Day5SolverTests
{
    public class SolverTests
    {
        private readonly ISeatIdFinder _seatIdFinder;
        private readonly IRawInputProvider _rawInputProvider;

        private readonly Solver _subject;

        public SolverTests()
        {
            _seatIdFinder = Substitute.For<ISeatIdFinder>();
            _rawInputProvider = Substitute.For<IRawInputProvider>();

            _subject = new Solver(_seatIdFinder, _rawInputProvider);
        }

        [Fact]
        public async Task SolveProblemAsync_WhenUsingExampleFromAoC_ThenGivesExcectedAnswer()
        {
            const string seatNumber1 = "FBFBBFFRLR";
            const string seatNumber2 = "BFFFBBFRRR";
            const string seatNumber3 = "FFFBBBFRRR";
            const string seatNumber4 = "BBFFBBFRLL";
            const int seatId1 = 357;
            const int seatId2 = 567;
            const int seatId3 = 119;
            const int seatId4 = 820;

            _seatIdFinder.FindSeatId(seatNumber1).Returns(seatId1);
            _seatIdFinder.FindSeatId(seatNumber2).Returns(seatId2);
            _seatIdFinder.FindSeatId(seatNumber3).Returns(seatId3);
            _seatIdFinder.FindSeatId(seatNumber4).Returns(seatId4);
            _rawInputProvider.ProvideRawInputAsync()
                .Returns(new[] { seatNumber1, seatNumber2, seatNumber3, seatNumber4 }.ToAsyncEnumerable());

            var result = await _subject.SolveProblemAsync();

            result.Should().Be(seatId4);
        }

        [Fact]
        public async Task SolveBonusProblemAsync_ThenGivesMissingSeatId()
        {
            const string seatNumber1 = "FBFBBFFRLR";
            const string seatNumber2 = "BFFFBBFRRR";
            const string seatNumber3 = "FFFBBBFRRR";
            const string seatNumber4 = "BBFFBBFRLL";
            const int seatId1 = 100;
            const int seatId2 = 101;
            const int seatId3 = 102;
            const int seatId4 = 104;

            _seatIdFinder.FindSeatId(seatNumber1).Returns(seatId1);
            _seatIdFinder.FindSeatId(seatNumber2).Returns(seatId2);
            _seatIdFinder.FindSeatId(seatNumber3).Returns(seatId3);
            _seatIdFinder.FindSeatId(seatNumber4).Returns(seatId4);
            _rawInputProvider.ProvideRawInputAsync()
                .Returns(new[] { seatNumber1, seatNumber2, seatNumber3, seatNumber4 }.ToAsyncEnumerable());

            var result = await _subject.SolveBonusProblemAsync();

            result.Should().Be(103, "it's the only missing seat id");
        }
    }
}
