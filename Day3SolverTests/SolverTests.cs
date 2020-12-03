using Day3Solver;
using FluentAssertions;
using NSubstitute;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Day3SolverTests
{
    [Trait("Category", "Functionnal")]
    public class SolverTests
    {
        [Fact]
        public async Task SolveProblemAsync_WhenUsingInputFromAoC_ThenResultIs7()
        {
            var subject = new Solver(new InputProvider(SetupRawInputProvider()));

            var result = await subject.SolveProblemAsync();

            result.Should().Be(7, "it's the answer provided so we trust it");
        }

        [Fact]
        public async Task SolveBonusProblemAsync_WhenUsingInputFromAoC_ThenResultIs336()
        {
            var subject = new Solver(new InputProvider(SetupRawInputProvider()));

            var result = await subject.SolveBonusProblemAsync();

            result.Should().Be(336, "it's the answer provided so we trust it");
        }

        private IRawInputProvider SetupRawInputProvider()
        {
            var rawInputProvider = Substitute.For<IRawInputProvider>();

            rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "..##.......",
                "#...#...#..",
                ".#....#..#.",
                "..#.#...#.#",
                ".#...##..#.",
                "..#.##.....",
                ".#.#.#....#",
                ".#........#",
                "#.##...#...",
                "#...##....#",
                ".#..#...#.#"
            }.ToAsyncEnumerable());

            return rawInputProvider;
        }
    }
}
