using System;
using System.Threading.Tasks;

namespace Day12Solver
{
    internal class Solver
    {
        private readonly IRawInputProvider _rawInputProvider;

        public Solver(IRawInputProvider rawInputProvider)
        {
            _rawInputProvider = rawInputProvider;
        }

        public Task<int> SolveProblemAsync()
        {
            return SolveAsync((ferry, command) => ferry.Move(command));
        }

        private async Task<int> SolveAsync(Action<Ferry, string> whatToDoWithFerry)
        {
            var allCommands = _rawInputProvider.ProvideRawInputAsync();
            var ferry = new Ferry();

            await foreach (var command in allCommands)
                whatToDoWithFerry(ferry, command);

            return ferry.ManhattanDistance;
        }

        public Task<int> SolveBonusProblemAsync()
        {
            return SolveAsync((ferry, command) => ferry.MoveAccordingToInstructionManual(command));
        }
    }
}
