using System.Collections.Generic;
using Day11Solver;
using FluentAssertions;
using Xunit;

namespace Day11SolverTests
{
    public class FerryTests
    {
        [Fact]
        public void OccupiedSeatsNearby_ThenReturnsNumberOfOccupiedSeatsInAdjacentPositions()
        {
            var subject = new Ferry
            {
                SeatLayout = new List<List<char>>
                {
                    new List<char>{Ferry.OccupiedSeat, Ferry.EmptySeat, Ferry.Floor},
                    new List<char>{Ferry.Floor, Ferry.EmptySeat, Ferry.OccupiedSeat},
                    new List<char>{Ferry.OccupiedSeat, Ferry.EmptySeat, Ferry.OccupiedSeat},
                }
            };

            var result = subject.OccupiedSeatsNearby(1, 1);

            result.Should().Be(4);
        }

        [Fact]
        public void OccupiedSeatsNearby_WhenQueriedPositionIsOccupied_ThenDoesNotIncludeThisSeatInTotal()
        {
            var subject = SetupSubject();

            var result = subject.OccupiedSeatsNearby(1, 1);

            result.Should().Be(4);
        }

        [Fact]
        public void OccupiedSeatsNearby_WhenQueriesFirstRow_ThenReturnsCorrectTotal()
        {
            var subject = SetupSubject();

            var result = subject.OccupiedSeatsNearby(0, 1);

            result.Should().Be(3);
        }

        [Fact]
        public void OccupiedSeatsNearby_WhenQueriesLastRow_ThenReturnsCorrectTotal()
        {
            var subject = SetupSubject();

            var result = subject.OccupiedSeatsNearby(2, 1);

            result.Should().Be(4);
        }

        [Fact]
        public void OccupiedSeatsNearby_WhenQueriesFirstColumn_ThenReturnsCorrectTotal()
        {
            var subject = SetupSubject();

            var result = subject.OccupiedSeatsNearby(1, 0);

            result.Should().Be(3);
        }

        [Fact]
        public void OccupiedSeatsNearby_WhenQueriesLastColumn_ThenReturnsCorrectTotal()
        {
            var subject = SetupSubject();

            var result = subject.OccupiedSeatsNearby(1, 2);

            result.Should().Be(2);
        }

        [Fact]
        public void GetTotalOccupiedSeats_ThenReturnsTotalOccupiedSeats()
        {
            var subject = SetupSubject();

            var result = subject.GetTotalOccupiedSeats();

            result.Should().Be(5);
        }

        [Fact]
        public void OccupiedSeatsVisible_ThenReturnsNumberOfOccupiedSeatsInVisiblePositions()
        {
            var subject = new Ferry
            {
                SeatLayout = new List<List<char>>
                {
                    new List<char>{Ferry.OccupiedSeat, Ferry.EmptySeat, Ferry.Floor, Ferry.EmptySeat, Ferry.OccupiedSeat},
                    new List<char>{Ferry.Floor, Ferry.EmptySeat, Ferry.Floor, Ferry.EmptySeat, Ferry.OccupiedSeat},
                    new List<char>{Ferry.OccupiedSeat, Ferry.Floor, Ferry.OccupiedSeat, Ferry.Floor, Ferry.Floor},
                    new List<char>{Ferry.Floor, Ferry.Floor, Ferry.OccupiedSeat, Ferry.EmptySeat, Ferry.OccupiedSeat},
                    new List<char>{Ferry.OccupiedSeat, Ferry.EmptySeat, Ferry.OccupiedSeat, Ferry.EmptySeat, Ferry.OccupiedSeat},
                }
            };

            var result = subject.OccupiedSeatsVisible(2, 2);

            result.Should().Be(3);
        }

        private Ferry SetupSubject()
        {
            return new Ferry
            {
                SeatLayout = new List<List<char>>
                {
                    new List<char>{Ferry.OccupiedSeat, Ferry.EmptySeat, Ferry.Floor},
                    new List<char>{Ferry.Floor, Ferry.OccupiedSeat, Ferry.OccupiedSeat},
                    new List<char>{Ferry.OccupiedSeat, Ferry.EmptySeat, Ferry.OccupiedSeat},
                }
            };
        }
    }
}
