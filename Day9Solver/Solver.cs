using System;
using System.Linq;
using System.Threading.Tasks;

namespace Day9Solver
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
            var rawInput = _rawInputProvider.ProvideRawInputAsync().Select(x => Convert.ToInt64(x));
            var xMasReader = new XMasReader(await rawInput.ToListAsync());

            try
            {
                xMasReader.Execute();
            }
            catch (InvalidSequenceException e)
            {
                return e.InvalidNumber;
            }

            throw new Exception("The input isn't hackable.");
        }

        public async Task<long> SolveBonusProblemAsync()
        {
            var rawInput = await _rawInputProvider.ProvideRawInputAsync().Select(x => Convert.ToInt64(x)).ToListAsync();
            var xMasReader = new XMasReader(rawInput);

            try
            {
                xMasReader.Execute();
            }
            catch (InvalidSequenceException e)
            {
                var weaknessFinder = new WeaknessFinder(rawInput);
                return await weaknessFinder.FindWeaknessAsync(e.InvalidNumber);
            }

            throw new Exception("The input isn't hackable.");
        }
    }
}
