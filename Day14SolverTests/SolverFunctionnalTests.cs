using System.Linq;
using System.Threading.Tasks;
using Day14Solver;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Day14SolverTests
{
    [Trait("Category", "Functionnal")]
    public class SolverFunctionnalTests
    {
        private readonly IRawInputProvider _rawInputProvider;

        private readonly Solver _subject;

        public SolverFunctionnalTests()
        {
            _rawInputProvider = Substitute.For<IRawInputProvider>();

            _subject = new Solver(_rawInputProvider);
        }

        [Fact]
        public async Task SolveProblemAsync_When1MaskInInput_ThenReturnsExceptedValue()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
                "mem[8] = 11",
                "mem[7] = 101",
                "mem[8] = 0"
            }.ToAsyncEnumerable());

            var result = await _subject.SolveProblemAsync();

            result.Should().Be(165);
        }

        [Fact]
        public async Task SolveProblemAsync_When2MasksInInput_ThenReturnsExceptedValue()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
                "mem[8] = 11",
                "mem[7] = 101",
                "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XX1X1X",
                "mem[8] = 0"
            }.ToAsyncEnumerable());

            var result = await _subject.SolveProblemAsync();

            result.Should().Be(175);
        }

        [Fact]
        public async Task SolveBonusProblemAsync_When1MaskInInput_ThenReturnsExceptedValue()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "mask = 000000000000000000000000000000X1001X",
                "mem[42] = 100"
            }.ToAsyncEnumerable());

            var result = await _subject.SolveBonusProblemAsync();

            result.Should().Be(400);
        }

        [Fact]
        public async Task SolveBonusProblemAsync_When2MasksInInput_ThenReturnsExceptedValue()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "mask = 000000000000000000000000000000X1001X",
                "mem[42] = 100",
                "mask = 00000000000000000000000000000000X0XX",
                "mem[26] = 1"
            }.ToAsyncEnumerable());

            var result = await _subject.SolveBonusProblemAsync();

            result.Should().Be(208);
        }
    }
}
