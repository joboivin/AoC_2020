using System.Collections.Generic;
using System.Threading.Tasks;
using Day11Solver;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Day11SolverTests
{
    [Trait("Category", "Functionnal")]
    public class SolverFunctionnalTests
    {
        private readonly IInputProvider _inputProvider;

        private readonly Solver _subject;

        public SolverFunctionnalTests()
        {
            _inputProvider = Substitute.For<IInputProvider>();

            _subject = new Solver(_inputProvider, new EntirelyPredictableHumanBehavior());
        }

        [Fact]
        public async Task SolveProblemAsync_WhenUsingInputFromAoC_TheReturns37()
        {
            SetupInputProvider();

            var result = await _subject.SolveProblemAsync();

            result.Should().Be(37);
        }

        [Fact]
        public async Task SolveBonusProblemAsync_WhenUsingInputFromAoC_TheReturns26()
        {
            SetupInputProvider();

            var result = await _subject.SolveBonusProblemAsync();

            result.Should().Be(26);
        }

        private void SetupInputProvider()
        {
            _inputProvider.ProvideInputAsync().Returns(new Ferry
            {
                SeatLayout = new List<List<char>>
                {
                    new List<char> {'L', '.', 'L', 'L', '.', 'L', 'L', '.', 'L', 'L'},
                    new List<char> {'L', 'L', 'L', 'L', 'L', 'L', 'L', '.', 'L', 'L'},
                    new List<char> {'L', '.', 'L', '.', 'L', '.', '.', 'L', '.', '.'},
                    new List<char> {'L', 'L', 'L', 'L', '.', 'L', 'L', '.', 'L', 'L'},
                    new List<char> {'L', '.', 'L', 'L', '.', 'L', 'L', '.', 'L', 'L'},
                    new List<char> {'L', '.', 'L', 'L', 'L', 'L', 'L', '.', 'L', 'L'},
                    new List<char> {'.', '.', 'L', '.', 'L', '.', '.', '.', '.', '.'},
                    new List<char> {'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L'},
                    new List<char> {'L', '.', 'L', 'L', 'L', 'L', 'L', 'L', '.', 'L'},
                    new List<char> {'L', '.', 'L', 'L', 'L', 'L', 'L', '.', 'L', 'L'}
                }
            });
        }
    }
}
