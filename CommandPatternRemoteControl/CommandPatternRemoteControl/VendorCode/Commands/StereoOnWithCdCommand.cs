using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class StereoOnWithCdCommand : BaseCommand, IRemoteCommand
    {
        private readonly Stereo _receiver;

        public StereoOnWithCdCommand(Stereo receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            Console.WriteLine("\n ----- Blink Blink Blink ----- \n");
            _receiver.On();
            _receiver.SetCd();
            _receiver.SetVolume(11);

        }

        public override string GetCommandName
        {
            get { return MethodBase.GetCurrentMethod().DeclaringType?.ToString().Replace("CommandPatternRemoteControl.VendorCode.", ""); }
        }

        public override Type GetCommandType
        {
            get { throw new NotImplementedException(); }
        }
    }
}