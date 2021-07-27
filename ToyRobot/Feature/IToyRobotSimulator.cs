namespace ToyRobot
{
    public interface IToyRobotSimulator
    {
        void Place(ToyRobotDto toyRobot, int x, int y, Direction? direction = null);
        void Move(ToyRobotDto toyRobot);
        void Left(ToyRobotDto toyRobot);
        void Right(ToyRobotDto toyRobot);
    }
}
