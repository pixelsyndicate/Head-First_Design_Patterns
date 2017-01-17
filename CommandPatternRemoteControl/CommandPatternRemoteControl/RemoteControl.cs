using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using CommandPatternRemoteControl.VendorCode;
using CommandPatternRemoteControl.VendorCode.Commands;

namespace CommandPatternRemoteControl
{
    public class RemoteControl
    {
        //  private readonly IRemoteCommand[][] _slots = new IRemoteCommand[7][];
        private readonly IRemoteCommand[] _onCommands;
        private readonly IRemoteCommand[] _offCommands;
        private readonly string[] _slotNames;

        public RemoteControl()
        {
            _onCommands = new IRemoteCommand[7] { new NoCommand(), new NoCommand(), new NoCommand(), new NoCommand(), new NoCommand(), new NoCommand(), new NoCommand() };
            _offCommands = new IRemoteCommand[7] { new NoCommand(), new NoCommand(), new NoCommand(), new NoCommand(), new NoCommand(), new NoCommand(), new NoCommand() };
            _slotNames = new[] { "", "", "", "", "", "", "" };

        }

        public void SetCommand(int slotNumber, IRemoteCommand onCommand, IRemoteCommand offCommand, string slotName = "No Name")
        {
            if (onCommand == null || offCommand == null)
            {
                throw new ApplicationException("must have an ON and OFF command included for each remote slot.");
            }
            _slotNames[slotNumber - 1] = slotName;
            if (slotNumber <= _onCommands.Length) { _onCommands[slotNumber - 1] = onCommand; }
            else throw new ArgumentOutOfRangeException(nameof(slotNumber), "The remote only has " + _offCommands.Length + " available OFF slots.");
            if (slotNumber <= _offCommands.Length) { _offCommands[slotNumber - 1] = offCommand; }
            else throw new ArgumentOutOfRangeException(nameof(slotNumber), "The remote only has " + _onCommands.Length + " available ON slots.");

        }

        /// <summary>
        /// Invoker runs command.execute()
        /// </summary>
        public void OnButtonWasPressed(int slotNumber)
        {
            _onCommands[slotNumber - 1].Execute();
        }
        public void OffButtonWasPressed(int slotNumber)
        {
            _offCommands[slotNumber - 1].Execute();
        }

        // override the tostring() method so i can see debugger info on what's happening
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n------ REMOTE CONTROL  ------\n");

            for (var i = 0; i <= _onCommands.Length - 1; i++)
            {
                sb.Append("[slot #" + i + " '" + _slotNames[i]+ "']         " + _onCommands[i].GetCommandName + "          " + _offCommands[i].GetCommandName + "\n");
            }
            return sb.ToString();
        }
    }
}