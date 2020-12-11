using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day11Solver
{
    internal class InputProvider : IInputProvider
    {
        private readonly IRawInputProvider _rawInputProvider;

        public InputProvider(IRawInputProvider rawInputProvider)
        {
            _rawInputProvider = rawInputProvider;
        }

        public async Task<Ferry> ProvideInputAsync()
        {
            var forest = new Ferry { SeatLayout = new List<List<char>>() };

            await foreach (var input in _rawInputProvider.ProvideRawInputAsync())
                forest.SeatLayout.Add(input.ToCharArray().ToList());

            return forest;
        }
    }
}