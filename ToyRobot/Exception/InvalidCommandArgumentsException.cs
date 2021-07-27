namespace ToyRobot.Exception
{
    public class InvalidCommandArgumentsException : ToyRobotException
    {
        public InvalidCommandArgumentsException(string message) : base(message)
        {
        }
    }
}
