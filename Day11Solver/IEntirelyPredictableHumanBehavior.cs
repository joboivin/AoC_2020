namespace Day11Solver
{
    internal interface IEntirelyPredictableHumanBehavior
    {
        Ferry ApplySimpleSetOfRules(Ferry initialFerry);
        Ferry ApplyMoreComplexButStillFairlySimpleSetOfRules(Ferry initialFerry);
    }
}