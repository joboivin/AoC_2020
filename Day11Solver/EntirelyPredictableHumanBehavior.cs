using System;
using System.Collections.Generic;

namespace Day11Solver
{
    internal class EntirelyPredictableHumanBehavior : IEntirelyPredictableHumanBehavior
    {
        public Ferry ApplySimpleSetOfRules(Ferry initialFerry)
        {
            const int maximumNearbyOccupiedSeatsTolerance = 3;

            return ApplyRules(initialFerry, maximumNearbyOccupiedSeatsTolerance,
                (ferry, row, column) => ferry.OccupiedSeatsNearby(row, column));
        }

        private Ferry ApplyRules(Ferry initialFerry, int maximumNearbyOccupiedSeatsTolerance, Func<Ferry, int, int, int> howToDetermineNearbyOccupiedSeats)
        {
            var ferryAfterMovements = new Ferry { SeatLayout = new List<List<char>>() };
            var oldSeatLayout = initialFerry.SeatLayout;

            for (var i = 0; i < oldSeatLayout.Count; i++)
            {
                var newRow = new List<char>();

                for (var j = 0; j < oldSeatLayout[i].Count; j++)
                {
                    if (oldSeatLayout[i][j] == Ferry.Floor)
                        newRow.Add(Ferry.Floor);
                    else if (oldSeatLayout[i][j] == Ferry.EmptySeat)
                        newRow.Add(howToDetermineNearbyOccupiedSeats(initialFerry, i, j) == 0 ? Ferry.OccupiedSeat : Ferry.EmptySeat);
                    else
                        newRow.Add(howToDetermineNearbyOccupiedSeats(initialFerry, i, j) > maximumNearbyOccupiedSeatsTolerance ? Ferry.EmptySeat : Ferry.OccupiedSeat);
                }

                ferryAfterMovements.SeatLayout.Add(newRow);
            }

            return ferryAfterMovements;
        }

        public Ferry ApplyMoreComplexButStillFairlySimpleSetOfRules(Ferry initialFerry)
        {
            const int maximumNearbyOccupiedSeatsTolerance = 4;

            return ApplyRules(initialFerry, maximumNearbyOccupiedSeatsTolerance,
                (ferry, row, column) => ferry.OccupiedSeatsVisible(row, column));
        }
    }
}
