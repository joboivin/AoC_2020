using System.Linq;
using System.Threading.Tasks;
using Day16Solver;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Day16SolverTests
{
    [Trait("Category", "Functionnal")]
    public class SolverFunctionnalTests
    {
        private readonly IRawInputProvider _rawInputProvider;

        private readonly Solver _subject;

        public SolverFunctionnalTests()
        {
            _rawInputProvider = Substitute.For<IRawInputProvider>();

            _subject = new Solver(new InputProvider(_rawInputProvider), new TicketFieldPositionFinder());
        }

        [Fact]
        public async Task SolveProblemAsync_WhenUsingInputFromAoC_ThenReturnsExpectedSum()
        {
            SetupFirstRawInputProvider();

            var result = await _subject.SolveProblemAsync();

            result.Should().Be(71);
        }

        [Fact]
        public async Task SolveBonusProblemAsync_WhenUsingInputFromAoCModifiedToHaveSomeDepartures_ThenReturnsExpectedProduct()
        {
            SetupSecondRawInputProvider();

            var result = await _subject.SolveBonusProblemAsync();

            result.Should().Be(156);
        }

        private void SetupFirstRawInputProvider()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "class: 1-3 or 5-7",
                "row: 6-11 or 33-44",
                "seat: 13-40 or 45-50",
                "",
                "your ticket:",
                "7,1,14",

                "nearby tickets:",
                "7,3,47",
                "40,4,50",
                "55,2,20",
                "38,6,12"
            }.ToAsyncEnumerable());
        }

        private void SetupSecondRawInputProvider()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "departure class: 0-1 or 4-19",
                "row: 0-5 or 8-19",
                "departure seat: 0-13 or 16-19",
                "",
                "your ticket:",
                "11,12,13",
                "",
                "nearby tickets:",
                "3,9,18",
                "15,1,5",
                "5,14,9"
            }.ToAsyncEnumerable());
        }
    }
}
