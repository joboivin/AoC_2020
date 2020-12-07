using System.Collections.Generic;

namespace Day7Solver
{
    internal interface IRawInputProvider
    {
        IAsyncEnumerable<string> ProvideRawInputAsync();
    }
}
