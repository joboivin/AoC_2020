using System;
using System.Linq;
using System.Threading.Tasks;

namespace Day11Solver
{
    internal class Solver
    {
        private readonly IInputProvider _inputProvider;
        private readonly IEntirelyPredictableHumanBehavior _entirelyPredictableHumanBehavior;

        public Solver(IInputProvider inputProvider, IEntirelyPredictableHumanBehavior entirelyPredictableHumanBehavior)
        {
            _inputProvider = inputProvider;
            _entirelyPredictableHumanBehavior = entirelyPredictableHumanBehavior;
        }

        public Task<int> SolveProblemAsync()
        {
            return SolveAsync((behavior, ferry) => behavior.ApplySimpleSetOfRules(ferry));
        }

        private async Task<int> SolveAsync(Func<IEntirelyPredictableHumanBehavior, Ferry, Ferry> whichRulesToApply)
        {
            var ferry = await _inputProvider.ProvideInputAsync();
            var ferryLayoutChanged = false;

            do
            {
                var newFerry = whichRulesToApply(_entirelyPredictableHumanBehavior, ferry);

                ferryLayoutChanged = new string(ferry.SeatLayout.SelectMany(x => x).ToArray()) !=
                                     new string(newFerry.SeatLayout.SelectMany(x => x).ToArray());

                ferry = newFerry;
            } while (ferryLayoutChanged);

            return ferry.GetTotalOccupiedSeats();
        }

        public Task<int> SolveBonusProblemAsync()
        {
            return SolveAsync((behavior, ferry) => behavior.ApplyMoreComplexButStillFairlySimpleSetOfRules(ferry));
        }
    }
}
