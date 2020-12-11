using System.Threading.Tasks;

namespace Day11Solver
{
    internal interface IInputProvider
    {
        Task<Ferry> ProvideInputAsync();
    }
}
