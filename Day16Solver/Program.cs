using System;
using System.Threading.Tasks;

namespace Day16Solver
{
    internal class Program
    {
        internal static async Task Main(string[] args)
        {
            var solver = new Solver(new InputProvider(new RawInputProvider()), new TicketFieldPositionFinder());
            var solution = solver.SolveProblemAsync();
            var bonusSolution = solver.SolveBonusProblemAsync();

            Console.WriteLine($"Solution for Day 16 is {await solution}");
            Console.WriteLine($"Bonus solution for Day 16 is {await bonusSolution}");
        }
    }
}
