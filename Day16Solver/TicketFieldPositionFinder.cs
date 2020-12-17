using System.Collections.Generic;
using System.Linq;

namespace Day16Solver
{
    internal class TicketFieldPositionFinder : ITicketFieldPositionFinder
    {
        public Dictionary<string, int> FindFieldsPosition(IList<Ticket> allTickets, IList<TicketField> ticketFields)
        {
            var potentialPositions = new Dictionary<string, List<int>>();

            foreach (var ticketField in ticketFields)
            {
                for (var i = 0; i < ticketFields.Count; i++)
                {
                    if (allTickets.Select(t => t.FieldsValue[i]).All(v => ticketField.IsValid(v)))
                    {
                        if (!potentialPositions.ContainsKey(ticketField.Name))
                            potentialPositions.Add(ticketField.Name, new List<int>());

                        potentialPositions[ticketField.Name].Add(i);
                    }
                }
            }

            return DetermineFieldsPosition(potentialPositions);
        }

        private Dictionary<string, int> DetermineFieldsPosition(Dictionary<string, List<int>> potentialPositions)
        {
            var result = new Dictionary<string, int>();

            while (potentialPositions.Count != result.Count)
            {
                foreach (var potentialPosition in potentialPositions.Where(p => !result.ContainsKey(p.Key)))
                {
                    if (potentialPosition.Value.Count == 1)
                    {
                        var officialPosition = potentialPosition.Value.Single();
                        result.Add(potentialPosition.Key, officialPosition);

                        foreach (var potentialPositionToChange in potentialPositions)
                        {
                            if (potentialPositionToChange.Key != potentialPosition.Key &&
                                potentialPositionToChange.Value.Contains(officialPosition))
                            {
                                potentialPositionToChange.Value.Remove(officialPosition);
                            }
                        }
                    }

                }
            }

            return result;
        }
    }
}