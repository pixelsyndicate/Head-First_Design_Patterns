using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class GarageDoorOpenCommand : BaseCommand, IRemoteCommand
    {
        private readonly GarageDoor _receiver;

        public GarageDoorOpenCommand(GarageDoor receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
          //  Console.WriteLine("\n ----- Blink Blink Blink ----- \n");
            _receiver.Up();

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
            _receiver.Down();
        }
    }
}