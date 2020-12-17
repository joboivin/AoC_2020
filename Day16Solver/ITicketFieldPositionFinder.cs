using System.Collections.Generic;

namespace Day16Solver
{
    internal interface ITicketFieldPositionFinder
    {
        Dictionary<string, int> FindFieldsPosition(IList<Ticket> allTickets, IList<TicketField> ticketFields);
    }
}
