using System;
using System.Threading.Tasks;

namespace Day11Solver
{
    internal class Program
    {
        internal static async Task Main(string[] args)
        {
            var solver = new Solver(new InputProvider(new RawInputProvider()), new EntirelyPredictableHumanBehavior());
            var solution = solver.SolveProblemAsync();
            var bonusSolution = solver.SolveBonusProblemAsync();

            Console.WriteLine($"Solution for Day 11 is {await solution}");
            Console.WriteLine($"Bonus solution for Day 11 is {await bonusSolution}");
        }
    }
}
