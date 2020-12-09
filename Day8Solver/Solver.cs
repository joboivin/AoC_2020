using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day8Solver
{
    internal class Solver
    {
        private readonly IRawInputProvider _rawInputProvider;

        public Solver(IRawInputProvider rawInputProvider)
        {
            _rawInputProvider = rawInputProvider;
        }

        public async Task<int> SolveProblemAsync()
        {
            var executor = new OperationExecutor(await _rawInputProvider.ProvideRawInputAsync().ToListAsync());

            try
            {
                executor.Execute();
            }
            catch (InfiniteLoopException e)
            {
                return e.CurrentAccumulator;
            }

            throw new Exception("Program doesn't seem to have an infinite loop.");
        }

        public async Task<int> SolveBonusProblemAsync()
        {
            var allOperations = await _rawInputProvider.ProvideRawInputAsync().ToListAsync();
            var unCorruptionAttempts = new List<Task<int?>>();

            for (var i = 0; i < allOperations.Count; i++)
            {
                if (allOperations[i].StartsWith("acc"))
                    continue;

                var operationsCopy = new List<string>(allOperations);

                if (allOperations[i].StartsWith("nop"))
                    operationsCopy[i] = operationsCopy[i].Replace("nop", "jmp");
                else
                    operationsCopy[i] = operationsCopy[i].Replace("jmp", "nop");

                var executor = new OperationExecutor(operationsCopy);
                unCorruptionAttempts.Add(TryToExecuteUncorruptedProgram(new Task<int>(executor.Execute)));
            }

            await Task.WhenAll(unCorruptionAttempts);

            return unCorruptionAttempts.Single(t => t.Result.HasValue).Result.Value;
        }

        private async Task<int?> TryToExecuteUncorruptedProgram(Task<int> uncorruptionAttempt)
        {
            try
            {
                uncorruptionAttempt.Start();
                return await uncorruptionAttempt;
            }
            catch (InfiniteLoopException)
            {
                return null;
            }
        }
    }
}
