using Day3Solver;
using FluentAssertions;
using NSubstitute;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Day3SolverTests
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
        public async Task ProvideInput_When1LineInRawInput_ThenForestHeightIs1()
        {
            _rawInputProvider.ProvideRawInput().Returns(new[] { "...#..." }.ToAsyncEnumerable());

            var result = await _subject.ProvideInputAsync();

            result.VisibleForest.Count.Should().Be(1);
        }

        [Fact]
        public async Task ProvideInput_When1LineInRawInput_ThenForestTreesAndOpenSquareParsedCorrectly()
        {
            _rawInputProvider.ProvideRawInput().Returns(new[] { "...#..." }.ToAsyncEnumerable());

            var result = await _subject.ProvideInputAsync();

            var firstRowOfForest = result.VisibleForest[0];
            firstRowOfForest[0].Should().Be('.');
            firstRowOfForest[1].Should().Be('.');
            firstRowOfForest[2].Should().Be('.');
            firstRowOfForest[3].Should().Be('#');
            firstRowOfForest[4].Should().Be('.');
            firstRowOfForest[5].Should().Be('.');
            firstRowOfForest[6].Should().Be('.');
        }

        [Fact]
        public async Task ProvideInput_When2LinesInRawInput_ThenForestHeightIs2()
        {
            _rawInputProvider.ProvideRawInput().Returns(new[] { "...#...", "##..##." }.ToAsyncEnumerable());

            var result = await _subject.ProvideInputAsync();

            result.VisibleForest.Count.Should().Be(2);
        }

        [Fact]
        public async Task ProvideInput_When2LinesInRawInput_ThenForestTreesAndOpenSquareParsedCorrectlyInSecondLine()
        {
            _rawInputProvider.ProvideRawInput().Returns(new[] { "...#...", "##..##." }.ToAsyncEnumerable());

            var result = await _subject.ProvideInputAsync();

            var secondRowOfForest = result.VisibleForest[1];
            secondRowOfForest[0].Should().Be('#');
            secondRowOfForest[1].Should().Be('#');
            secondRowOfForest[2].Should().Be('.');
            secondRowOfForest[3].Should().Be('.');
            secondRowOfForest[4].Should().Be('#');
            secondRowOfForest[5].Should().Be('#');
            secondRowOfForest[6].Should().Be('.');
        }
    }
}
