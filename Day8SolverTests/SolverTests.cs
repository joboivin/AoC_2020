using System.Linq;
using System.Threading.Tasks;
using Day8Solver;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Day8SolverTests
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
        public async Task SolveProblem_WhenUsingInputFromAoC_ThenReturns5()
        {
            SetupRawInputProvider();

            var result = await _subject.SolveProblemAsync();

            result.Should().Be(5);
        }

        [Fact]
        public async Task SolveBonusProblemAsync_WhenUsingInputFromAoC_ThenReturns5()
        {
            SetupRawInputProvider();

            var result = await _subject.SolveBonusProblemAsync();

            result.Should().Be(8);
        }

        private void SetupRawInputProvider()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6"
            }.ToAsyncEnumerable());
        }
    }
}
