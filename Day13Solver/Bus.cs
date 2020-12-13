namespace Day13Solver
{
    internal class Bus
    {
        public Bus(int id)
        {
            Id = id;
        }

        public int Id { get; }

        public long MinutesBeforeNextBus(long currentTimestamp)
        {
            return (Id - currentTimestamp % Id) % Id;
        }
    }
}
