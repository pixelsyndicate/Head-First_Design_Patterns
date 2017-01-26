using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CommandPatternRemoteControl.VendorCode.Commands;

namespace CommandPatternRemoteControl
{
    public class RemoteControl
    {
        //  private readonly IRemoteCommand[][] _slots = new IRemoteCommand[7][];
        private readonly List<IRemoteCommand> _onCommands;
        private readonly List<IRemoteCommand> _offCommands;
        private IRemoteCommand _undoCommand;
        private readonly string[] _slotNames;

        public RemoteControl()
        {

            IRemoteCommand noCommand = new NoCommand();
            _onCommands = new List<IRemoteCommand>(7);// IRemoteCommand[];
            _offCommands = new List<IRemoteCommand>(7);
            _slotNames = new string[7];
            for (int i = 0; i < 7; i++)
            {
                _onCommands.Add(noCommand);//[i] = noCommand;
                _offCommands.Add(noCommand);//[i] = noCommand;
                _slotNames[i] = i.ToString();
            }
            _undoCommand = noCommand;
        }

        public void SetCommand(int slotNumber, IRemoteCommand onCommand, IRemoteCommand offCommand, string slotName = "No Name")
        {
            int ziNum = slotNumber - 1;
            if (onCommand == null || offCommand == null)
            {
                throw new ApplicationException("must have an ON and OFF command included for each remote slot.");
            }
            _slotNames[ziNum] = slotName;
            if (slotNumber <= _onCommands.Count())
            {
                _onCommands.RemoveAt(ziNum);
                _onCommands.Insert(ziNum, onCommand);
            }
            else throw new ArgumentOutOfRangeException(nameof(slotNumber), "The remote only has " + _offCommands.Count() + " available OFF slots.");
            if (slotNumber <= _offCommands.Count())
            {
                _offCommands.RemoveAt(ziNum);
                _offCommands.Insert(ziNum, offCommand);
            }
            else throw new ArgumentOutOfRangeException(nameof(slotNumber), "The remote only has " + _onCommands.Count() + " available ON slots.");

        }

        /// <summary>
        /// Invoker runs command.execute()
        /// </summary>
        public object OnButtonWasPressed(int slotNumber)
        {
            int ziNum = slotNumber - 1;
            _undoCommand = _onCommands[ziNum];
            return _onCommands[ziNum].Execute();

        }
        public object OffButtonWasPressed(int slotNumber)
        {
            int ziNum = slotNumber - 1;
            _undoCommand = _offCommands[ziNum];
            return _offCommands[ziNum].Execute();

        }
        public object UndoButtonWasPressed()
        {
            return _undoCommand.Undo();
        }
        // override the tostring() method so i can see debugger info on what's happening
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("------ Remote Control -------");

            int counter = 0;
            foreach (var cmd in _onCommands)
            {
                var curInd = counter;// _onCommands.IndexOf(cmd);
                var onCmdName = cmd.GetType().Name;
                var matchingOff = _offCommands[curInd];
                var offCmdName = matchingOff.GetType().Name;
                sb.AppendLine("[slot " + curInd + "] " + onCmdName + "     " + offCmdName);
                counter++;
            }
            sb.AppendLine("Undo: " + _undoCommand.GetType().Name);
            return sb.ToString();
        }



    }
}