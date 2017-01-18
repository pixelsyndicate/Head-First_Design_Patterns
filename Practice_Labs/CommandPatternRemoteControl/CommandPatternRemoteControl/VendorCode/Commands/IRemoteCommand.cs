using System;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public interface IRemoteCommand
    {
        void Execute();
        string Name { get; set; }
        string GetCommandName { get; }
        Type GetCommandType { get; }
       
        void Undo();
    }
}