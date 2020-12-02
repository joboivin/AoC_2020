using Day1Solver;
using FluentAssertions;
using NSubstitute;
using System;
using Xunit;

namespace Day1SolverTests
{
    public class SolverTests
    {
        private readonly IInputProvider _inputProvider;
        private readonly Solver _subject;

        public SolverTests()
        {
            _inputProvider = Substitute.For<IInputProvider>();
            _subject = new Solver(_inputProvider);
        }

        [Fact]
        public void Solve_When2NumbersAddUpTo2020_ThenReturnsProductOfThoseNumbers()
        {
            _inputProvider.ProvideInput().Returns(new[] { 1721, 979, 366, 299, 675, 1456 });

            var result = _subject.SolveProblem();

            result.Should().Be(514579, "the product of 1721 and 299 is 514579");
        }



        [Fact]
        public void Solve_WhenNo2NumbersAddUpTo2020_ThenThrowsException()
        {
            _inputProvider.ProvideInput().Returns(new[] { 1721, 979, 366, 300, 675, 1456 });

            var action = new Action(() => _subject.SolveProblem());

            action.Should().Throw<Exception>();
        }
    }
}
