namespace ToyRobot
{
    public interface IToyRobotOperator
    {
        void Do(ToyRobotDto toyRobot, string command);
        void Redo(int levels);
        void Undo(int levels);
    }
}
