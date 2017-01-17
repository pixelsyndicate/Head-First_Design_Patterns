using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternRemoteControl
{
    public interface ICommand
    {
        void Execute();
    }

    public interface IRemoteCommand
    {
        void Execute();
        string Name { get; set; }
        string GetCommandName { get; }
        Type GetCommandType { get; }
    }
}
