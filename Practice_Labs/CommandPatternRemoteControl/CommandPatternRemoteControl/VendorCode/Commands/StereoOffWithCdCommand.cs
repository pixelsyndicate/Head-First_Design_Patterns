using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class StereoOffWithCdCommand :  IRemoteCommand
    {
        private readonly Stereo _receiver;

        public StereoOffWithCdCommand(Stereo receiver)
        {
            _receiver = receiver;
        }

        public object Execute()
        {
            return _receiver.Off();
            }

        public  string GetCommandName
        {
            get { return MethodBase.GetCurrentMethod().DeclaringType?.FullName.Replace("CommandPatternRemoteControl.VendorCode.Commands.", ""); }

        }
        public  Type GetCommandType
        {
            get { throw new NotImplementedException(); }
        }

        public Action Undo()
        {
            // Console.WriteLine("\n ----- UNDO PRESSED ----- \n");
            return () => _receiver.On();
        }
    }
}