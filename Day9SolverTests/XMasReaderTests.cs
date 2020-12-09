using System;
using Day9Solver;
using FluentAssertions;
using Xunit;

namespace Day9SolverTests
{
    public class XMasReaderTests
    {
        [Fact]
        public void Execute_WhenPreambleIs5AndOneNumberInListIsNotTheSumOfThePrevious5_ThenInvalidSequenceException()
        {
            var numbers = new long[]
            {
                35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117,
                150, 182, 127, 219, 299, 277, 309, 576
            };
            var subject = new XMasReader(numbers, 5);

            var action = new Action(() => subject.Execute());

            action.Should().Throw<InvalidSequenceException>().Which.InvalidNumber.Should().Be(127);
        }

        [Fact]
        public void Execute_WhenPreambleIs5AndAllNumbersInListAreTheSumOfThePrevious5_ThenNoInvalidSequenceException()
        {
            var numbers = new long[]
            {
                35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117,
                150, 182
            };
            var subject = new XMasReader(numbers, 5);

            var action = new Action(() => subject.Execute());

            action.Should().NotThrow<InvalidSequenceException>();
        }
    }
}
