using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class OldStereoOffCommand : ICommand
    {
        private readonly Stereo _receiver;

        public OldStereoOffCommand(Stereo receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.Off();
        }
    }
}