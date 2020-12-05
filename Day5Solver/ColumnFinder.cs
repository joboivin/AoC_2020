namespace Day5Solver
{
    internal class ColumnFinder : Finder, IColumnFinder
    {
        public const int TotalNumberOfColumns = 8;
        public const int NumberOfCharsRepresetingColumnNumber = 3;
        public const int ColumnNumberRepresentationStartPosition = 7;
        public const char LowerHalf = 'L';
        public const char HigherHalf = 'R';

        public ColumnFinder()
            : base(ColumnNumberRepresentationStartPosition, NumberOfCharsRepresetingColumnNumber,
                LowerHalf, HigherHalf, TotalNumberOfColumns)
        {

        }

        public int FindColumnNumber(string seatNumber)
        {
            return base.FindNumber(seatNumber);
        }
    }
}