using System.Collections.Generic;
using Day16Solver;
using FluentAssertions;
using Xunit;

namespace Day16SolverTests
{
    public class TicketFieldPositionFinderTests
    {
        private readonly TicketFieldPositionFinder _subject = new TicketFieldPositionFinder();

        [Fact]
        public void FindFieldsPosition_WhenUsingInputFromAoC_ThenReturnsExpectedResult()
        {
            var input = SetupInput();

            var result = _subject.FindFieldsPosition(input.allTickets, input.ticketFields);

            result["row"].Should().Be(0);
            result["class"].Should().Be(1);
            result["seat"].Should().Be(2);
        }

        private (IList<Ticket> allTickets, IList<TicketField> ticketFields) SetupInput()
        {
            var allTickets = new List<Ticket>
            {
                new Ticket("11,12,13"),
                new Ticket("3,9,18"),
                new Ticket("15,1,5"),
                new Ticket("5,14,9")
            };

            var ticketFields = new List<TicketField>
            {
                new TicketField("class: 0-1 or 4-19"),
                new TicketField("row: 0-5 or 8-19"),
                new TicketField("seat: 0-13 or 16-19")
            };

            return (allTickets, ticketFields);
        }
    }
}
