using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class LightOffCommand : BaseCommand, IRemoteCommand
    {
        private readonly Light _receiver;

        public LightOffCommand(Light receiver)
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
            get { return MethodBase.GetCurrentMethod().DeclaringType?.ToString().Replace("CommandPatternRemoteControl.VendorCode.",""); }
        }

        public override Type GetCommandType
        {
            get { throw new NotImplementedException(); }
        }
    }
}