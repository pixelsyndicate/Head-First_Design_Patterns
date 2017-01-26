using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class StereoOnWithCdCommand :IRemoteCommand
    {
        private readonly Stereo _receiver;

        public StereoOnWithCdCommand(Stereo receiver)
        {
            _receiver = receiver;
        }

        public object Execute()
        {
            return _receiver.SetCd() + _receiver.SetLevel(11) + _receiver.On();
        }
       public Action Undo()
        {
            return () => _receiver.Off();
        }
        public  string GetCommandName
        {
            get { return MethodBase.GetCurrentMethod().DeclaringType?.FullName.Replace("CommandPatternRemoteControl.VendorCode.Commands.", ""); }

        }
        public  Type GetCommandType
        {
            get { throw new NotImplementedException(); }
        }


    }
}