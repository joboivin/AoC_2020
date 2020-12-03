using System.Collections.Generic;

namespace Day3Solver
{
    internal interface IRawInputProvider
    {
        IAsyncEnumerable<string> ProvideRawInput();
    }
}
