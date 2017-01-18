using System;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public abstract class BaseCommand
    {
        public abstract string GetCommandName { get; }
        public virtual Type GetCommandType { get; }

        public virtual string Name { get; set; }
    }
}