using System.Collections.Generic;

namespace Day12Solver
{
    internal interface IRawInputProvider
    {
        IAsyncEnumerable<string> ProvideRawInputAsync();
    }
}
