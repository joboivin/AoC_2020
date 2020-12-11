using System.Collections.Generic;
using System.Linq;

namespace Day11Solver
{
    internal class Ferry
    {
        public const char Floor = '.';
        public const char EmptySeat = 'L';
        public const char OccupiedSeat = '#';

        public List<List<char>> SeatLayout { get; set; }

        public int OccupiedSeatsNearby(int row, int column)
        {
            var rowBeforeExists = row > 0;
            var rowAfterExists = row < SeatLayout.Count - 1;
            var columnBeforeExists = column > 0;
            var columnAfterExists = column < SeatLayout[0].Count - 1;
            var occupiedSeatsNearby = 0;

            if (rowBeforeExists)
                occupiedSeatsNearby += OccupiedSeatsNearbyInRow(row - 1, column, columnBeforeExists, columnAfterExists);

            if (rowAfterExists)
                occupiedSeatsNearby += OccupiedSeatsNearbyInRow(row + 1, column, columnBeforeExists, columnAfterExists);

            occupiedSeatsNearby += OccupiedSeatsNearbyInRow(row, column, columnBeforeExists, columnAfterExists);

            if (SeatLayout[row][column] == OccupiedSeat)
                occupiedSeatsNearby--;

            return occupiedSeatsNearby;
        }

        private int OccupiedSeatsNearbyInRow(int row, int column, bool columnBeforeExists, bool columnAfterExists)
        {
            var occupiedSeatsNearbyInRow = 0;

            if (columnBeforeExists && SeatLayout[row][column - 1] == OccupiedSeat)
                occupiedSeatsNearbyInRow++;

            if (columnAfterExists && SeatLayout[row][column + 1] == OccupiedSeat)
                occupiedSeatsNearbyInRow++;

            if (SeatLayout[row][column] == OccupiedSeat)
                occupiedSeatsNearbyInRow++;

            return occupiedSeatsNearbyInRow;
        }

        public int GetTotalOccupiedSeats()
        {
            return SeatLayout.SelectMany(x => x).Count(s => s == OccupiedSeat);
        }

        public int OccupiedSeatsVisible(int row, int column)
        {
            var rowBeforeExists = row > 0;
            var rowAfterExists = row < SeatLayout.Count - 1;
            var columnBeforeExists = column > 0;
            var columnAfterExists = column < SeatLayout[0].Count - 1;
            var isFirstVisibleSeatOccupiedResult = new List<bool>();

            if (rowBeforeExists)
            {
                if (columnBeforeExists)
                    isFirstVisibleSeatOccupiedResult.Add(IsFirstVisibleSeatOccupied(row, column, -1, -1));

                if (columnAfterExists)
                    isFirstVisibleSeatOccupiedResult.Add(IsFirstVisibleSeatOccupied(row, column, -1, +1));

                isFirstVisibleSeatOccupiedResult.Add(IsFirstVisibleSeatOccupied(row, column, -1, 0));
            }

            if (rowAfterExists)
            {
                if (columnBeforeExists)
                    isFirstVisibleSeatOccupiedResult.Add(IsFirstVisibleSeatOccupied(row, column, +1, -1));

                if (columnAfterExists)
                    isFirstVisibleSeatOccupiedResult.Add(IsFirstVisibleSeatOccupied(row, column, +1, +1));

                isFirstVisibleSeatOccupiedResult.Add(IsFirstVisibleSeatOccupied(row, column, +1, 0));
            }

            if (columnBeforeExists)
                isFirstVisibleSeatOccupiedResult.Add(IsFirstVisibleSeatOccupied(row, column, 0, -1));

            if (columnAfterExists)
                isFirstVisibleSeatOccupiedResult.Add(IsFirstVisibleSeatOccupied(row, column, 0, +1));

            return isFirstVisibleSeatOccupiedResult.Count(r => r);
        }

        private bool IsFirstVisibleSeatOccupied(int row, int column, int rowIncrement, int columnIncrement)
        {
            var x = row;
            var y = column;

            while (true)
            {
                x += rowIncrement;
                y += columnIncrement;

                if (x < 0 || x >= SeatLayout.Count || y < 0 || y >= SeatLayout[x].Count)
                    return false;

                if (SeatLayout[x][y] == OccupiedSeat)
                    return true;

                if (SeatLayout[x][y] == EmptySeat)
                    return false;
            }
        }
    }
}
