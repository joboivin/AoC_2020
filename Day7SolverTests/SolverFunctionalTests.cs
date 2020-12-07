using Day7Solver;
using FluentAssertions;
using NSubstitute;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Day7SolverTests
{
    [Trait("Category", "Functionnal")]
    public class SolverFunctionalTests
    {
        private readonly IRawInputProvider _rawInputProvider;

        private readonly Solver _subject;

        public SolverFunctionalTests()
        {
            _rawInputProvider = Substitute.For<IRawInputProvider>();

            _subject = new Solver(new InputProvider(_rawInputProvider));
        }

        [Fact]
        public async Task SolveProblemAsync_WhenUsingInputFromAoC_ThenReturns4()
        {
            SetupRawInputProvider();

            var result = await _subject.SolveProblemAsync();

            result.Should().Be(4);
        }

        [Fact]
        public async Task SolveBonusProblemAsync_WhenUsingInputFromAoC_ThenReturns32()
        {
            SetupRawInputProvider();

            var result = await _subject.SolveBonusProblemAsync();

            result.Should().Be(32);
        }

        [Fact]
        public async Task SolveBonusProblemAsync_WhenUsingAlternativeInputFromAoC_ThenReturns126()
        {
            SetupAlternativeRawInputProvider();

            var result = await _subject.SolveBonusProblemAsync();

            result.Should().Be(126);
        }

        private void SetupRawInputProvider()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags."
            }.ToAsyncEnumerable());
        }

        private void SetupAlternativeRawInputProvider()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "shiny gold bags contain 2 dark red bags.",
                "dark red bags contain 2 dark orange bags.",
                "dark orange bags contain 2 dark yellow bags.",
                "dark yellow bags contain 2 dark green bags.",
                "dark green bags contain 2 dark blue bags.",
                "dark blue bags contain 2 dark violet bags.",
                "dark violet bags contain no other bags.",
            }.ToAsyncEnumerable());
        }
    }
}
