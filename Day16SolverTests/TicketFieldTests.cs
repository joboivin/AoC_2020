using Day16Solver;
using FluentAssertions;
using Xunit;

namespace Day16SolverTests
{
    public class TicketFieldTests
    {
        private readonly TicketField _subject;

        public TicketFieldTests()
        {
            _subject = new TicketField("class: 1-3 or 5-7");
        }

        [Fact]
        public void IsValid_WhenValueIsLessThanFirstMin_ThenFalse()
        {
            var result = _subject.IsValid(0);

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenValueIsFirstMin_ThenTrue()
        {
            var result = _subject.IsValid(1);

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_WhenValueIsBetweenFirstMinAndFirstMax_ThenTrue()
        {
            var result = _subject.IsValid(2);

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_WhenValueIsFirstMax_ThenTrue()
        {
            var result = _subject.IsValid(3);

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_WhenValueIsBetweenFirstMaxAndSecondMin_ThenFalse()
        {
            var result = _subject.IsValid(4);

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValid_WhenValueIsSecondMin_ThenTrue()
        {
            var result = _subject.IsValid(5);

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_WhenValueIsBetweenSecondMinAndSecondMax_ThenTrue()
        {
            var result = _subject.IsValid(6);

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_WhenValueIsSecondMax_ThenTrue()
        {
            var result = _subject.IsValid(7);

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValid_WhenValueIsHigherThanSecondMax_ThenFalse()
        {
            var result = _subject.IsValid(8);

            result.Should().BeFalse();
        }
    }
}
