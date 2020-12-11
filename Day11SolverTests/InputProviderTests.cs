using System.Linq;
using System.Threading.Tasks;
using Day11Solver;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Day11SolverTests
{
    public class InputProviderTests
    {
        private readonly IRawInputProvider _rawInputProvider;

        private readonly InputProvider _subject;

        public InputProviderTests()
        {
            _rawInputProvider = Substitute.For<IRawInputProvider>();

            _subject = new InputProvider(_rawInputProvider);
        }

        [Fact]
        public async Task ProvideInput_When1LineInRawInput_ThenFerryHeightIs1()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "...#.L." }.ToAsyncEnumerable());

            var result = await _subject.ProvideInputAsync();

            result.SeatLayout.Count.Should().Be(1);
        }

        [Fact]
        public async Task ProvideInput_When1LineInRawInput_ThenFerrySeatsAndFloorParsedCorrectly()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "...#.L." }.ToAsyncEnumerable());

            var result = await _subject.ProvideInputAsync();

            var firstRowOfSeats = result.SeatLayout[0];
            firstRowOfSeats[0].Should().Be('.');
            firstRowOfSeats[1].Should().Be('.');
            firstRowOfSeats[2].Should().Be('.');
            firstRowOfSeats[3].Should().Be('#');
            firstRowOfSeats[4].Should().Be('.');
            firstRowOfSeats[5].Should().Be('L');
            firstRowOfSeats[6].Should().Be('.');
        }

        [Fact]
        public async Task ProvideInput_When2LinesInRawInput_ThenFerryHeightIs2()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "...#.L.", "##..##." }.ToAsyncEnumerable());

            var result = await _subject.ProvideInputAsync();

            result.SeatLayout.Count.Should().Be(2);
        }

        [Fact]
        public async Task ProvideInput_When2LinesInRawInput_ThenFerrySeatsAndFloorParsedCorrectlyInSecondLine()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "...#.L.", "##..##." }.ToAsyncEnumerable());

            var result = await _subject.ProvideInputAsync();

            var secondRowOfSeats = result.SeatLayout[1];
            secondRowOfSeats[0].Should().Be('#');
            secondRowOfSeats[1].Should().Be('#');
            secondRowOfSeats[2].Should().Be('.');
            secondRowOfSeats[3].Should().Be('.');
            secondRowOfSeats[4].Should().Be('#');
            secondRowOfSeats[5].Should().Be('#');
            secondRowOfSeats[6].Should().Be('.');
        }
    }
}
