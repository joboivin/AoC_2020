using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day3Solver
{
    internal class InputProvider : IInputProvider
    {
        private readonly IRawInputProvider _rawInputProvider;

        public InputProvider(IRawInputProvider rawInputProvider)
        {
            _rawInputProvider = rawInputProvider;
        }

        public async Task<Forest> ProvideInputAsync()
        {
            var forest = new Forest { VisibleForest = new List<List<char>>() };

            await foreach (var input in _rawInputProvider.ProvideRawInput())
                forest.VisibleForest.Add(input.ToCharArray().ToList());

            return forest;
        }
    }
}