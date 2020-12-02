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
        public void SolveProblem_When2NumbersAddUpTo2020_ThenReturnsProductOfThoseNumbers()
        {
            _inputProvider.ProvideInput().Returns(new[] { 1721, 979, 366, 299, 675, 1456 });

            var result = _subject.SolveProblem();

            result.Should().Be(514579, "the product of 1721 and 299 is 514579");
        }

        [Fact]
        public void SolveProblem_WhenNo2NumbersAddUpTo2020_ThenThrowsException()
        {
            _inputProvider.ProvideInput().Returns(new[] { 1721, 979, 366, 300, 675, 1456 });

            var action = new Action(() => _subject.SolveProblem());

            action.Should().Throw<Exception>();
        }

        [Fact]
        public void SolveBonusProblem_When3NumbersAddUpTo2020_ThenReturnsProductOfThoseNumbers()
        {
            _inputProvider.ProvideInput().Returns(new[] { 1721, 979, 366, 299, 675, 1456 });

            var result = _subject.SolveBonusProblem();

            result.Should().Be(241861950, "the product of 979, 366 and 675 is 241861950");
        }

        [Fact]
        public void SolveBonusProblem_WhenNo3NumbersAddUpTo2020_ThenThrowsException()
        {
            _inputProvider.ProvideInput().Returns(new[] { 1721, 979, 366, 299, 676, 1456 });

            var action = new Action(() => _subject.SolveBonusProblem());

            action.Should().Throw<Exception>();
        }
    }
}
