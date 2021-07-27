using ToyRobot.Exception;

namespace ToyRobot
{
    public class ToyRobotSimulator : IToyRobotSimulator
    {
        private readonly int _maxXCoor = 5, _maxYCoor = 5;
        private readonly int _minXCoor = 0, _minYCoor = 0;

        public ToyRobotSimulator()
        {
        }

        public void Place(ToyRobotDto toyRobot, int x, int y, Direction? direction = null)
        {
            if (direction == null &&
                toyRobot.Location == null)
            {
                throw new InvalidCommandException("The direction needs to be set in the first PLACE command.");
            }

            if (x > _maxXCoor ||
                x < _minXCoor ||
                y > _maxYCoor ||
                y < _minYCoor)
            {
                throw new OutsideOfTableException("Coordinates are outside of the table surface.");
            }

            toyRobot.Location = new Location
            {
                X = x,
                Y = y
            };

            if (direction != null)
            {
                toyRobot.Direction = direction.Value;
            }
        }

        public void Move(ToyRobotDto toyRobot)
        {
            ThrowRobotHasNotBeenPlacedYetException(toyRobot);
            switch (toyRobot.Direction)
            {
                case Direction.North:
                    if (toyRobot.Location.Y == _maxYCoor)
                    {
                        throw CanNotMoveException();
                    }
                    toyRobot.Location.Y++;
                    break;
                case Direction.East:
                    if (toyRobot.Location.X == _maxXCoor)
                    {
                        throw CanNotMoveException();
                    }
                    toyRobot.Location.X++;
                    break;
                case Direction.South:
                    if (toyRobot.Location.Y == _minYCoor)
                    {
                        throw CanNotMoveException();
                    }
                    toyRobot.Location.Y--;
                    break;
                case Direction.West:
                    if (toyRobot.Location.X == _minXCoor)
                    {
                        throw CanNotMoveException();
                    }
                    toyRobot.Location.X--;
                    break;
            }
        }

        public void Left(ToyRobotDto toyRobot)
        {
            ThrowRobotHasNotBeenPlacedYetException(toyRobot);
            toyRobot.Direction = toyRobot.Direction.Value.Previous();
        }

        public void Right(ToyRobotDto toyRobot)
        {
            ThrowRobotHasNotBeenPlacedYetException(toyRobot);
            toyRobot.Direction = toyRobot.Direction.Value.Next();
        }

        private ToyRobotException CanNotMoveException()
        {
            return new OutsideOfTableException("The robot has reached the end of the table. Can not move.");
        }

        private void ThrowRobotHasNotBeenPlacedYetException(ToyRobotDto toyRobot)
        {
            if (toyRobot.Location == null)
            {
                throw new InvalidCommandException("The robot has not been PLACEd yet. Use PLACE command to palce the robot.");
            }
        }
    }
}
