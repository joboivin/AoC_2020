using System.Collections.Generic;

namespace Day1Solver
{
    internal interface IInputProvider
    {
        IAsyncEnumerable<int> ProvideInputAsync();
    }
}
