using System.Linq;
using System.Threading.Tasks;
using Day13Solver;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Day13SolverTests
{
    [Trait("Category", "Functionnal")]
    public class SolverFunctionalTests
    {
        private readonly IRawInputProvider _rawInputProvider;

        private readonly Solver _subject;

        public SolverFunctionalTests()
        {
            _rawInputProvider = Substitute.For<IRawInputProvider>();

            _subject = new Solver(_rawInputProvider);
        }

        [Fact]
        public async Task SolveProblemAsync_WhenUsingInputFromAoC_ThenReturns295()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "939",
                "7,13,x,x,59,x,31,19"
            }.ToAsyncEnumerable());

            var result = await _subject.SolveProblemAsync();

            result.Should().Be(295);
        }

        [Theory]
        [InlineData("7,13,x,x,59,x,31,19", 1068781)]
        [InlineData("17,x,13,19", 3417)]
        [InlineData("67,7,59,61", 754018)]
        [InlineData("67,x,7,59,61", 779210)]
        [InlineData("67,7,x,59,61", 1261476)]
        [InlineData("1789,37,47,1889", 1202161486)]
        public async Task SolveBonusProblemAsync_WhenUsingFirstInputFromAoC_ThenReturns1068781(string input, long expectedAnswer)
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "939",
                input
            }.ToAsyncEnumerable());

            var result = await _subject.SolveBonusProblemAsync();

            result.Should().Be(expectedAnswer);
        }
    }
}
