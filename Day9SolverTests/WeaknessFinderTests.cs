using System.Threading.Tasks;
using Day9Solver;
using FluentAssertions;
using Xunit;

namespace Day9SolverTests
{
    public class WeaknessFinderTests
    {
        [Fact]
        public async Task FindWeaknessAsync_WhenUsingInputFromAoC_ThenReturns62()
        {
            var numbers = new long[]
            {
                35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117,
                150, 182, 127, 219, 299, 277, 309, 576
            };
            var subject = new WeaknessFinder(numbers);

            var result = await subject.FindWeaknessAsync(127);

            result.Should().Be(62);
        }
    }
}
