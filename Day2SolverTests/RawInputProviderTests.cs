using Day2Solver;
using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Day2SolverTests
{
    public class RawInputProviderTests
    {
        [Fact]
        public async Task ProvideRawInputAsync_ThenReturns1000Entries()
        {
            var subject = new RawInputProvider();

            var result = subject.ProvideRawInputAsync();

            var count = await result.CountAsync();
            count.Should().Be(1000, "there are 1000 lines in the input file");
        }
    }
}
