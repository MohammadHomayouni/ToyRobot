using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    public interface ICommand
    {
        void Execute();
        void UnExecute();
    }
}
