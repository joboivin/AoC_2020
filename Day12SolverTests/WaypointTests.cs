using Day12Solver;
using FluentAssertions;
using Xunit;

namespace Day12SolverTests
{
    public class WaypointTests
    {
        [Fact]
        public void Waypoint_ThenInitialValuesAreOK()
        {
            var subject = new Waypoint();

            subject.RelativeLongitude.Should().Be(10);
            subject.RelativeLatitude.Should().Be(1);
        }
    }
}
