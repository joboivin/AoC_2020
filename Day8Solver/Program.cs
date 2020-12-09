﻿using System;
using System.Threading.Tasks;

namespace Day8Solver
{
    internal class Program
    {
        internal static async Task Main(string[] args)
        {
            var solver = new Solver(new RawInputProvider());
            var solution = solver.SolveProblemAsync();
            var bonusSolution = solver.SolveBonusProblemAsync();

            Console.WriteLine($"Solution for Day 8 is {await solution}");
            Console.WriteLine($"Bonus solution for Day 8 is {await bonusSolution}");
        }
    }
}
