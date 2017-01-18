using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class OldStereoOnCommand : ICommand
    {
        private readonly Stereo _receiver;

        public OldStereoOnCommand(Stereo receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.Off();
        }
    }
}