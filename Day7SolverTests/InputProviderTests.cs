using Day7Solver;
using FluentAssertions;
using NSubstitute;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Day7SolverTests
{
    public class InputProviderTests
    {
        private readonly IRawInputProvider _rawInputProvider;

        private readonly InputProvider _subject;

        public InputProviderTests()
        {
            _rawInputProvider = Substitute.For<IRawInputProvider>();

            _subject = new InputProvider(_rawInputProvider);
        }

        [Fact]
        public async Task ProvideInputAsync_When1LineInInput_ThenReturns1Bag()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags."
            }.ToAsyncEnumerable());

            var result = await _subject.ProvideInputAsync();

            result.Should().HaveCount(1);
            result.Should().ContainKey("light red");
        }

        [Fact]
        public async Task ProvideInputAsync_When2LinesInInput_ThenReturns2Bags()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "faded blue bags contain no other bags."
            }.ToAsyncEnumerable());

            var result = await _subject.ProvideInputAsync();

            result.Should().HaveCount(2);
            result.Should().ContainKey("light red");
            result.Should().ContainKey("faded blue");
        }

        [Fact]
        public async Task ProvideInputAsync_When1LineInInputAndBagHasNoContent_ThenBagContentEmpty()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "faded blue bags contain no other bags."
            }.ToAsyncEnumerable());

            var result = await _subject.ProvideInputAsync();

            result["faded blue"].Content.Should().BeEmpty();
        }

        [Fact]
        public async Task ProvideInputAsync_When1LineInInputAndBagHas1Content_ThenBagContentIsOK()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "bright white bags contain 1 shiny gold bag."
            }.ToAsyncEnumerable());

            var result = await _subject.ProvideInputAsync();

            var bagContent = result["bright white"].Content;
            bagContent.Should().ContainSingle();
            bagContent.Should().Contain("shiny gold");
        }

        [Fact]
        public async Task ProvideInputAsync_When1LineInInputAndBagHas2Contents_ThenBagContentIsOK()
        {
            _rawInputProvider.ProvideRawInputAsync().Returns(new[]
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags."
            }.ToAsyncEnumerable());

            var result = await _subject.ProvideInputAsync();

            var bagContent = result["light red"].Content;
            bagContent.Should().HaveCount(2);
            bagContent.Should().Contain("bright white");
            bagContent.Should().Contain("muted yellow");
        }
    }
}
