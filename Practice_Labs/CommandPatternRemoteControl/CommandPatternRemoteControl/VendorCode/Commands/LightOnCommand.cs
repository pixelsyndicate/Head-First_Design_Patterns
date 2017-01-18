using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class LightOnCommand : BaseCommand, IRemoteCommand
    {
        private readonly Light _receiver;

        public LightOnCommand(Light receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {Console.WriteLine("\n ----- Blink Blink Blink ----- \n");
            _receiver.On();
            
        }
        public override string GetCommandName
        {
            get { return MethodBase.GetCurrentMethod().DeclaringType?.FullName.Replace("CommandPatternRemoteControl.VendorCode.Commands.", ""); }

        }
        public override Type GetCommandType
        {
            get { throw new NotImplementedException(); }
        }

        public void Undo()
        {
            Console.WriteLine("\n ----- UNDO PRESSED ----- \n");
            _receiver.Off();
        }
    }
}