using System;
using System.Threading.Tasks;

namespace Day2Solver
{
    internal class Program
    {
        internal static async Task Main(string[] args)
        {
            var solver = new Solver(new InputProvider(new RawInputProvider()));

            Console.WriteLine($"Solution for Day 2 is {await solver.SolveProblemAsync()}");
        }
    }
}
