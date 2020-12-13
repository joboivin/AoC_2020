using System;
using System.Collections.Generic;

namespace Day12Solver
{
    internal class Ferry
    {
        public const char MoveNorth = 'N';
        public const char MoveEast = 'E';
        public const char MoveSouth = 'S';
        public const char MoveWest = 'W';
        public const char MoveForward = 'F';
        public const char RotateLeft = 'L';
        public const char RotateRight = 'R';

        private static readonly IList<CardinalPoint> CardinalPointsOrder = new[] { CardinalPoint.North, CardinalPoint.East, CardinalPoint.South, CardinalPoint.West };

        private readonly Waypoint _waypoint;

        public Ferry()
            : this(new Waypoint())
        {

        }

        public Ferry(Waypoint waypoint)
        {
            Direction = CardinalPoint.East;
            Latitude = 0;
            Longitude = 0;

            _waypoint = waypoint;
        }

        public CardinalPoint Direction { get; private set; }
        public int Longitude { get; private set; }
        public int Latitude { get; private set; }
        public int ManhattanDistance => Math.Abs(Longitude) + Math.Abs(Latitude);

        public void Move(string instruction)
        {
            var command = instruction[0];
            var value = Convert.ToInt32(instruction[1..]);

            switch (command)
            {
                case MoveNorth:
                    Move(CardinalPoint.North, value);
                    break;
                case MoveEast:
                    Move(CardinalPoint.East, value);
                    break;
                case MoveSouth:
                    Move(CardinalPoint.South, value);
                    break;
                case MoveWest:
                    Move(CardinalPoint.West, value);
                    break;
                case MoveForward:
                    Move(Direction, value);
                    break;
                case RotateLeft:
                    RotateShip(-value);
                    break;
                case RotateRight:
                    RotateShip(value);
                    break;
            }
        }

        private void Move(CardinalPoint direction, int value)
        {
            switch (direction)
            {
                case CardinalPoint.North:
                    Latitude += value;
                    break;
                case CardinalPoint.East:
                    Longitude += value;
                    break;
                case CardinalPoint.South:
                    Latitude -= value;
                    break;
                case CardinalPoint.West:
                    Longitude -= value;
                    break;
            }
        }

        private void RotateShip(int value)
        {
            var currentCardinalPoint = CardinalPointsOrder.IndexOf(Direction);
            var nextCardinalPoint = currentCardinalPoint + (value / 90);

            while (nextCardinalPoint < 0)
                nextCardinalPoint += 4;

            Direction = CardinalPointsOrder[nextCardinalPoint % 4];
        }

        public void MoveAccordingToInstructionManual(string instruction)
        {
            var command = instruction[0];
            var value = Convert.ToInt32(instruction[1..]);

            switch (command)
            {
                case MoveNorth:
                    _waypoint.Move(CardinalPoint.North, value);
                    break;
                case MoveEast:
                    _waypoint.Move(CardinalPoint.East, value);
                    break;
                case MoveSouth:
                    _waypoint.Move(CardinalPoint.South, value);
                    break;
                case MoveWest:
                    _waypoint.Move(CardinalPoint.West, value);
                    break;
                case MoveForward:
                    MoveToWaypoint(value);
                    break;
                case RotateLeft:
                    _waypoint.Rotate(-value);
                    break;
                case RotateRight:
                    _waypoint.Rotate(value);
                    break;
            }
        }

        private void MoveToWaypoint(int value)
        {
            Longitude += value * _waypoint.RelativeLongitude;
            Latitude += value * _waypoint.RelativeLatitude;
        }
    }
}
