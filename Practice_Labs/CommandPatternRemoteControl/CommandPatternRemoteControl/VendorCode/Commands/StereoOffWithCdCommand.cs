using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class StereoOffWithCdCommand : BaseCommand, IRemoteCommand
    {
        private readonly Stereo _receiver;

        public StereoOffWithCdCommand(Stereo receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.Off();
            Console.WriteLine("\n ----- Blink Blink Blink ----- \n");
        }

        public override string GetCommandName
        {
            get { return MethodBase.GetCurrentMethod().DeclaringType?.FullName.Replace("CommandPatternRemoteControl.VendorCode.Commands.", ""); }

        }
        public override Type GetCommandType
        {
            get { throw new NotImplementedException(); }
        }
    }
}