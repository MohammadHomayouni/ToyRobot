using System;
using ToyRobot.Exception;

namespace ToyRobot
{
    class Program
    {
        static ToyRobotDto _toyRobot = new ToyRobotDto();
        static ToyRobotOperator _toyRobotOperator = new ToyRobotOperator(new ToyRobotSimulator());
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter your command");
                var command = Console.ReadLine();
                try
                {
                    if (command.ToUpper().StartsWith("REPORT"))
                    {
                        Console.WriteLine(_toyRobot.ToString());
                        continue;
                    }
                    _toyRobotOperator.Do(_toyRobot, command);
                }
                catch (ToyRobotException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (System.Exception exception)
                {
                    //TODO: Logging
                    System.Diagnostics.Debugger.Log(1, null, exception.Message);
                }
            }
        }
    }
}
