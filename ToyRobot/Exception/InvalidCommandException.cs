namespace ToyRobot.Exception
{
    public class InvalidCommandException : ToyRobotException
    {
        public InvalidCommandException(string message) : base(message)
        {
        }
    }
}
