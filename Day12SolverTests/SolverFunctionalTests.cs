using System.Linq;
using System.Threading.Tasks;
using Day12Solver;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Day12SolverTests
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
        public async Task SolveProblemAsync_WhenUsingInputFromAoC_ThenReturns25()
        {
            SetupRawInputProvider();

            var result = await _subject.SolveProblemAsync();

            result.Should().Be(25);
        }

        [Fact]
        public async Task SolveBonusProblemAsync_WhenUsingInputFromAoC_ThenReturns286()
        {
            SetupRawInputProvider();

            var result = await _subject.SolveBonusProblemAsync();

            result.Should().Be(286);
        }

        private void SetupRawInputProvider()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "F10",
                "N3",
                "F7",
                "R90",
                "F11"
            }.ToAsyncEnumerable());
        }
    }
}
