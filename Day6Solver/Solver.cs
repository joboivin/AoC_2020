using System.Linq;
using System.Threading.Tasks;

namespace Day6Solver
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
            var allGroupsInPlane = await _inputProvider.ProvideInputAsync();

            return allGroupsInPlane.Select(g => g.GetAnswersCount()).Sum();
        }

        public async Task<int> SolveBonusProblemAsync()
        {
            var allGroupsInPlane = await _inputProvider.ProvideInputAsync();

            return allGroupsInPlane.Select(g => g.GetAnswersCountForBonus()).Sum();
        }
    }
}
