using System.Collections.Generic;
using System.Threading.Tasks;
using Day11Solver;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Day11SolverTests
{
    public class SolverTests
    {
        private readonly IInputProvider _inputProvider;
        private readonly IEntirelyPredictableHumanBehavior _entirelyPredictableHumanBehavior;

        private readonly Solver _subject;

        public SolverTests()
        {
            _inputProvider = Substitute.For<IInputProvider>();
            _entirelyPredictableHumanBehavior = Substitute.For<IEntirelyPredictableHumanBehavior>();

            _subject = new Solver(_inputProvider, _entirelyPredictableHumanBehavior);
        }

        [Fact]
        public async Task SolveProblemAsync_ThenReturnsOccupiedSeatsOneNobodyMoves()
        {
            var firstFerry = SetupFirstFerry();
            var secondFerry = SetupSecondFerry();
            var thirdFerry = SetupSecondFerry();
            _inputProvider.ProvideInputAsync().Returns(firstFerry);
            _entirelyPredictableHumanBehavior.ApplySimpleSetOfRules(firstFerry).Returns(secondFerry);
            _entirelyPredictableHumanBehavior.ApplySimpleSetOfRules(secondFerry).Returns(thirdFerry);

            var result = await _subject.SolveProblemAsync();

            result.Should().Be(3);
        }

        [Fact]
        public async Task SolveBonusProblemAsync_ThenReturnsOccupiedSeatsOneNobodyMoves()
        {
            var firstFerry = SetupFirstFerry();
            var secondFerry = SetupSecondFerry();
            var thirdFerry = SetupSecondFerry();
            _inputProvider.ProvideInputAsync().Returns(firstFerry);
            _entirelyPredictableHumanBehavior.ApplyMoreComplexButStillFairlySimpleSetOfRules(firstFerry).Returns(secondFerry);
            _entirelyPredictableHumanBehavior.ApplyMoreComplexButStillFairlySimpleSetOfRules(secondFerry).Returns(thirdFerry);

            var result = await _subject.SolveBonusProblemAsync();

            result.Should().Be(3);
        }

        private Ferry SetupFirstFerry()
        {
            return new Ferry
            {
                SeatLayout = new List<List<char>>
                {
                    new List<char>{'.', 'L', '#'},
                    new List<char>{'.', '#', '#'},
                }
            };
        }

        private Ferry SetupSecondFerry()
        {
            return new Ferry
            {
                SeatLayout = new List<List<char>>
                {
                    new List<char>{'.', '#', '#'},
                    new List<char>{'.', 'L', '#'},
                }
            };
        }
    }
}
