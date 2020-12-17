using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day16Solver
{
    internal class InputProvider : IInputProvider
    {
        private readonly IRawInputProvider _rawInputProvider;

        public InputProvider(IRawInputProvider rawInputProvider)
        {
            _rawInputProvider = rawInputProvider;
        }

        public async Task<(IList<TicketField> ticketFields, Ticket myTicket, IList<Ticket> nearbyTickets)> ProvideInputAsync()
        {
            var input = await _rawInputProvider.ProvideRawInputAsync().ToListAsync();
            var (ticketFields, endOfFieldIndex) = ExtractTicketFields(input);
            var (myTicket, endOfMyTicketIndex) = ExtractMyTicket(input, endOfFieldIndex);
            var nearbyTickets = ExtractNearbyTickets(input, endOfMyTicketIndex);

            return (ticketFields, myTicket, nearbyTickets);
        }

        private (IList<TicketField> ticketFields, int index) ExtractTicketFields(IList<string> input)
        {
            var result = new List<TicketField>();

            var i = 0;

            while (input[i] != "")
            {
                result.Add(new TicketField(input[i]));
                i++;
            }

            return (result, i);
        }

        private (Ticket myTicket, int index) ExtractMyTicket(IList<string> input, int index)
        {
            const int myTicketIntroduction = 2;
            const int myTicketLength = 2;

            return (new Ticket(input[index + myTicketIntroduction]), index + myTicketIntroduction + myTicketLength);
        }

        private IList<Ticket> ExtractNearbyTickets(IList<string> input, int index)
        {
            const int nearbyTicketsIntroduction = 1;

            var result = new List<Ticket>();

            for (var i = index + nearbyTicketsIntroduction; i < input.Count; i++)
                result.Add(new Ticket(input[i]));

            return result;
        }
    }
}