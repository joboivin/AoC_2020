using System.Linq;
using System.Threading.Tasks;

namespace Day2Solver
{
    internal class Solver
    {
        private readonly IInputProvider _inputProvider;

        public Solver(IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }

        public ValueTask<int> SolveProblemAsync()
        {
            var input = _inputProvider.ProvideInputAsync();

            return input.CountAsync(p => !p.IsValid);
        }
    }
}
