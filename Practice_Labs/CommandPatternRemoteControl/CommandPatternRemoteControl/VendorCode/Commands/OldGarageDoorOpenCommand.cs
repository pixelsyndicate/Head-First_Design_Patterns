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

        public object Execute()
        {
            return _door.Up();
        }
    }
}