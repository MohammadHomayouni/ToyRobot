using System.Collections.Generic;

namespace ToyRobot
{
    public class ToyRobotOperator : IToyRobotOperator
    {
        private readonly IToyRobotSimulator _toyRobotSimulator;
        private readonly List<ICommand> _commands = new List<ICommand>();

        public ToyRobotOperator(IToyRobotSimulator toyRobotSimulator)
        {
            _toyRobotSimulator = toyRobotSimulator;
        }

        public void Do(ToyRobotDto toyRobot, string command)
        {
            var toyRobotSimulatorCommand = new ToyRobotSimulatorCommand(_toyRobotSimulator, toyRobot, command);
            toyRobotSimulatorCommand.Execute();
            // Add command to undo list (undo is not implemented for this test project)
            _commands.Add(toyRobotSimulatorCommand);
        }

        public void Redo(int levels)
        {
            throw new System.NotImplementedException();
        }

        public void Undo(int levels)
        {
            throw new System.NotImplementedException();
        }
    }
}
