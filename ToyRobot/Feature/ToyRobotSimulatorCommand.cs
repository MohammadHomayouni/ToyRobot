using System;
using ToyRobot.Exception;

namespace ToyRobot
{
    public class ToyRobotSimulatorCommand : ICommand
    {
        private readonly IToyRobotSimulator _toyRobotSimulator;
        private readonly ToyRobotDto _toyRobot;
        private string _command;

        public ToyRobotSimulatorCommand(IToyRobotSimulator toyRobotSimulator,
                                        ToyRobotDto toyRobot,
                                        string command)
        {
            _toyRobotSimulator = toyRobotSimulator;
            _toyRobot = toyRobot;
            _command = command;
        }

        public void Execute()
        {
            var commandSeparatedBySpace = _command.Split(" ");
            if(commandSeparatedBySpace.Length < 1)
            {
                throw new InvalidCommandException("Invalid command.");
            }

            switch (commandSeparatedBySpace[0].ToUpper())
            {
                case "PLACE":
                    var args = commandSeparatedBySpace[1].Split(",");
                    if (args.Length < 2)
                    {
                        throw new InvalidCommandArgumentsException("Invalid arguments for the command PLACE.");
                    }
                    Place(args);
                    break;
                case "MOVE":
                    Move();
                    break;
                case "LEFT":
                    Left();
                    break;
                case "RIGHT":
                    Right();
                    break;
                default:
                    throw new ToyRobotException("Invalid command.");
            }
        }

        private void Place(string[] placeCommandArgs)
        {
            var isValidX = int.TryParse(placeCommandArgs[0], out var x);
            var isValidY = int.TryParse(placeCommandArgs[1], out var y);

            if (!isValidX || !isValidY)
            {
                throw new InvalidCommandArgumentsException("invalid x or y coordinate for command PLACE");
            }

            Direction? newDirection = _toyRobot.Direction;

            if (placeCommandArgs.Length > 2)
            {
                var isValidDirection = Enum.TryParse(typeof(Direction), placeCommandArgs[2], true, out var direction);

                if (!isValidDirection)
                {
                    throw new InvalidCommandArgumentsException("invalid direction for command PLACE");
                }

                newDirection = (Direction)direction;
            }

            _toyRobotSimulator.Place(_toyRobot, x, y, newDirection);
        }

        private void Move()
        {
            _toyRobotSimulator.Move(_toyRobot);
        }

        private void Left()
        {
            _toyRobotSimulator.Left(_toyRobot);
        }

        private void Right()
        {
            _toyRobotSimulator.Right(_toyRobot);
        }

        public void UnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
