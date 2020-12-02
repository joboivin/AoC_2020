using Day2Solver;
using FluentAssertions;
using NSubstitute;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Day2SolverTests
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
        public async Task ProvideInputAsync_When1RawInputAndRawInputIsValid_ThenReturns1PasswordEntry()
        {
            var rawInput = "1-3 a: ddd";
            _rawInputProvider.ProvideRawInputAsync().Returns(new[] { rawInput }.ToAsyncEnumerable());

            var result = _subject.ProvideInputAsync();

            var passwordEntry = await result.SingleAsync();
            passwordEntry.MinOccurence.Should().Be(1);
            passwordEntry.MaxOccurence.Should().Be(3);
            passwordEntry.MandatoryChar.Should().Be('a');
            passwordEntry.Password.Should().Be("ddd");
        }

        [Fact]
        public async Task ProvideInputAsync_When1RawInputAndRawInputIsValidAndOccurencesHave2Digits_ThenReturns1PasswordEntry()
        {
            var rawInput = "10-13 a: ddd";
            _rawInputProvider.ProvideRawInputAsync().Returns(new[] { rawInput }.ToAsyncEnumerable());

            var result = _subject.ProvideInputAsync();

            var passwordEntry = await result.SingleAsync();
            passwordEntry.MinOccurence.Should().Be(10);
            passwordEntry.MaxOccurence.Should().Be(13);
            passwordEntry.MandatoryChar.Should().Be('a');
            passwordEntry.Password.Should().Be("ddd");
        }

        [Fact]
        public async Task ProvideInputAsync_When2RawInputsAndBothInputsAreValid_ThenReturns2PasswordEntries()
        {
            var rawInput1 = "1-3 a: ddd";
            var rawInput2 = "10-13 a: aassddddffffrtrrrrrddd";
            _rawInputProvider.ProvideRawInputAsync().Returns(new[] { rawInput1, rawInput2 }.ToAsyncEnumerable());

            var result = await _subject.ProvideInputAsync().ToListAsync();

            result.Should().HaveCount(2);
        }

        [Fact]
        public void ProvideInputAsync_When1RawInputAndInputIsInvalid_ThenThrows()
        {
            var rawInput = "1-3 a:ddd";
            _rawInputProvider.ProvideRawInputAsync().Returns(new[] { rawInput }.ToAsyncEnumerable());

            var action = new Func<Task>(async () => await _subject.ProvideInputAsync().ToListAsync());

            action.Should().Throw<Exception>();
        }
    }
}
