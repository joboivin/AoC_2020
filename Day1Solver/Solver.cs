using System;
using System.Linq;

namespace Day1Solver
{
    internal class Solver
    {
        private const int SumRequired = 2020;
        private readonly IInputProvider _inputProvider;

        public Solver(IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }

        public int SolveProblem()
        {
            var input = _inputProvider.ProvideInput().ToList();

            for (var i = 0; i < input.Count; i++)
                for (var j = i + 1; j < input.Count; j++)
                    if (input[i] + input[j] == SumRequired)
                        return input[i] * input[j];

            throw new Exception("Cannont find the two magic numbers");
        }
    }
}
