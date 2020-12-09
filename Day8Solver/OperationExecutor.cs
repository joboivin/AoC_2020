using System;
using System.Collections.Generic;

namespace Day8Solver
{
    internal class OperationExecutor
    {
        private readonly IList<string> _operations;

        public OperationExecutor(IList<string> operations)
        {
            _operations = operations;
        }

        public int Execute()
        {
            var state = new State();
            var operationsExecuted = new HashSet<int>();

            while (state.NextOperation < _operations.Count)
            {
                if (operationsExecuted.Contains(state.NextOperation))
                    throw new InfiniteLoopException(state.Accumulator);

                operationsExecuted.Add(state.NextOperation);
                ExecuteInstruction(_operations[state.NextOperation], state);
            }

            return state.Accumulator;
        }

        private static void ExecuteInstruction(string operation, State currentState)
        {
            const int operationLength = 3;

            var currentInstruction = operation.Substring(0, operationLength);

            if (currentInstruction == "jmp")
            {
                var jumpValue = Convert.ToInt32(operation[(operationLength + 1)..]);
                currentState.NextOperation += jumpValue;
            }
            else
            {
                currentState.NextOperation++;

                if (currentInstruction == "acc")
                {
                    var accValue = Convert.ToInt32(operation[(operationLength + 1)..]);
                    currentState.Accumulator += accValue;
                }
            }
        }

        private class State
        {
            public int Accumulator { get; set; } = 0;
            public int NextOperation { get; set; } = 0;
        }
    }
}
