using Day15Solver;
using FluentAssertions;
using Xunit;

namespace Day15SolverTests
{
    public class SolverTests
    {
        [Theory]
        [InlineData(436, 0, 3, 6)]
        [InlineData(1, 1, 3, 2)]
        [InlineData(10, 2, 1, 3)]
        [InlineData(27, 1, 2, 3)]
        [InlineData(78, 2, 3, 1)]
        [InlineData(438, 3, 2, 1)]
        [InlineData(1836, 3, 1, 2)]
        public void SolveProblem_WhenUsingExamplesFromAoC_ThenReturnsExpectedNumber(int expectedNumber, params int[] input)
        {
            var subject = new Solver(input);

            var result = subject.SolveProblem();

            result.Should().Be(expectedNumber);
        }

        [Theory]
        [InlineData(175594, 0, 3, 6)]
        [InlineData(2578, 1, 3, 2)]
        [InlineData(3544142, 2, 1, 3)]
        [InlineData(261214, 1, 2, 3)]
        [InlineData(6895259, 2, 3, 1)]
        [InlineData(18, 3, 2, 1)]
        [InlineData(362, 3, 1, 2)]
        public void SolveBonusProblem_WhenUsingExamplesFromAoC_ThenReturnsExpectedNumber(int expectedNumber, params int[] input)
        {
            var subject = new Solver(input);

            var result = subject.SolveBonusProblem();

            result.Should().Be(expectedNumber);
        }
    }
}
