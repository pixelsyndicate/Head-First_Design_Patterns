using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class OldGarageDoorCloseCommand : ICommand
    {
        private readonly GarageDoor _door;

        public OldGarageDoorCloseCommand(GarageDoor door)
        {
            _door = door;
        }

        public object Execute()
        {
            return _door.Down();
        }
    }
}