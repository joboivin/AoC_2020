using System.Collections.Generic;
using System.Threading.Tasks;

namespace Day16Solver
{
    internal interface IInputProvider
    {
        Task<(IList<TicketField> ticketFields, Ticket myTicket, IList<Ticket> nearbyTickets)> ProvideInputAsync();
    }
}
