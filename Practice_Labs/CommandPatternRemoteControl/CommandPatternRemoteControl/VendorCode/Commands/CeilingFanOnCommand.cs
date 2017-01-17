using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class CeilingFanOnCommand : BaseCommand, IRemoteCommand
    {
        private readonly CeilingFan _receiver;

        public CeilingFanOnCommand(CeilingFan receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            Console.WriteLine("\n ----- Blink Blink Blink ----- \n");
            _receiver.On();
            _receiver.SetSpeed(3);

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