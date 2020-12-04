using System.Collections.Generic;
using System.Threading.Tasks;

namespace Day4Solver
{
    internal interface IInputProvider
    {
        Task<IReadOnlyCollection<Passport>> ProvideInputAsync();
    }
}
