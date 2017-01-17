using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class CeilingFanOffCommand : BaseCommand, IRemoteCommand
    {
        private readonly CeilingFan _receiver;

        public CeilingFanOffCommand(CeilingFan receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            Console.WriteLine("\n ----- Blink Blink Blink ----- \n");
            _receiver.Off();
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