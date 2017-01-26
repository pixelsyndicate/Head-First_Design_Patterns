using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class GarageDoorOpenCommand : IRemoteCommand
    {
        private readonly GarageDoor _receiver;

        public GarageDoorOpenCommand(GarageDoor receiver)
        {
            _receiver = receiver;
        }

        public object Execute()
        {

            return _receiver.Up();

        }

        public Action Undo()
        {

            return () => _receiver.Down();
        }
    }
}