using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class OldGarageDoorOpenCommand : ICommand
    {
        private readonly GarageDoor _door;

        public OldGarageDoorOpenCommand(GarageDoor door)
        {
            _door = door;
        }

        public void Execute()
        {
            _door.Up();
        }
    }
}