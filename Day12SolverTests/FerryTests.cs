using Day12Solver;
using FluentAssertions;
using Xunit;

namespace Day12SolverTests
{
    public class FerryTests
    {
        [Fact]
        public void Ferry_ThenInitialValuesAreOK()
        {
            var subject = new Ferry();

            subject.Direction.Should().Be(CardinalPoint.East);
            subject.Longitude.Should().Be(0);
            subject.Latitude.Should().Be(0);
        }

        [Fact]
        public void Move_WhenMoveNorth_ThenLatituteIncrementedByValue()
        {
            const int value = 15;

            var subject = new Ferry();
            var command = $"{Ferry.MoveNorth}{value}";

            subject.Move(command);

            subject.Direction.Should().Be(CardinalPoint.East);
            subject.Longitude.Should().Be(0);
            subject.Latitude.Should().Be(value);
        }

        [Fact]
        public void Move_WhenMoveEast_ThenLongitudeIncrementedByValue()
        {
            const int value = 14;

            var subject = new Ferry();
            var command = $"{Ferry.MoveEast}{value}";

            subject.Move(command);

            subject.Direction.Should().Be(CardinalPoint.East);
            subject.Longitude.Should().Be(value);
            subject.Latitude.Should().Be(0);
        }

        [Fact]
        public void Move_WhenMoveSouth_ThenLatituteDecrementedByValue()
        {
            const int value = 13;

            var subject = new Ferry();
            var command = $"{Ferry.MoveSouth}{value}";

            subject.Move(command);

            subject.Direction.Should().Be(CardinalPoint.East);
            subject.Longitude.Should().Be(0);
            subject.Latitude.Should().Be(-value);
        }

        [Fact]
        public void Move_WhenMoveWest_ThenLongitudeDecrementedByValue()
        {
            const int value = 12;

            var subject = new Ferry();
            var command = $"{Ferry.MoveWest}{value}";

            subject.Move(command);

            subject.Direction.Should().Be(CardinalPoint.East);
            subject.Longitude.Should().Be(-value);
            subject.Latitude.Should().Be(0);
        }

        [Fact]
        public void Move_WhenMoveForwardAndDirectionIsEast_ThenLongitudeIncrementedByValue()
        {
            const int value = 11;

            var subject = new Ferry();
            var command = $"{Ferry.MoveForward}{value}";

            subject.Move(command);

            subject.Direction.Should().Be(CardinalPoint.East);
            subject.Longitude.Should().Be(value);
            subject.Latitude.Should().Be(0);
        }

        [Theory]
        [InlineData(0, CardinalPoint.East)]
        [InlineData(90, CardinalPoint.South)]
        [InlineData(180, CardinalPoint.West)]
        [InlineData(270, CardinalPoint.North)]
        [InlineData(360, CardinalPoint.East)]
        [InlineData(450, CardinalPoint.South)]
        public void Move_WhenDirectionIsEastAndRotateRight_ThenDirectionChanged(int degreesDifference, CardinalPoint newDirection)
        {
            var subject = new Ferry();
            var command = $"{Ferry.RotateRight}{degreesDifference}";

            subject.Move(command);

            subject.Direction.Should().Be(newDirection);
            subject.Longitude.Should().Be(0);
            subject.Latitude.Should().Be(0);
        }

        [Theory]
        [InlineData(0, CardinalPoint.East)]
        [InlineData(90, CardinalPoint.North)]
        [InlineData(180, CardinalPoint.West)]
        [InlineData(270, CardinalPoint.South)]
        [InlineData(360, CardinalPoint.East)]
        [InlineData(450, CardinalPoint.North)]
        public void Move_WhenDirectionIsEastAndRotateLeft_ThenDirectionChanged(int degreesDifference, CardinalPoint newDirection)
        {
            var subject = new Ferry();
            var command = $"{Ferry.RotateLeft}{degreesDifference}";

            subject.Move(command);

            subject.Direction.Should().Be(newDirection);
            subject.Longitude.Should().Be(0);
            subject.Latitude.Should().Be(0);
        }

        [Fact]
        public void Move_WhenMoveForwardAndDirectionIsNorth_ThenLatitudeIncrementedByValue()
        {
            const int value = 11;

            var subject = new Ferry();
            var firstCommand = $"{Ferry.RotateLeft}90";
            var secondCommand = $"{Ferry.MoveForward}{value}";

            subject.Move(firstCommand);
            subject.Move(secondCommand);

            subject.Direction.Should().Be(CardinalPoint.North);
            subject.Longitude.Should().Be(0);
            subject.Latitude.Should().Be(value);
        }

        [Fact]
        public void Move_WhenMoveForwardAndDirectionIsWest_ThenLongitudeDecrementedByValue()
        {
            const int value = 10;

            var subject = new Ferry();
            var firstCommand = $"{Ferry.RotateLeft}180";
            var secondCommand = $"{Ferry.MoveForward}{value}";

            subject.Move(firstCommand);
            subject.Move(secondCommand);

            subject.Direction.Should().Be(CardinalPoint.West);
            subject.Longitude.Should().Be(-value);
            subject.Latitude.Should().Be(0);
        }

        [Fact]
        public void Move_WhenMoveForwardAndDirectionIsSouth_ThenLatitudeDecrementedByValue()
        {
            const int value = 9;

            var subject = new Ferry();
            var firstCommand = $"{Ferry.RotateRight}90";
            var secondCommand = $"{Ferry.MoveForward}{value}";

            subject.Move(firstCommand);
            subject.Move(secondCommand);

            subject.Direction.Should().Be(CardinalPoint.South);
            subject.Longitude.Should().Be(0);
            subject.Latitude.Should().Be(-value);
        }

        [Fact]
        public void ManhattanDistance_WhenBothLatitudeAndLongitudeArePositive_ThenReturnSum()
        {
            var subject = new Ferry();
            var firstCommand = $"{Ferry.MoveEast}9";
            var secondCommand = $"{Ferry.MoveNorth}8";

            subject.Move(firstCommand);
            subject.Move(secondCommand);
            var result = subject.ManhattanDistance;

            result.Should().Be(17);
        }

        [Fact]
        public void ManhattanDistance_WhenBothLatitudeAndLongitudeAreNegative_ThenReturnSumOfAbsoluteValues()
        {
            var subject = new Ferry();
            var firstCommand = $"{Ferry.MoveWest}7";
            var secondCommand = $"{Ferry.MoveSouth}6";

            subject.Move(firstCommand);
            subject.Move(secondCommand);
            var result = subject.ManhattanDistance;

            result.Should().Be(13);
        }

        [Fact]
        public void ManhattanDistance_WhenLatitudeIsPositiveAndLongitudeIsNegative_ThenReturnSumOfAbsoluteValues()
        {
            var subject = new Ferry();
            var firstCommand = $"{Ferry.MoveWest}5";
            var secondCommand = $"{Ferry.MoveNorth}4";

            subject.Move(firstCommand);
            subject.Move(secondCommand);
            var result = subject.ManhattanDistance;

            result.Should().Be(9);
        }

        [Fact]
        public void ManhattanDistance_WhenLatitudeIsNegativeAndLongitudeIsPositive_ThenReturnSumOfAbsoluteValues()
        {
            var subject = new Ferry();
            var firstCommand = $"{Ferry.MoveEast}3";
            var secondCommand = $"{Ferry.MoveNorth}2";

            subject.Move(firstCommand);
            subject.Move(secondCommand);
            var result = subject.ManhattanDistance;

            result.Should().Be(5);
        }

        [Fact]
        public void MoveAccordingToInstructionManual_WhenMoveNorth_ThenWaypointRelativeLatituteIncrementedByValue()
        {
            const int value = 15;

            var waypoint = new Waypoint();
            var subject = new Ferry(waypoint);
            var command = $"{Ferry.MoveNorth}{value}";
            var waypointLongitude = waypoint.RelativeLongitude;
            var waypointLatitude = waypoint.RelativeLatitude;

            subject.MoveAccordingToInstructionManual(command);

            subject.Longitude.Should().Be(0);
            subject.Latitude.Should().Be(0);
            waypoint.RelativeLatitude.Should().Be(waypointLatitude + value);
            waypoint.RelativeLongitude.Should().Be(waypointLongitude);
        }

        [Fact]
        public void MoveAccordingToInstructionManual_WhenMoveEast_ThenWaypointRelativeLongitudeIncrementedByValue()
        {
            const int value = 14;

            var waypoint = new Waypoint();
            var subject = new Ferry(waypoint);
            var command = $"{Ferry.MoveEast}{value}";
            var waypointLongitude = waypoint.RelativeLongitude;
            var waypointLatitude = waypoint.RelativeLatitude;

            subject.MoveAccordingToInstructionManual(command);

            subject.Longitude.Should().Be(0);
            subject.Latitude.Should().Be(0);
            waypoint.RelativeLatitude.Should().Be(waypointLatitude);
            waypoint.RelativeLongitude.Should().Be(waypointLongitude + value);
        }

        [Fact]
        public void MoveAccordingToInstructionManual_WhenMoveSouth_ThenWaypointRelativeLatituteDecrementedByValue()
        {
            const int value = 13;

            var waypoint = new Waypoint();
            var subject = new Ferry(waypoint);
            var command = $"{Ferry.MoveSouth}{value}";
            var waypointLongitude = waypoint.RelativeLongitude;
            var waypointLatitude = waypoint.RelativeLatitude;

            subject.MoveAccordingToInstructionManual(command);

            subject.Longitude.Should().Be(0);
            subject.Latitude.Should().Be(0);
            waypoint.RelativeLatitude.Should().Be(waypointLatitude - value);
            waypoint.RelativeLongitude.Should().Be(waypointLongitude);
        }

        [Fact]
        public void MoveAccordingToInstructionManual_WhenMoveWest_ThenWaypointRelativeLongitudeDecrementedByValue()
        {
            const int value = 12;

            var waypoint = new Waypoint();
            var subject = new Ferry(waypoint);
            var command = $"{Ferry.MoveWest}{value}";
            var waypointLongitude = waypoint.RelativeLongitude;
            var waypointLatitude = waypoint.RelativeLatitude;

            subject.MoveAccordingToInstructionManual(command);

            subject.Longitude.Should().Be(0);
            subject.Latitude.Should().Be(0);
            waypoint.RelativeLatitude.Should().Be(waypointLatitude);
            waypoint.RelativeLongitude.Should().Be(waypointLongitude - value);
        }

        [Fact]
        public void MoveAccordingToInstructionManual_WhenMoveForward_ThenMoveAccordingToWaypoint()
        {
            const int value = 11;

            var waypoint = new Waypoint();
            var subject = new Ferry(waypoint);
            var waypointLongitude = waypoint.RelativeLongitude;
            var waypointLatitude = waypoint.RelativeLatitude;
            var command = $"{Ferry.MoveForward}{value}";

            subject.MoveAccordingToInstructionManual(command);

            subject.Longitude.Should().Be(value * waypointLongitude);
            subject.Latitude.Should().Be(value * waypointLatitude);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(360)]
        public void MoveAccordingToInstructionManual_WhenRotateRightAndDegreesAre360_ThenWaypointStaysInSameLocation(int degreesDifference)
        {
            var waypoint = new Waypoint();
            var subject = new Ferry(waypoint);
            var waypointLongitude = waypoint.RelativeLongitude;
            var waypointLatitude = waypoint.RelativeLatitude;
            var command = $"{Ferry.RotateRight}{degreesDifference}";

            subject.Move(command);

            subject.Longitude.Should().Be(0);
            subject.Latitude.Should().Be(0);
            waypoint.RelativeLongitude.Should().Be(waypointLongitude);
            waypoint.RelativeLatitude.Should().Be(waypointLatitude);
        }

        [Theory]
        [InlineData(90)]
        [InlineData(450)]
        public void MoveAccordingToInstructionManual_WhenRotateRightAndDegreesAre90_ThenWaypointMovesAroundShip(int degreesDifference)
        {
            var waypoint = new Waypoint();
            var subject = new Ferry(waypoint);
            var waypointLongitude = waypoint.RelativeLongitude;
            var waypointLatitude = waypoint.RelativeLatitude;
            var command = $"{Ferry.RotateRight}{degreesDifference}";

            subject.MoveAccordingToInstructionManual(command);

            subject.Longitude.Should().Be(0);
            subject.Latitude.Should().Be(0);
            waypoint.RelativeLongitude.Should().Be(waypointLatitude);
            waypoint.RelativeLatitude.Should().Be(-waypointLongitude);
        }

        [Theory]
        [InlineData(180)]
        [InlineData(540)]
        public void MoveAccordingToInstructionManual_WhenRotateRightAndDegreesAre180_ThenWaypointMovesAroundShip(int degreesDifference)
        {
            var waypoint = new Waypoint();
            var subject = new Ferry(waypoint);
            var waypointLongitude = waypoint.RelativeLongitude;
            var waypointLatitude = waypoint.RelativeLatitude;
            var command = $"{Ferry.RotateRight}{degreesDifference}";

            subject.MoveAccordingToInstructionManual(command);

            subject.Longitude.Should().Be(0);
            subject.Latitude.Should().Be(0);
            waypoint.RelativeLongitude.Should().Be(-waypointLongitude);
            waypoint.RelativeLatitude.Should().Be(-waypointLatitude);
        }

        [Theory]
        [InlineData(270)]
        [InlineData(630)]
        public void MoveAccordingToInstructionManual_WhenRotateRightAndDegreesAre270_ThenWaypointMovesAroundShip(int degreesDifference)
        {
            var waypoint = new Waypoint();
            var subject = new Ferry(waypoint);
            var waypointLongitude = waypoint.RelativeLongitude;
            var waypointLatitude = waypoint.RelativeLatitude;
            var command = $"{Ferry.RotateRight}{degreesDifference}";

            subject.MoveAccordingToInstructionManual(command);

            subject.Longitude.Should().Be(0);
            subject.Latitude.Should().Be(0);
            waypoint.RelativeLongitude.Should().Be(-waypointLatitude);
            waypoint.RelativeLatitude.Should().Be(waypointLongitude);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(360)]
        public void MoveAccordingToInstructionManual_WhenRotateLeftAndDegreesAre360_ThenWaypointStaysInSameLocation(int degreesDifference)
        {
            var waypoint = new Waypoint();
            var subject = new Ferry(waypoint);
            var waypointLongitude = waypoint.RelativeLongitude;
            var waypointLatitude = waypoint.RelativeLatitude;
            var command = $"{Ferry.RotateLeft}{degreesDifference}";

            subject.Move(command);

            subject.Longitude.Should().Be(0);
            subject.Latitude.Should().Be(0);
            waypoint.RelativeLongitude.Should().Be(waypointLongitude);
            waypoint.RelativeLatitude.Should().Be(waypointLatitude);
        }

        [Theory]
        [InlineData(90)]
        [InlineData(450)]
        public void MoveAccordingToInstructionManual_WhenRotateLeftAndDegreesAre90_ThenWaypointMovesAroundShip(int degreesDifference)
        {
            var waypoint = new Waypoint();
            var subject = new Ferry(waypoint);
            var waypointLongitude = waypoint.RelativeLongitude;
            var waypointLatitude = waypoint.RelativeLatitude;
            var command = $"{Ferry.RotateLeft}{degreesDifference}";

            subject.MoveAccordingToInstructionManual(command);

            subject.Longitude.Should().Be(0);
            subject.Latitude.Should().Be(0);
            waypoint.RelativeLongitude.Should().Be(-waypointLatitude);
            waypoint.RelativeLatitude.Should().Be(waypointLongitude);
        }

        [Theory]
        [InlineData(180)]
        [InlineData(540)]
        public void MoveAccordingToInstructionManual_WhenRotateLeftAndDegreesAre180_ThenWaypointMovesAroundShip(int degreesDifference)
        {
            var waypoint = new Waypoint();
            var subject = new Ferry(waypoint);
            var waypointLongitude = waypoint.RelativeLongitude;
            var waypointLatitude = waypoint.RelativeLatitude;
            var command = $"{Ferry.RotateLeft}{degreesDifference}";

            subject.MoveAccordingToInstructionManual(command);

            subject.Longitude.Should().Be(0);
            subject.Latitude.Should().Be(0);
            waypoint.RelativeLongitude.Should().Be(-waypointLongitude);
            waypoint.RelativeLatitude.Should().Be(-waypointLatitude);
        }

        [Theory]
        [InlineData(270)]
        [InlineData(630)]
        public void MoveAccordingToInstructionManual_WhenRotateLeftAndDegreesAre270_ThenWaypointMovesAroundShip(int degreesDifference)
        {
            var waypoint = new Waypoint();
            var subject = new Ferry(waypoint);
            var waypointLongitude = waypoint.RelativeLongitude;
            var waypointLatitude = waypoint.RelativeLatitude;
            var command = $"{Ferry.RotateLeft}{degreesDifference}";

            subject.MoveAccordingToInstructionManual(command);

            subject.Longitude.Should().Be(0);
            subject.Latitude.Should().Be(0);
            waypoint.RelativeLongitude.Should().Be(waypointLatitude);
            waypoint.RelativeLatitude.Should().Be(-waypointLongitude);
        }
    }
}
