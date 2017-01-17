using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class GarageDoorCloseCommand : BaseCommand, IRemoteCommand
    {
        private readonly GarageDoor _door;

        public GarageDoorCloseCommand(GarageDoor door)
        {
            _door = door;
        }

        public void Execute()
        {
            _door.Down();
            Console.WriteLine("\n ----- Blink Blink Blink ----- \n");
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