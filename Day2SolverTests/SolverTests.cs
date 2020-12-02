using Day2Solver;
using FluentAssertions;
using NSubstitute;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Day2SolverTests
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
        public async Task SolveProblem_WhenInputHas0ValidElementAnd1InvalidElement_ThenReturns1()
        {
            var invalidEntry = Substitute.For<PasswordEntry>();
            invalidEntry.IsValid.Returns(false);
            _inputProvider.ProvideInputAsync().Returns(new[] { invalidEntry }.ToAsyncEnumerable());

            var result = await _subject.SolveProblemAsync();

            result.Should().Be(1);
        }

        [Fact]
        public async Task SolveProblem_WhenInputHas2ValidElementsAnd1InvalidElement_ThenReturns1()
        {
            var invalidEntry = Substitute.For<PasswordEntry>();
            invalidEntry.IsValid.Returns(false);
            var validEntry1 = Substitute.For<PasswordEntry>();
            validEntry1.IsValid.Returns(true);
            var validEntry2 = Substitute.For<PasswordEntry>();
            validEntry2.IsValid.Returns(true);
            _inputProvider.ProvideInputAsync().Returns(new[] { validEntry1, invalidEntry, validEntry2 }.ToAsyncEnumerable());

            var result = await _subject.SolveProblemAsync();

            result.Should().Be(1);
        }

        [Fact]
        public async Task SolveProblem_WhenInputHas1ValidElementAnd2InvalidElements_ThenReturns2()
        {
            var invalidEntry1 = Substitute.For<PasswordEntry>();
            invalidEntry1.IsValid.Returns(false);
            var invalidEntry2 = Substitute.For<PasswordEntry>();
            invalidEntry2.IsValid.Returns(false);
            var validEntry = Substitute.For<PasswordEntry>();
            validEntry.IsValid.Returns(true);
            _inputProvider.ProvideInputAsync().Returns(new[] { invalidEntry2, invalidEntry1, validEntry }.ToAsyncEnumerable());

            var result = await _subject.SolveProblemAsync();

            result.Should().Be(2);
        }
    }
}
