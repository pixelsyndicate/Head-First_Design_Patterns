using System;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class OldLightOnCommand : ICommand
    {
        private readonly Light _light;

        public OldLightOnCommand(Light light)
        {
            _light = light;
        }

        public object Execute()
        {
           return _light.On();
        }
    }
}