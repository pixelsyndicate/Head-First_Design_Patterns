using System;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public interface IRemoteCommand
    {
        object Execute();
        Action Undo();
        // string Name { get; set; }
        //string GetCommandName { get; }
        //Type GetCommandType { get; }
    }
}