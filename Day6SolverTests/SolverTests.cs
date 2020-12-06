using Day6Solver;
using FluentAssertions;
using NSubstitute;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Day6SolverTests
{
    [Trait("Category", "Functionnal")]
    public class SolverTests
    {
        private readonly IRawInputProvider _rawInputProvider;

        private readonly Solver _subject;

        public SolverTests()
        {
            _rawInputProvider = Substitute.For<IRawInputProvider>();

            _subject = new Solver(new InputProvider(_rawInputProvider));
        }

        [Fact]
        public async Task SolveProblem_When5GroupsAndAnswerTotalIs11_ThenReturns11()
        {
            SetupRawInputProvider();

            var result = await _subject.SolveProblemAsync();

            result.Should().Be(11);
        }

        [Fact]
        public async Task SolveBonusProblem_When5GroupsAndAnswerTotalIs6_ThenReturns6()
        {
            SetupRawInputProvider();

            var result = await _subject.SolveBonusProblemAsync();

            result.Should().Be(6);
        }

        private void SetupRawInputProvider()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "abc",
                "",
                "a",
                "b",
                "c",
                "",
                "ab",
                "ac",
                "",
                "a",
                "a",
                "a",
                "a",
                "",
                "b"
            }.ToAsyncEnumerable());
        }
    }
}
