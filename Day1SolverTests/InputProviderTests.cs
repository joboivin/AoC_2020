using System.Linq;
using System.Threading.Tasks;
using Day1Solver;
using FluentAssertions;
using Xunit;

namespace Day1SolverTests
{
    public class InputProviderTests
    {
        [Fact]
        public async Task ProvideInputAsync_ThenReturns200Numbers()
        {
            var subject = new InputProvider();

            var result = subject.ProvideInputAsync();

            var count = await result.CountAsync();
            count.Should().Be(200, "there are 200 lines in the input file");
        }
    }
}
