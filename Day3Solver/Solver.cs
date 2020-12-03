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
            var x = 0;
            var y = 0;
            var outOfForest = false;
            var numberOfTrees = 0;

            while (!outOfForest)
            {
                try
                {
                    numberOfTrees += forest.IsOpenSquare(x, y) ? 0 : 1;
                    x += horizontalProgression;
                    y += verticalProgression;
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
