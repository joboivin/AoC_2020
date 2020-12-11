using System.Linq;
using System.Threading.Tasks;
using Day10Solver;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Day10SolverTests
{
    public class SolverTests
    {
        private readonly IRawInputProvider _rawInputProvider;

        private readonly Solver _subject;

        public SolverTests()
        {
            _rawInputProvider = Substitute.For<IRawInputProvider>();

            _subject = new Solver(_rawInputProvider);
        }

        [Fact]
        public async Task SolveProblemAsync_WhenUsingFirstInputFromAoC_ThenReturns35()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "16",
                "10",
                "15",
                "5",
                "1",
                "11",
                "7",
                "19",
                "6",
                "12",
                "4"
            }.ToAsyncEnumerable());

            var result = await _subject.SolveProblemAsync();

            result.Should().Be(35);
        }

        [Fact]
        public async Task SolveProblemAsync_WhenUsingSecondInputFromAoC_ThenReturns220()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "28",
                "33",
                "18",
                "42",
                "31",
                "14",
                "46",
                "20",
                "48",
                "47",
                "24",
                "23",
                "49",
                "45",
                "19",
                "38",
                "39",
                "11",
                "1",
                "32",
                "25",
                "35",
                "8",
                "17",
                "7",
                "9",
                "4",
                "2",
                "34",
                "10",
                "3"
            }.ToAsyncEnumerable());

            var result = await _subject.SolveProblemAsync();

            result.Should().Be(220);
        }

        [Fact]
        public async Task SolveBonusProblemAsync_WhenUsingFirstInputFromAoC_ThenReturns8()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "16",
                "10",
                "15",
                "5",
                "1",
                "11",
                "7",
                "19",
                "6",
                "12",
                "4"
            }.ToAsyncEnumerable());

            var result = await _subject.SolveBonusProblemAsync();

            result.Should().Be(8);
        }

        [Fact]
        public async Task SolveBonusProblemAsync_WhenUsingSecondInputFromAoC_ThenReturns19208()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "28",
                "33",
                "18",
                "42",
                "31",
                "14",
                "46",
                "20",
                "48",
                "47",
                "24",
                "23",
                "49",
                "45",
                "19",
                "38",
                "39",
                "11",
                "1",
                "32",
                "25",
                "35",
                "8",
                "17",
                "7",
                "9",
                "4",
                "2",
                "34",
                "10",
                "3"
            }.ToAsyncEnumerable());

            var result = await _subject.SolveBonusProblemAsync();

            result.Should().Be(19208);
        }
    }
}
