using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class TvOnCommand :  IRemoteCommand
    {
        private readonly TV _receiver;

        public TvOnCommand(TV receiver)
        {
            _receiver = receiver;
        }

        public object Execute()
        {
            return _receiver.On();

        }
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
            return () => _receiver.Off();
        }
    }
}