using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode
{
    public class OldLightOffCommand : ICommand
    {
        private readonly Light _light;

        public OldLightOffCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.Off();
        }
    }
}