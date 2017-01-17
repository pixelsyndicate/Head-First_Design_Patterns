using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode
{
    public class OldLightOnCommand : ICommand
    {
        private readonly Light _light;

        public OldLightOnCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.On();
        }
    }
}