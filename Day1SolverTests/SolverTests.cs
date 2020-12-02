using Day1Solver;
using FluentAssertions;
using NSubstitute;
using System;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task SolveProblemAsync_When2NumbersAddUpTo2020_ThenReturnsProductOfThoseNumbers()
        {
            _inputProvider.ProvideInputAsync().Returns(new[] { 1721, 979, 366, 299, 675, 1456 }.ToAsyncEnumerable());

            var result = await _subject.SolveProblemAsync();

            result.Should().Be(514579, "the product of 1721 and 299 is 514579");
        }

        [Fact]
        public void SolveProblemAsync_WhenNo2NumbersAddUpTo2020_ThenThrowsException()
        {
            _inputProvider.ProvideInputAsync().Returns(new[] { 1721, 979, 366, 300, 675, 1456 }.ToAsyncEnumerable());

            var action = new Func<Task>(async () => await _subject.SolveProblemAsync());

            action.Should().Throw<Exception>();
        }

        [Fact]
        public async Task SolveBonusProblemAsync_When3NumbersAddUpTo2020_ThenReturnsProductOfThoseNumbers()
        {
            _inputProvider.ProvideInputAsync().Returns(new[] { 1721, 979, 366, 299, 675, 1456 }.ToAsyncEnumerable());

            var result = await _subject.SolveBonusProblemAsync();

            result.Should().Be(241861950, "the product of 979, 366 and 675 is 241861950");
        }

        [Fact]
        public void SolveBonusProblemAsync_WhenNo3NumbersAddUpTo2020_ThenThrowsException()
        {
            _inputProvider.ProvideInputAsync().Returns(new[] { 1721, 979, 366, 299, 676, 1456 }.ToAsyncEnumerable());

            var action = new Func<Task>(async () => await _subject.SolveBonusProblemAsync());

            action.Should().Throw<Exception>();
        }
    }
}
