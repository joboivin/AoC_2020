using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Day15Solver
{
    internal class Program
    {
        internal static async Task Main(string[] args)
        {
            var solver = new Solver(new List<int> { 9, 3, 1, 0, 8, 4 });
            var solution = solver.SolveProblem();
            var bonusSolution = solver.SolveBonusProblem();

            Console.WriteLine($"Solution for Day 15 is {solution}");
            Console.WriteLine($"Bonus solution for Day 15 is {bonusSolution}");
        }
    }
}
