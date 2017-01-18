using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class GarageDoorCloseCommand : BaseCommand, IRemoteCommand
    {
        private readonly GarageDoor _receiver;

        public GarageDoorCloseCommand(GarageDoor receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            // Console.WriteLine("\n ----- Blink Blink Blink ----- \n");
            _receiver.Down();

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
            //Console.WriteLine("\n ----- UNDO PRESSED ----- \n");
            _receiver.Up();
        }
    }
}