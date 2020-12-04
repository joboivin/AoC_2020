using System.Collections.Generic;

namespace Day4Solver
{
    internal interface IRawInputProvider
    {
        IAsyncEnumerable<string> ProvideRawInputAsync();
    }
}
