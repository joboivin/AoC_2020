using Day13Solver;
using FluentAssertions;
using Xunit;

namespace Day13SolverTests
{
    public class BusTests
    {
        [Fact]
        public void MinutesBeforeNextBus_WhenNextBusIn1Minute_ThenReturns1()
        {
            var subject = new Bus(8);

            var result = subject.MinutesBeforeNextBus(7);

            result.Should().Be(1);
        }

        [Fact]
        public void MinutesBeforeNextBus_WhenNextBusIn5MinutesAndBusAlreadyMadeSomeLoops_ThenReturns5()
        {
            var subject = new Bus(8);

            var result = subject.MinutesBeforeNextBus(27);

            result.Should().Be(5);
        }

        [Fact]
        public void MinutesBeforeNextBus_WhenNextBusIsRightNow_ThenReturns0()
        {
            var subject = new Bus(8);

            var result = subject.MinutesBeforeNextBus(80);

            result.Should().Be(0);
        }
    }
}
