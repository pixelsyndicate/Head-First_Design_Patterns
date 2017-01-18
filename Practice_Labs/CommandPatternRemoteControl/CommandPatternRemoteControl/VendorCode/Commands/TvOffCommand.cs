using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class TvOffCommand : BaseCommand, IRemoteCommand
    {
        private readonly TV _receiver;

        public TvOffCommand(TV receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
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
          //  Console.WriteLine("\n ----- UNDO PRESSED ----- \n");
            _receiver.On();
        }
    }
}