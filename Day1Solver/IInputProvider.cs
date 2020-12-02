using System.Collections.Generic;

namespace Day1Solver
{
    internal interface IInputProvider
    {
        IEnumerable<int> ProvideInput();
    }
}
