using System.Collections.Generic;

namespace Day13Solver
{
    internal interface IRawInputProvider
    {
        IAsyncEnumerable<string> ProvideRawInputAsync();
    }
}
