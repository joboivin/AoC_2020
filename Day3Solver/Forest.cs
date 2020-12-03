using System.Collections.Generic;

namespace Day3Solver
{
    internal class Forest
    {
        public const char OpenSquare = '.';
        public const char Tree = '#';

        public List<List<char>> VisibleForest { get; set; }
        public int Visibility => VisibleForest[0].Count;

        public bool IsOpenSquare(int x, int y)
        {
            if (y >= VisibleForest.Count)
                throw new OutOfForestException();

            return VisibleForest[y][x % Visibility] == OpenSquare;
        }
    }
}
