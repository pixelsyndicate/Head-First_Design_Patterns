using CommandPatternRemoteControl.VendorCode.Commands;

namespace CommandPatternRemoteControl
{
    public class SimpleRemoteControl
    {
        private ICommand _slot;

        public void SetCommand(ICommand command)
        {
            _slot = command;
        }

        /// <summary>
        /// Invoker runs command.execute()
        /// </summary>
        public void ButtonWasPressed()
        {
            _slot.Execute();
        }
    }
}