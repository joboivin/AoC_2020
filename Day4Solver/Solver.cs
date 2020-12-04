using System.Linq;
using System.Threading.Tasks;

namespace Day4Solver
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
            var passports = await _inputProvider.ProvideInputAsync();

            return passports.Count(p => p.IsValid());
        }
    }
}
