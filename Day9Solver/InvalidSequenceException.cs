namespace Day9Solver
{
    internal class InvalidSequenceException : System.Exception
    {
        public long InvalidNumber { get; }

        public InvalidSequenceException(long invalidNumber)
        {
            InvalidNumber = invalidNumber;
        }
    }
}
