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

        public void Execute()
        {
            _door.Down();
        }
    }
}