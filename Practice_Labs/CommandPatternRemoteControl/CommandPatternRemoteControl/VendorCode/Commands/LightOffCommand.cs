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

        public void Execute() { 
            _receiver.Off();
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
           // Console.WriteLine("\n ----- UNDO PRESSED ----- \n");
            _receiver.On();
        }
    }
}