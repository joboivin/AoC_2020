using Day1Solver;
using FluentAssertions;
using Xunit;

namespace Day1SolverTests
{
    public class InputProviderTests
    {
        [Fact]
        public void ProvideInput_ThenReturns200Numbers()
        {
            var subject = new InputProvider();

            var result = subject.ProvideInput();

            result.Should().HaveCount(200, "there are 200 lines in the input file");
        }
    }
}
