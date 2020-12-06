using System;
using System.Threading.Tasks;

namespace Day5Solver
{
    internal class Program
    {
        internal static async Task Main(string[] args)
        {
            var solver = new Solver(new SeatIdFinder(new RowFinder(), new ColumnFinder()), new RawInputProvider());
            var solution = solver.SolveProblemAsync();
            var bonusSolution = solver.SolveBonusProblemAsync();

            Console.WriteLine($"Solution for Day 5 is {await solution}");
            Console.WriteLine($"Bonus solution for Day 5 is {await bonusSolution}");
        }
    }
}
