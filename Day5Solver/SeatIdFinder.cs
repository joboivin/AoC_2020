namespace Day5Solver
{
    internal class SeatIdFinder : ISeatIdFinder
    {
        private readonly IRowFinder _rowFinder;
        private readonly IColumnFinder _columnFinder;

        public SeatIdFinder(IRowFinder rowFinder, IColumnFinder columnFinder)
        {
            _rowFinder = rowFinder;
            _columnFinder = columnFinder;
        }

        public int FindSeatId(string seatNumber)
        {
            return _rowFinder.FindRowNumber(seatNumber) * 8 + _columnFinder.FindColumnNumber(seatNumber);
        }
    }
}