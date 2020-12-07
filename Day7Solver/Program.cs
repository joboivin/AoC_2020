﻿using System;
using System.Threading.Tasks;

namespace Day7Solver
{
    internal class Program
    {
        internal static async Task Main(string[] args)
        {
            var solver = new Solver(new InputProvider(new RawInputProvider()));
            var solution = solver.SolveProblemAsync();
            var bonusSolution = solver.SolveBonusProblemAsync();

            Console.WriteLine($"Solution for Day 7 is {await solution}");
            Console.WriteLine($"Bonus solution for Day 7 is {await bonusSolution}");
        }
    }
}
