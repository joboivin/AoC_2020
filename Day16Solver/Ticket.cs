using System;
using System.Collections.Generic;
using System.Linq;

namespace Day16Solver
{
    internal class Ticket
    {
        public Ticket(string ticketLine)
        {
            var values = ticketLine.Split(',');

            FieldsValue = values.Select(v => Convert.ToInt32(v)).ToList();
        }

        public IList<int> FieldsValue { get; }

        public IList<int> GetInvalidFields(IEnumerable<ITicketField> ticketFields)
        {
            return FieldsValue.Where(v => !ticketFields.Any(f => f.IsValid(v))).ToList();
        }
    }
}
