using System.Collections.Generic;
using System.Threading.Tasks;

namespace Day7Solver
{
    internal interface IInputProvider
    {
        Task<Dictionary<string, Bag>> ProvideInputAsync();
    }
}
