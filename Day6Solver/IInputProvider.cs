using System.Collections.Generic;
using System.Threading.Tasks;

namespace Day6Solver
{
    internal interface IInputProvider
    {
        Task<IReadOnlyCollection<GroupAnswers>> ProvideInputAsync();
    }
}
