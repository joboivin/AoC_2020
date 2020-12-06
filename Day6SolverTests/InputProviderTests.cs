using Day6Solver;
using FluentAssertions;
using NSubstitute;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Day6SolverTests
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
        public async Task ProvideInput_When5GroupsInInput_ThenReturns5Groups()
        {
            SetupRawInputProvider();

            var result = await _subject.ProvideInputAsync();

            result.Should().HaveCount(5);
        }

        [Fact]
        public async Task ProvideInput_WhenUsingInputFromAoC_ThenAnswersCountForEachGroupIsOK()
        {
            SetupRawInputProvider();

            var result = (await _subject.ProvideInputAsync()).ToList();

            result[0].GetAnswersCount().Should().Be(3);
            result[1].GetAnswersCount().Should().Be(3);
            result[2].GetAnswersCount().Should().Be(3);
            result[3].GetAnswersCount().Should().Be(1);
            result[4].GetAnswersCount().Should().Be(1);
        }

        [Fact]
        public async Task ProvideInput_WhenUsingInputFromAoC_ThenBonusAnswersCountForEachGroupIsOK()
        {
            SetupRawInputProvider();

            var result = (await _subject.ProvideInputAsync()).ToList();

            result[0].GetAnswersCountForBonus().Should().Be(3);
            result[1].GetAnswersCountForBonus().Should().Be(0);
            result[2].GetAnswersCountForBonus().Should().Be(1);
            result[3].GetAnswersCountForBonus().Should().Be(1);
            result[4].GetAnswersCountForBonus().Should().Be(1);
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
