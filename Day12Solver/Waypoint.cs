namespace Day12Solver
{
    internal class Waypoint
    {
        public const char MoveNorth = 'N';
        public const char MoveEast = 'E';
        public const char MoveSouth = 'S';
        public const char MoveWest = 'W';

        public Waypoint()
        {
            RelativeLongitude = 10;
            RelativeLatitude = 1;
        }

        public int RelativeLongitude { get; private set; }
        public int RelativeLatitude { get; private set; }

        public void Move(CardinalPoint direction, int value)
        {
            switch (direction)
            {
                case CardinalPoint.North:
                    RelativeLatitude += value;
                    break;
                case CardinalPoint.East:
                    RelativeLongitude += value;
                    break;
                case CardinalPoint.South:
                    RelativeLatitude -= value;
                    break;
                case CardinalPoint.West:
                    RelativeLongitude -= value;
                    break;
            }
        }

        public void Rotate(int numberOfDegrees)
        {
            var rotationValue = numberOfDegrees / 90;
            var oldLongitude = RelativeLongitude;
            var oldLatitude = RelativeLatitude;

            switch (rotationValue % 4)
            {
                case 1:
                case -3:
                    RelativeLatitude = 0 - oldLongitude;
                    RelativeLongitude = oldLatitude;
                    break;
                case 2:
                case -2:
                    RelativeLatitude = 0 - oldLatitude;
                    RelativeLongitude = 0 - oldLongitude;
                    break;
                case 3:
                case -1:
                    RelativeLatitude = oldLongitude;
                    RelativeLongitude = 0 - oldLatitude;
                    break;
            }
        }
    }
}
