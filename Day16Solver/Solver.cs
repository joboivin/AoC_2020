using System.Linq;
using System.Threading.Tasks;

namespace Day16Solver
{
    internal class Solver
    {
        private readonly IInputProvider _inputProvider;
        private readonly ITicketFieldPositionFinder _ticketFieldPositionFinder;

        public Solver(IInputProvider inputProvider, ITicketFieldPositionFinder ticketFieldPositionFinder)
        {
            _inputProvider = inputProvider;
            _ticketFieldPositionFinder = ticketFieldPositionFinder;
        }

        public async Task<int> SolveProblemAsync()
        {
            var (ticketFields, _, nearbyTickets) = await _inputProvider.ProvideInputAsync();

            return nearbyTickets.SelectMany(t => t.GetInvalidFields(ticketFields)).Sum();
        }

        public async Task<long> SolveBonusProblemAsync()
        {
            var (ticketFields, myTicket, nearbyTickets) = await _inputProvider.ProvideInputAsync();
            var validTickets = nearbyTickets.Where(t => !t.GetInvalidFields(ticketFields).Any());
            var fieldsPositions = _ticketFieldPositionFinder.FindFieldsPosition(validTickets.Concat(new[] { myTicket }).ToList(), ticketFields);
            var departureFields = ticketFields.Where(f => f.Name.StartsWith("departure"));

            return departureFields.Aggregate(1L, (current, departureField) => current * myTicket.FieldsValue[fieldsPositions[departureField.Name]]);
        }
    }
}
