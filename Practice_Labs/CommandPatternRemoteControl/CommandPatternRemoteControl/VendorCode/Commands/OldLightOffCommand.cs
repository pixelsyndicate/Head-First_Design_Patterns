using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class OldLightOffCommand : ICommand
    {
        private readonly Light _light;

        public OldLightOffCommand(Light light)
        {
            _light = light;
        }

        public object Execute()
        {
            return _light.Off();
        }
    }
}