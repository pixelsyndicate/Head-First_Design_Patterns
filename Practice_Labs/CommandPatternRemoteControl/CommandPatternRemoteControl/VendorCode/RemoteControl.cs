using System;
using System.Text;
using CommandPatternRemoteControl.VendorCode.Commands;

namespace CommandPatternRemoteControl
{
    public class RemoteControl
    {
        //  private readonly IRemoteCommand[][] _slots = new IRemoteCommand[7][];
        private readonly IRemoteCommand[] _onCommands;
        private readonly IRemoteCommand[] _offCommands;
        private IRemoteCommand _undoCommand;
        private readonly string[] _slotNames;

        public RemoteControl()
        {
            _onCommands = new IRemoteCommand[7] { new NoCommand(), new NoCommand(), new NoCommand(), new NoCommand(), new NoCommand(), new NoCommand(), new NoCommand() };
            _offCommands = new IRemoteCommand[7] { new NoCommand(), new NoCommand(), new NoCommand(), new NoCommand(), new NoCommand(), new NoCommand(), new NoCommand() };
            _slotNames = new[] { "", "", "", "", "", "", "" };
            _undoCommand = new NoCommand();
        }

        public void SetCommand(int slotNumber, IRemoteCommand onCommand, IRemoteCommand offCommand, string slotName = "No Name")
        {
            int ziNum = slotNumber - 1;
            if (onCommand == null || offCommand == null)
            {
                throw new ApplicationException("must have an ON and OFF command included for each remote slot.");
            }
            _slotNames[ziNum] = slotName;
            if (slotNumber <= _onCommands.Length)
            {
                _onCommands[ziNum] = onCommand;
            }
            else throw new ArgumentOutOfRangeException(nameof(slotNumber), "The remote only has " + _offCommands.Length + " available OFF slots.");
            if (slotNumber <= _offCommands.Length)
            {
                _offCommands[ziNum] = offCommand;
            }
            else throw new ArgumentOutOfRangeException(nameof(slotNumber), "The remote only has " + _onCommands.Length + " available ON slots.");

        }

        /// <summary>
        /// Invoker runs command.execute()
        /// </summary>
        public void OnButtonWasPressed(int slotNumber)
        {
            int ziNum = slotNumber - 1;
            _onCommands[ziNum].Execute();
            _undoCommand = _onCommands[ziNum];
        }
        public void OffButtonWasPressed(int slotNumber)
        {
            int ziNum = slotNumber - 1;
            _offCommands[ziNum].Execute();
            _undoCommand = _offCommands[ziNum];
        }

        // override the tostring() method so i can see debugger info on what's happening
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n------ REMOTE CONTROL  ------\n");

            for (var i = 0; i <= _onCommands.Length - 1; i++)
            {
                int slotNum = i + 1;
                sb.AppendLine("-- [slot #" + slotNum + " '" + _slotNames[i] + "']    " + _onCommands[i].GetCommandName + "     " + _offCommands[i].GetCommandName + " -- ");
            }
            sb.AppendLine("--[undo] " + _undoCommand.GetCommandName + " -- ");
            return sb.ToString();
        }

        public void UndoButtonWasPressed()
        {
            _undoCommand.Undo();
        }
    }
}