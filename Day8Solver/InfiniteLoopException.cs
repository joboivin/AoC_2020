using System;

namespace Day8Solver
{
    internal class InfiniteLoopException : Exception
    {
        public int CurrentAccumulator { get; }

        public InfiniteLoopException(int currentAccumulator)
        {
            CurrentAccumulator = currentAccumulator;
        }
    }
}
