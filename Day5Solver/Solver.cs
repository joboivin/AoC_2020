using System.Linq;
using System.Threading.Tasks;

namespace Day5Solver
{
    internal class Solver
    {
        private readonly ISeatIdFinder _seatIdFinder;
        private readonly IRawInputProvider _rawInputProvider;

        public Solver(ISeatIdFinder seatIdFinder, IRawInputProvider rawInputProvider)
        {
            _seatIdFinder = seatIdFinder;
            _rawInputProvider = rawInputProvider;
        }

        public Task<int> SolveProblemAsync()
        {
            return _rawInputProvider.ProvideRawInputAsync().Select(input => _seatIdFinder.FindSeatId(input)).MaxAsync().AsTask();
        }
    }
}
