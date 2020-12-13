using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day13Solver
{
    internal class Solver
    {
        private readonly IRawInputProvider _rawInputProvider;

        public Solver(IRawInputProvider rawInputProvider)
        {
            _rawInputProvider = rawInputProvider;
        }

        public async Task<long> SolveProblemAsync()
        {
            var input = await _rawInputProvider.ProvideRawInputAsync().ToListAsync();

            var currentTimestamp = Convert.ToInt32(input[0]);
            var allBuses = ExtractBuses(input[1]).Select((tuple => tuple.bus));
            var (busToTake, minutesBefofeNextBus) = allBuses.Select(b => new Tuple<Bus, long>(b, b.MinutesBeforeNextBus(currentTimestamp)))
                .OrderBy(t => t.Item2).First();

            return busToTake.Id * minutesBefofeNextBus;
        }

        private static IEnumerable<(Bus bus, int offset)> ExtractBuses(string input)
        {
            const char separator = ',';
            const string outOfServiceBus = "x";

            var potentialBuses = input.Split(separator);

            for (var i = 0; i < potentialBuses.Length; i++)
            {
                if (potentialBuses[i] != outOfServiceBus)
                    yield return (new Bus(Convert.ToInt32(potentialBuses[i])), i);
            }
        }

        public async Task<long> SolveBonusProblemAsync()
        {
            var input = await _rawInputProvider.ProvideRawInputAsync().ToListAsync();
            var allBuses = ExtractBuses(input[1]);
            var minimumTimestamp = 0L;
            var incrementor = 1L;

            foreach (var (bus, offset) in allBuses)
            {
                while (bus.MinutesBeforeNextBus(minimumTimestamp + offset) != 0)
                {
                    minimumTimestamp += incrementor;
                }

                incrementor *= bus.Id;
            }

            return minimumTimestamp;
        }
    }
}
