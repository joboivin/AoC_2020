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

        public async Task<int> SolveBonusProblemAsync()
        {
            var allSeatIds = await _rawInputProvider.ProvideRawInputAsync().Select(input => _seatIdFinder.FindSeatId(input)).OrderBy(id => id).ToListAsync();

            var seatId = allSeatIds[0];

            for (var i = 1; i < allSeatIds.Count; i++)
            {
                if (allSeatIds[i] - seatId != 1)
                {
                    seatId++;
                    break;
                }

                seatId = allSeatIds[i];
            }

            return seatId;
        }
    }
}
