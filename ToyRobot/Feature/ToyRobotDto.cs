using ToyRobot.Exception;

namespace ToyRobot
{
    public class ToyRobotDto
    {
        public Location Location { get; set; }

        public Direction? Direction { get; set; }

        public override string ToString()
        {
            if (Location == null)
            {
                throw new ToyRobotException("Robot has not yet been PLACEd.");
            }
            return $"{Location.X}, {Location.Y}, {Direction.ToString()}";
        }
    }

    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public enum Direction
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3
    }
}
