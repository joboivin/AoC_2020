using System.Threading.Tasks;

namespace Day3Solver
{
    internal interface IInputProvider
    {
        Task<Forest> ProvideInputAsync();
    }
}
