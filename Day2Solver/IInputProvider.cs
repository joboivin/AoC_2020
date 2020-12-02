using System.Collections.Generic;

namespace Day2Solver
{
    internal interface IInputProvider
    {
        IAsyncEnumerable<PasswordEntry> ProvideInputAsync();
    }
}
