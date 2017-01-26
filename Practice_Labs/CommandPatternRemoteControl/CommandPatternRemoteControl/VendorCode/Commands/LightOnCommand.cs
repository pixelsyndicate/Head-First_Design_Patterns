using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class LightOnCommand : IRemoteCommand
    {
        private readonly Light _receiver;

        public LightOnCommand(Light receiver)
        {
            _receiver = receiver;
        }

        #region Command Members

        public object Execute()
        {
            return _receiver.On();
        }

        #endregion
        public string GetCommandName
        {
            get { return MethodBase.GetCurrentMethod().DeclaringType?.FullName.Replace("CommandPatternRemoteControl.VendorCode.Commands.", ""); }

        }
        public Type GetCommandType
        {
            get { throw new NotImplementedException(); }
        }

        public Action Undo()
        {
            _receiver.Off();
            return null;
        }
    }
}