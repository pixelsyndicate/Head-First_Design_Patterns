using System;

namespace CommandPatternRemoteControl.VendorCode.Commands
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
