using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day3Solver
{
    internal class Solver
    {
        private readonly IInputProvider _inputProvider;

        public Solver(IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }

        public async Task<int> SolveProblemAsync()
        {
            const int verticalProgression = 1;
            const int horizontalProgression = 3;

            var forest = await _inputProvider.ProvideInputAsync();

            return SolveProblemForSlope(horizontalProgression, verticalProgression, forest);
        }

        public async Task<int> SolveBonusProblemAsync()
        {
            var forest = await _inputProvider.ProvideInputAsync();
            var numberOfTreesBySlope = new List<Task<int>>
            {
                Task.Run(() => SolveProblemForSlope(1, 1, forest)),
                Task.Run(() => SolveProblemForSlope(3, 1, forest)),
                Task.Run(() => SolveProblemForSlope(5, 1, forest)),
                Task.Run(() => SolveProblemForSlope(7, 1, forest)),
                Task.Run(() => SolveProblemForSlope(1, 2, forest))
            };

            await Task.WhenAll(numberOfTreesBySlope);

            return numberOfTreesBySlope.Select(t => t.Result).Aggregate(1, (x, y) => x * y);
        }

        private int SolveProblemForSlope(int right, int down, Forest forest)
        {
            var x = 0;
            var y = 0;
            var outOfForest = false;
            var numberOfTrees = 0;

            while (!outOfForest)
            {
                try
                {
                    numberOfTrees += forest.IsOpenSquare(x, y) ? 0 : 1;
                    x += right;
                    y += down;
                }
                catch (OutOfForestException)
                {
                    outOfForest = true;
                }
            }

            return numberOfTrees;
        }
    }
}
