using System;

namespace Day1Solver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solver = new Solver(new InputProvider());
            Console.WriteLine($"Solution for Day 1 is {solver.SolveProblem()}");
            Console.WriteLine($"Bonus solution for Day 1 is {solver.SolveBonusProblem()}");
        }
    }
}
