using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class GarageDoorOpenCommand : BaseCommand, IRemoteCommand
    {
        private readonly GarageDoor _door;

        public GarageDoorOpenCommand(GarageDoor door)
        {
            _door = door;
        }

        public void Execute()
        {
            _door.Up();
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