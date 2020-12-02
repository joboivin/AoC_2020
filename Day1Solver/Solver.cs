﻿using System;
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
                {
                    var potentialSolution = TryToResolve(input[i], input[j]);

                    if (potentialSolution.HasValue)
                        return potentialSolution.Value;
                }

            throw new Exception("Cannont find the two magic numbers");
        }

        public int SolveBonusProblem()
        {
            var input = _inputProvider.ProvideInput().ToList();

            for (var i = 0; i < input.Count; i++)
                for (var j = i + 1; j < input.Count; j++)
                    for (var k = j + 1; k < input.Count; k++)
                    {
                        var potentialSolution = TryToResolve(input[i], input[j], input[k]);

                        if (potentialSolution.HasValue)
                            return potentialSolution.Value;
                    }

            throw new Exception("Cannont find the three magic numbers");
        }

        private static int? TryToResolve(params int[] candidateNumbers)
        {
            if (candidateNumbers.Sum() == SumRequired)
                return candidateNumbers.Aggregate(1, (x, y) => x * y);

            return null;
        }
    }
}
