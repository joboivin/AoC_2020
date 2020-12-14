using System.Collections.Generic;

namespace Day14Solver
{
    internal interface IRawInputProvider
    {
        IAsyncEnumerable<string> ProvideRawInputAsync();
    }
}
