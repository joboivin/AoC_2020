namespace Day5Solver
{
    internal class RowFinder : Finder, IRowFinder
    {
        public const int TotalNumberOfRows = 128;
        public const int NumberOfCharsRepresetingRowNumber = 7;
        public const int RowNumberRepresentationStartPosition = 0;
        public const char LowerHalf = 'F';
        public const char HigherHalf = 'B';

        public RowFinder()
            : base(RowNumberRepresentationStartPosition, NumberOfCharsRepresetingRowNumber,
                LowerHalf, HigherHalf, TotalNumberOfRows)
        {

        }

        public int FindRowNumber(string seatNumber)
        {
            return base.FindNumber(seatNumber);
        }
    }
}