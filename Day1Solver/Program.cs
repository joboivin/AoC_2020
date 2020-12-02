using System;
using System.Threading.Tasks;

namespace Day1Solver
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var solver = new Solver(new InputProvider());
            var solution = solver.SolveProblemAsync();
            var bonusSolution = solver.SolveBonusProblemAsync();

            Console.WriteLine($"Solution for Day 1 is {await solution}");
            Console.WriteLine($"Bonus solution for Day 1 is {await bonusSolution}");
        }
    }
}
