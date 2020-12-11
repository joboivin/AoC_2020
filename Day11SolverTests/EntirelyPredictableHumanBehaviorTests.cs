using System.Collections.Generic;
using Day11Solver;
using FluentAssertions;
using Xunit;

namespace Day11SolverTests
{
    public class EntirelyPredictableHumanBehaviorTests
    {
        private readonly EntirelyPredictableHumanBehavior _subject = new EntirelyPredictableHumanBehavior();

        [Fact]
        public void ApplySimpleSetOfRules_WhenUsingFirstFerry_ThenProducesSecondFerry()
        {
            var initialFerry = SetupFirstSimpleFerry();
            var expectedFerry = SetupSecondSimpleFerry();

            var result = _subject.ApplySimpleSetOfRules(initialFerry);

            result.Should().BeEquivalentTo(expectedFerry);
        }

        [Fact]
        public void ApplySimpleSetOfRules_WhenUsingSecondFerry_ThenProducesThirdFerry()
        {
            var initialFerry = SetupSecondSimpleFerry();
            var expectedFerry = SetupThirdSimpleFerry();

            var result = _subject.ApplySimpleSetOfRules(initialFerry);

            result.Should().BeEquivalentTo(expectedFerry);
        }

        [Fact]
        public void ApplyMoreComplexButStillFairlySimpleSetOfRules_WhenUsingFirstFerry_ThenProducesSecondFerry()
        {
            var initialFerry = SetupFirstComplexFerry();
            var expectedFerry = SetupSecondComplexFerry();

            var result = _subject.ApplyMoreComplexButStillFairlySimpleSetOfRules(initialFerry);

            result.Should().BeEquivalentTo(expectedFerry);
        }

        [Fact]
        public void ApplyMoreComplexButStillFairlySimpleSetOfRules_WhenUsingSecondFerry_ThenProducesThirdFerry()
        {
            var initialFerry = SetupSecondComplexFerry();
            var expectedFerry = SetupThirdComplexFerry();

            var result = _subject.ApplyMoreComplexButStillFairlySimpleSetOfRules(initialFerry);

            result.Should().BeEquivalentTo(expectedFerry);
        }

        private Ferry SetupFirstSimpleFerry()
        {
            return new Ferry
            {
                SeatLayout = new List<List<char>>
                {
                    new List<char>{'#', '.', 'L', 'L', '.', 'L', '#', '.', '#', '#'},
                    new List<char>{'#', 'L', 'L', 'L', 'L', 'L', 'L', '.', 'L', '#'},
                    new List<char>{'L', '.', 'L', '.', 'L', '.', '.', 'L', '.', '.'},
                    new List<char>{'#', 'L', 'L', 'L', '.', 'L', 'L', '.', 'L', '#'},
                    new List<char>{'#', '.', 'L', 'L', '.', 'L', 'L', '.', 'L', 'L'},
                    new List<char>{'#', '.', 'L', 'L', 'L', 'L', '#', '.', '#', '#'},
                    new List<char>{'.', '.', 'L', '.', 'L', '.', '.', '.', '.', '.'},
                    new List<char>{'#', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', '#'},
                    new List<char>{'#', '.', 'L', 'L', 'L', 'L', 'L', 'L', '.', 'L'},
                    new List<char>{'#', '.', '#', 'L', 'L', 'L', 'L', '.', '#', '#'}
                }
            };
        }

        private Ferry SetupSecondSimpleFerry()
        {
            return new Ferry
            {
                SeatLayout = new List<List<char>>
                {
                    new List<char>{'#', '.', '#', '#', '.', 'L', '#', '.', '#', '#'},
                    new List<char>{'#', 'L', '#', '#', '#', 'L', 'L', '.', 'L', '#'},
                    new List<char>{'L', '.', '#', '.', '#', '.', '.', '#', '.', '.'},
                    new List<char>{'#', 'L', '#', '#', '.', '#', '#', '.', 'L', '#'},
                    new List<char>{'#', '.', '#', '#', '.', 'L', 'L', '.', 'L', 'L'},
                    new List<char>{'#', '.', '#', '#', '#', 'L', '#', '.', '#', '#'},
                    new List<char>{'.', '.', '#', '.', '#', '.', '.', '.', '.', '.'},
                    new List<char>{'#', 'L', '#', '#', '#', '#', '#', '#', 'L', '#'},
                    new List<char>{'#', '.', 'L', 'L', '#', '#', '#', 'L', '.', 'L'},
                    new List<char>{'#', '.', '#', 'L', '#', '#', '#', '.', '#', '#'},
                }
            };
        }

        private Ferry SetupThirdSimpleFerry()
        {
            return new Ferry
            {
                SeatLayout = new List<List<char>>
                {
                    new List<char>{'#', '.', '#', 'L', '.', 'L', '#', '.', '#', '#'},
                    new List<char>{'#', 'L', 'L', 'L', '#', 'L', 'L', '.', 'L', '#'},
                    new List<char>{'L', '.', 'L', '.', 'L', '.', '.', '#', '.', '.'},
                    new List<char>{'#', 'L', 'L', 'L', '.', '#', '#', '.', 'L', '#'},
                    new List<char>{'#', '.', 'L', 'L', '.', 'L', 'L', '.', 'L', 'L'},
                    new List<char>{'#', '.', 'L', 'L', '#', 'L', '#', '.', '#', '#'},
                    new List<char>{'.', '.', 'L', '.', 'L', '.', '.', '.', '.', '.'},
                    new List<char>{'#', 'L', '#', 'L', 'L', 'L', 'L', '#', 'L', '#'},
                    new List<char>{'#', '.', 'L', 'L', 'L', 'L', 'L', 'L', '.', 'L'},
                    new List<char>{'#', '.', '#', 'L', '#', 'L', '#', '.', '#', '#'}
                }
            };
        }

        private Ferry SetupFirstComplexFerry()
        {
            return new Ferry
            {
                SeatLayout = new List<List<char>>
                {
                    new List<char>{'#', '.', 'L', '#', '.', 'L', '#', '.', 'L', '#'},
                    new List<char>{'#', 'L', 'L', 'L', 'L', 'L', 'L', '.', 'L', 'L'},
                    new List<char>{'L', '.', 'L', '.', 'L', '.', '.', '#', '.', '.'},
                    new List<char>{'#', '#', 'L', 'L', '.', 'L', 'L', '.', 'L', '#'},
                    new List<char>{'L', '.', 'L', 'L', '.', 'L', 'L', '.', 'L', '#'},
                    new List<char>{'#', '.', 'L', 'L', 'L', 'L', 'L', '.', 'L', 'L'},
                    new List<char>{'.', '.', 'L', '.', 'L', '.', '.', '.', '.', '.'},
                    new List<char>{'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', '#'},
                    new List<char>{'#', '.', 'L', 'L', 'L', 'L', 'L', '#', '.', 'L'},
                    new List<char>{'#', '.', 'L', '#', 'L', 'L', '#', '.', 'L', '#'}
                }
            };
        }

        private Ferry SetupSecondComplexFerry()
        {
            return new Ferry
            {
                SeatLayout = new List<List<char>>
                {
                    new List<char>{'#', '.', 'L', '#', '.', 'L', '#', '.', 'L', '#'},
                    new List<char>{'#', 'L', 'L', 'L', 'L', 'L', 'L', '.', 'L', 'L'},
                    new List<char>{'L', '.', 'L', '.', 'L', '.', '.', '#', '.', '.'},
                    new List<char>{'#', '#', 'L', '#', '.', '#', 'L', '.', 'L', '#'},
                    new List<char>{'L', '.', 'L', '#', '.', '#', 'L', '.', 'L', '#'},
                    new List<char>{'#', '.', 'L', '#', '#', '#', '#', '.', 'L', 'L'},
                    new List<char>{'.', '.', '#', '.', '#', '.', '.', '.', '.', '.'},
                    new List<char>{'L', 'L', 'L', '#', '#', '#', 'L', 'L', 'L', '#'},
                    new List<char>{'#', '.', 'L', 'L', 'L', 'L', 'L', '#', '.', 'L'},
                    new List<char>{'#', '.', 'L', '#', 'L', 'L', '#', '.', 'L', '#'}
                }
            };
        }

        private Ferry SetupThirdComplexFerry()
        {
            return new Ferry
            {
                SeatLayout = new List<List<char>>
                {
                    new List<char>{'#', '.', 'L', '#', '.', 'L', '#', '.', 'L', '#'},
                    new List<char>{'#', 'L', 'L', 'L', 'L', 'L', 'L', '.', 'L', 'L'},
                    new List<char>{'L', '.', 'L', '.', 'L', '.', '.', '#', '.', '.'},
                    new List<char>{'#', '#', 'L', '#', '.', '#', 'L', '.', 'L', '#'},
                    new List<char>{'L', '.', 'L', '#', '.', 'L', 'L', '.', 'L', '#'},
                    new List<char>{'#', '.', 'L', 'L', 'L', 'L', '#', '.', 'L', 'L'},
                    new List<char>{'.', '.', '#', '.', 'L', '.', '.', '.', '.', '.'},
                    new List<char>{'L', 'L', 'L', '#', '#', '#', 'L', 'L', 'L', '#'},
                    new List<char>{'#', '.', 'L', 'L', 'L', 'L', 'L', '#', '.', 'L'},
                    new List<char>{'#', '.', 'L', '#', 'L', 'L', '#', '.', 'L', '#'}
                }
            };
        }
    }
}
