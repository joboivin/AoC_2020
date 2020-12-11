using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day10Solver
{
    internal class Solver
    {
        private readonly IRawInputProvider _rawInputProvider;

        public Solver(IRawInputProvider rawInputProvider)
        {
            _rawInputProvider = rawInputProvider;
        }

        public async Task<int> SolveProblemAsync()
        {
            var allInputs = await ProvideAllInputs();

            var countOf1Difference = 0;
            var countOf3Difference = 0;

            for (var i = 1; i < allInputs.Count; i++)
            {
                var joltDifference = allInputs[i] - allInputs[i - 1];

                if (joltDifference == 1)
                    countOf1Difference++;
                else if (joltDifference == 3)
                    countOf3Difference++;
            }

            return countOf3Difference * countOf1Difference;
        }

        public async Task<long> SolveBonusProblemAsync()
        {
            var allInputs = await ProvideAllInputs();
            var totalCombinationsAvailable = new Dictionary<int, long> { { allInputs.Count - 1, 1 } };

            for (var i = allInputs.Count - 2; i >= 0; i--)
            {
                var totalCombinations = 0L;

                for (var j = 1; j <= 3; j++)
                {
                    if (i + j < allInputs.Count && allInputs[i + j] - allInputs[i] <= 3)
                        totalCombinations += totalCombinationsAvailable[i + j];
                }

                totalCombinationsAvailable.Add(i, totalCombinations);
            }

            return totalCombinationsAvailable[0];
        }

        private async Task<IList<int>> ProvideAllInputs()
        {
            var input = _rawInputProvider.ProvideRawInputAsync().Select(x => Convert.ToInt32(x)).OrderBy(x => x);
            var inputWithExtraValues = await new[] { 0 }.ToAsyncEnumerable().Concat(input).ToListAsync();
            inputWithExtraValues.Add(inputWithExtraValues[^1] + 3);

            return inputWithExtraValues;
        }
    }
}
